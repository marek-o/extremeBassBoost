using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace extremeBassBoost
{
    public partial class Form1 : Form
    {
        SoundWrapper recorder;
        SoundWrapper player;

        public Form1()
        {
            InitializeComponent();
            recorder = new SoundWrapper(SoundWrapper.Mode.Record, 16, 2, 48000, 1024*8);
            recorder.NewDataPresent += Recorder_NewDataPresent;

            player = new SoundWrapper(SoundWrapper.Mode.Play, 16, 2, 48000, 1024*8);
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

                    //input = (short)(input / 10000 * 10000);

                    //input *= 2;
                    //temp = (short)(temp + variable1 * (inputL - temp));
                    const float scale = 0.1f;
                    bass1L = (short)(bass1L + scale * variable1 * (inputL - bass1L));
                    bass2L = (short)(bass2L + scale * variable1 * (bass1L - bass2L));

                    bass1R = (short)(bass1R + scale * variable1 * (inputR - bass1R));
                    bass2R = (short)(bass2R + scale * variable1 * (bass1R - bass2R));

                    short outputL = Limit(variable3 * (100 * variable2 * bass2L + inputL));
                    short outputR = Limit(variable3 * (100 * variable2 * bass2R + inputR));

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
            labelQueue.Text = "Bytes in queue: " + queue.Count * 1024 * 8; //FIXME

            if (clipping)
            {
                clipping = false;
                labelClipping.Visible = true;
                //trackBar2.Value = (int)(trackBar2.Value * 0.9);
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

        private void buttonStartRec_Click(object sender, EventArgs e)
        {
            int device = int.Parse(((string)comboBoxRec.SelectedItem).Split(':').First());
            recorder.Start(device);
        }

        private void buttonStopRec_Click(object sender, EventArgs e)
        {
            recorder.Stop();
        }

        private void buttonStartPlay_Click(object sender, EventArgs e)
        {
            StartPlayer();
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

        private void buttonStopPlay_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void buttonDSPStart_Click(object sender, EventArgs e)
        {
            int device = int.Parse(((string)comboBoxRec.SelectedItem).Split(':').First());
            timerStartup.Start();
            recorder.Start(device);
        }

        private void buttonDSPStop_Click(object sender, EventArgs e)
        {
            recorder.Stop();
            player.Stop();
            queue.Clear();
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            if (queue.Count >= 4)
            {
                StartPlayer();
                timerStartup.Stop();
            }
        }

        private float variable1 = 0.0f;
        private float variable2 = 0.0f;
        private float variable3 = 0.0f;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            variable1 = trackBar1.Value / (float)trackBar1.Maximum;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            variable2 = trackBar2.Value / (float)trackBar2.Maximum;
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            variable3 = trackBar3.Value / (float)trackBar3.Maximum;

        }
    }
}
