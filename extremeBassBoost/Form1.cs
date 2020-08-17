using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace extremeBassBoost
{
    public partial class Form1 : Form
    {
        SoundRecorder recorder;

        int samplesRecorded = 0;

        public Form1()
        {
            InitializeComponent();
            recorder = new SoundRecorder(16, 2, 48000, 2048);
            recorder.NewDataPresent += Recorder_NewDataPresent;
            recorder.Start();
        }

        private void Recorder_NewDataPresent(object sender, SoundRecorder.NewDataEventArgs e)
        {
            samplesRecorded += e.data.Length;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = samplesRecorded.ToString();
        }
    }
}
