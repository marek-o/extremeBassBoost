using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace extremeBassBoost
{
    public partial class ExtremeBassBoost : Form
    {
        SoundWrapper recorder;
        SoundWrapper player;

        private const int sampleRate = 48000;
        private const int bufferLengthBytes = 8 * 1024;
        private const int initialQueueSize = 2;

        public ExtremeBassBoost()
        {
            InitializeComponent();
            recorder = new SoundWrapper(SoundWrapper.Mode.Record, 16, 2, sampleRate, bufferLengthBytes);
            recorder.NewDataPresent += Recorder_NewDataPresent;

            player = new SoundWrapper(SoundWrapper.Mode.Play, 16, 2, sampleRate, bufferLengthBytes);
            player.NewDataRequested += Player_NewDataRequested;

            comboBoxRec.Items.AddRange(recorder.EnumerateDevices().ToArray());
            comboBoxRec.SelectedIndex = 0;

            comboBoxPlay.Items.AddRange(player.EnumerateDevices().ToArray());
            comboBoxPlay.SelectedIndex = 0;

            trackBar1.Value = 100000;
            trackBar2.Value = 500000;
            trackBar3.Value = 500000;
        }

        Queue<short[]> queue = new Queue<short[]>();

        private double bass1L, bass2L;
        private double bass1R, bass2R;

        private bool clipping = false;
        private bool underrun = false;

        private bool isPlaying = false;
        private bool isStopping = false;

        private bool wasUnderrun = false;
        private bool wasOverrun = false;

        private short Limit(double value)
        {
            if (value > short.MaxValue)
            {
                clipping = true;
                return short.MaxValue;
            }
            else if (value < short.MinValue)
            {
                clipping = true;
                return short.MinValue;
            }
            else
            {
                return (short)value;
            }
        }

        private void Player_NewDataRequested(object sender, SoundWrapper.NewDataEventArgs e)
        {
            if (queue.Count > 0)
            {
                var buf = queue.Dequeue();

                for (int i = 0; i < buf.Length && i < e.data.Length; i += 2)
                {
                    double inputL = buf[i];
                    double inputR = buf[i + 1];

                    bass1L = bass1L + filterFreq * (inputL - bass1L);
                    bass2L = bass2L + filterFreq * (bass1L - bass2L);

                    bass1R = bass1R + filterFreq * (inputR - bass1R);
                    bass2R = bass2R + filterFreq * (bass1R - bass2R);

                    short outputL = Limit(volumeSmoothed * (bassBoostSmoothed * bass2L + inputL));
                    short outputR = Limit(volumeSmoothed * (bassBoostSmoothed * bass2R + inputR));

                    e.data[i] = outputL;
                    e.data[i + 1] = outputR;

                    volumeSmoothed = volumeSmoothed + 0.01f * (volume - volumeSmoothed);
                    bassBoostSmoothed = bassBoostSmoothed + 0.01f * (bassBoost - bassBoostSmoothed);
                }
            }
            else
            {
                if (isStopping)
                {
                    StopPlayer();
                }
                else if (isPlaying)
                {
                    underrun = true;
                }
            }
        }

        private void Recorder_NewDataPresent(object sender, SoundWrapper.NewDataEventArgs e)
        {
            queue.Enqueue(e.data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool overrun = queue.Count > initialQueueSize * 2;

            labelClipping.BackColor = clipping ? Color.Red : Color.DarkGray;
            labelUnderrun.BackColor = underrun ? Color.Red : wasUnderrun ? Color.Maroon : Color.DarkGray;
            labelOverrun.BackColor = overrun ? Color.Red : wasOverrun ? Color.Maroon : Color.DarkGray;

            wasUnderrun |= underrun;
            wasOverrun |= overrun;

            clipping = false;
            underrun = false;

#if DEBUG
            labelDebug.Visible = true;
            labelDebug.Text = string.Format("queue size: {0}", queue.Count);
#endif
        }

        private void StartPlayer()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => StartPlayer()));
                return;
            }

            var device = (SoundWrapper.DeviceInfo)comboBoxPlay.SelectedItem;
            isPlaying = true;
            player.Start(device);

            buttonDSPStop.Enabled = true;
        }

        private void StopPlayer()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => StopPlayer()));
                return;
            }

            player.Stop();
            isStopping = false;
            isPlaying = false;
            queue.Clear();

            UpdateVolume(); //restore previous volume

            comboBoxPlay.Enabled = true;
            comboBoxRec.Enabled = true;
            buttonDSPStart.Enabled = true;

            wasUnderrun = false;
            wasOverrun = false;
        }

        private void buttonDSPStart_Click(object sender, EventArgs e)
        {
            var device = (SoundWrapper.DeviceInfo)comboBoxRec.SelectedItem;
            timerStartup.Start();
            recorder.Start(device);

            comboBoxPlay.Enabled = false;
            comboBoxRec.Enabled = false;
            buttonDSPStart.Enabled = false;

            volumeSmoothed = 0.0f; //smooth start
        }

        private void buttonDSPStop_Click(object sender, EventArgs e)
        {
            volume = 0.0f; //smooth stop

            isStopping = true;
            recorder.Stop();

            buttonDSPStop.Enabled = false;
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            if (queue.Count >= initialQueueSize)
            {
                StartPlayer();
                timerStartup.Stop();
            }
        }

        private float bassBoostSmoothed = 0.0f;
        private float volumeSmoothed = 0.0f;

        private float filterFreq = 0.0f;
        private float bassBoost = 0.0f;
        private float volume = 0.0f;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            filterFreq = trackBar1.Value * 0.1f / (float)trackBar1.Maximum;
            labelFilterFreq.Text = string.Format("{0:F0} Hz", filterFreq * 48000);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            float bassVolumeSlider = trackBar2.Value / (float)trackBar2.Maximum;
            float bassVolumedB = 20.0f * bassVolumeSlider;
            float bassVolume = (float)Math.Pow(10, bassVolumedB / 10);
            bassBoost = bassVolume - 1;
            labelBassBoost.Text = string.Format("+{0:F1} dB", bassVolumedB);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            UpdateVolume();
        }

        private void UpdateVolume()
        {
            float volumeSlider = trackBar3.Value / (float)trackBar3.Maximum;
            float volumedB = 50.0f * (volumeSlider - 1);
            volume = (float)Math.Pow(10, volumedB / 10);
            labelVolume.Text = string.Format("{0:F1} dB", volumedB);
        }

        private void HandleMouseWheel(object sender, MouseEventArgs e)
        {
            if (sender is TrackBar t)
            {
                int delta = e.Delta * t.Maximum / SystemInformation.MouseWheelScrollDelta / 100;
                t.Value = Math.Max(t.Minimum, Math.Min(t.Maximum, t.Value + delta));
            }
        }

        private void ExtremeBassBoost_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonDSPStop.PerformClick();
        }
    }
}
