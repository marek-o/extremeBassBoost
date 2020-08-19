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

        int samplesRecorded = 0;
        int samplesPlayed = 0;

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
        }

        Queue<short[]> queue = new Queue<short[]>();

        private void Player_NewDataRequested(object sender, SoundWrapper.NewDataEventArgs e)
        {
            if (queue.Count > 0)
            {
                var buf = queue.Dequeue();
                Array.Copy(buf, e.data, buf.Length); //assume equal sizes

                //DSP
                for (int i = 0; i < buf.Length && i < e.data.Length; ++i)
                {
                    short input = buf[i];

                    input = (short)(input / 10000 * 10000);

                    //input *= 2;

                    e.data[i] = input;
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

            samplesPlayed += e.data.Length;
        }

        private void Recorder_NewDataPresent(object sender, SoundWrapper.NewDataEventArgs e)
        {
            queue.Enqueue(e.data);
            samplesRecorded += e.data.Length;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (samplesRecorded * 2).ToString();
            label2.Text = (samplesPlayed * 2).ToString();
            labelQueue.Text = "Bytes in queue: " + queue.Count * 1024 * 8; //FIXME
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
    }
}
