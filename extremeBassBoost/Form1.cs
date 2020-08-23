using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace extremeBassBoost
{
    public partial class Form1 : Form
    {
        SoundWrapper recorder;
        SoundWrapper player;

        private const int sampleRate = 48000;
        private const int bufferLengthBytes = 8 * 1024;

        public Form1()
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

            trackBar1.Value = 200000;
            trackBar2.Value = 200000;
            trackBar3.Value = 100000;
        }

        Queue<short[]> queue = new Queue<short[]>();

        private short bass1L, bass2L;
        private short bass1R, bass2R;

        private bool clipping = false;

        private short Limit(float value)
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
                Array.Copy(buf, e.data, buf.Length); //assume equal sizes

                //DSP
                for (int i = 0; i < buf.Length && i < e.data.Length; i += 2)
                {
                    short inputL = buf[i];
                    short inputR = buf[i + 1];

                    bass1L = (short)(bass1L + filterFreq * (inputL - bass1L));
                    bass2L = (short)(bass2L + filterFreq * (bass1L - bass2L));

                    bass1R = (short)(bass1R + filterFreq * (inputR - bass1R));
                    bass2R = (short)(bass2R + filterFreq * (bass1R - bass2R));

                    short outputL = Limit(volume * (bassBoost * bass2L + inputL));
                    short outputR = Limit(volume * (bassBoost * bass2R + inputR));

                    e.data[i] = outputL;
                    e.data[i + 1] = outputR;
                }



            }
            else
            {
                e.data[0] = 30000;
                //for (int i = 0; i < e.data.Length; ++i)
                //{
                //    int current = samplesPlayed + i;

                //    float freq = 1000.0f;

                //    //stereo
                //    if ((current % (int)(48000 * 2 / freq)) - (48000 * 2 / freq / 2) < 0)
                //    {
                //        if (current % 2 == 0)
                //            e.data[i] = 30000;
                //        else
                //            e.data[i] = 30000;

                //    }
                //    else
                //    {
                //        e.data[i] = -30000;
                //    }
                //}
            }
        }

        private void Recorder_NewDataPresent(object sender, SoundWrapper.NewDataEventArgs e)
        {
            queue.Enqueue(e.data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelQueue.Text = "Bytes in queue: " + queue.Count * bufferLengthBytes;

            if (clipping)
            {
                clipping = false;
                labelClipping.Visible = true;
            }
            else
            {
                labelClipping.Visible = false;
            }

            if (queue.Any())
            {
                StringBuilder sb = new StringBuilder();
                var buf = queue.Peek();

                for (int i = 0; i < 10; ++i)
                {
                    sb.AppendLine(buf[i].ToString());
                }

                label5.Text = sb.ToString();
            }
        }

        private void StartPlayer()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => StartPlayer()));
                return;
            }

            int device = int.Parse(((string)comboBoxPlay.SelectedItem).Split(':').First());
            player.Start(device);
        }

        private void buttonDSPStart_Click(object sender, EventArgs e)
        {
            int device = int.Parse(((string)comboBoxRec.SelectedItem).Split(':').First());
            timerStartup.Start();
            recorder.Start(device);

            comboBoxPlay.Enabled = false;
            comboBoxRec.Enabled = false;
        }

        private void buttonDSPStop_Click(object sender, EventArgs e)
        {
            recorder.Stop();
            player.Stop();
            queue.Clear();

            comboBoxPlay.Enabled = true;
            comboBoxRec.Enabled = true;
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            if (queue.Count >= 4)
            {
                StartPlayer();
                timerStartup.Stop();
            }
        }

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
            bassBoost = trackBar2.Value * 100 / (float)trackBar2.Maximum;
            labelBassBoost.Text = string.Format("x {0:F1}", bassBoost);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            volume = trackBar3.Value / (float)trackBar3.Maximum;
            labelVolume.Text = string.Format("{0:P2}", volume);
        }
    }
}
