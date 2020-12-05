namespace extremeBassBoost
{
    partial class ExtremeBassBoost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtremeBassBoost));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRec = new System.Windows.Forms.ComboBox();
            this.comboBoxPlay = new System.Windows.Forms.ComboBox();
            this.buttonDSPStop = new System.Windows.Forms.Button();
            this.buttonDSPStart = new System.Windows.Forms.Button();
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.labelClipping = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelBassBoost = new System.Windows.Forms.Label();
            this.labelFilterFreq = new System.Windows.Forms.Label();
            this.labelUnderrun = new System.Windows.Forms.Label();
            this.labelOverrun = new System.Windows.Forms.Label();
            this.labelDebug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Input:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output:";
            // 
            // comboBoxRec
            // 
            this.comboBoxRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRec.FormattingEnabled = true;
            this.comboBoxRec.Location = new System.Drawing.Point(77, 12);
            this.comboBoxRec.Name = "comboBoxRec";
            this.comboBoxRec.Size = new System.Drawing.Size(217, 21);
            this.comboBoxRec.TabIndex = 8;
            // 
            // comboBoxPlay
            // 
            this.comboBoxPlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlay.FormattingEnabled = true;
            this.comboBoxPlay.Location = new System.Drawing.Point(77, 39);
            this.comboBoxPlay.Name = "comboBoxPlay";
            this.comboBoxPlay.Size = new System.Drawing.Size(217, 21);
            this.comboBoxPlay.TabIndex = 9;
            // 
            // buttonDSPStop
            // 
            this.buttonDSPStop.Enabled = false;
            this.buttonDSPStop.Location = new System.Drawing.Point(96, 66);
            this.buttonDSPStop.Name = "buttonDSPStop";
            this.buttonDSPStop.Size = new System.Drawing.Size(75, 23);
            this.buttonDSPStop.TabIndex = 12;
            this.buttonDSPStop.Text = "Stop";
            this.buttonDSPStop.UseVisualStyleBackColor = true;
            this.buttonDSPStop.Click += new System.EventHandler(this.buttonDSPStop_Click);
            // 
            // buttonDSPStart
            // 
            this.buttonDSPStart.Location = new System.Drawing.Point(16, 66);
            this.buttonDSPStart.Name = "buttonDSPStart";
            this.buttonDSPStart.Size = new System.Drawing.Size(75, 23);
            this.buttonDSPStart.TabIndex = 11;
            this.buttonDSPStart.Text = "Start";
            this.buttonDSPStart.UseVisualStyleBackColor = true;
            this.buttonDSPStart.Click += new System.EventHandler(this.buttonDSPStart_Click);
            // 
            // timerStartup
            // 
            this.timerStartup.Interval = 10;
            this.timerStartup.Tick += new System.EventHandler(this.timerStartup_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10000;
            this.trackBar1.Location = new System.Drawing.Point(168, 95);
            this.trackBar1.Maximum = 1000000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(466, 45);
            this.trackBar1.SmallChange = 1000;
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickFrequency = 100000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HandleMouseWheel);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10000;
            this.trackBar2.Location = new System.Drawing.Point(168, 133);
            this.trackBar2.Maximum = 1000000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(466, 45);
            this.trackBar2.SmallChange = 1000;
            this.trackBar2.TabIndex = 15;
            this.trackBar2.TickFrequency = 100000;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            this.trackBar2.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HandleMouseWheel);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 10000;
            this.trackBar3.Location = new System.Drawing.Point(168, 172);
            this.trackBar3.Maximum = 1000000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(466, 45);
            this.trackBar3.SmallChange = 1000;
            this.trackBar3.TabIndex = 16;
            this.trackBar3.TickFrequency = 100000;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            this.trackBar3.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HandleMouseWheel);
            // 
            // labelClipping
            // 
            this.labelClipping.AutoSize = true;
            this.labelClipping.BackColor = System.Drawing.Color.Red;
            this.labelClipping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelClipping.ForeColor = System.Drawing.Color.White;
            this.labelClipping.Location = new System.Drawing.Point(185, 71);
            this.labelClipping.Name = "labelClipping";
            this.labelClipping.Size = new System.Drawing.Size(58, 15);
            this.labelClipping.TabIndex = 17;
            this.labelClipping.Text = "CLIPPING";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 38);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filter frequency (roughly)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Bass volume";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Master volume";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(126, 172);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(21, 13);
            this.labelVolume.TabIndex = 21;
            this.labelVolume.Text = "0%";
            // 
            // labelBassBoost
            // 
            this.labelBassBoost.AutoSize = true;
            this.labelBassBoost.Location = new System.Drawing.Point(126, 133);
            this.labelBassBoost.Name = "labelBassBoost";
            this.labelBassBoost.Size = new System.Drawing.Size(21, 13);
            this.labelBassBoost.TabIndex = 22;
            this.labelBassBoost.Text = "x 0";
            // 
            // labelFilterFreq
            // 
            this.labelFilterFreq.AutoSize = true;
            this.labelFilterFreq.Location = new System.Drawing.Point(126, 95);
            this.labelFilterFreq.Name = "labelFilterFreq";
            this.labelFilterFreq.Size = new System.Drawing.Size(29, 13);
            this.labelFilterFreq.TabIndex = 23;
            this.labelFilterFreq.Text = "0 Hz";
            // 
            // labelUnderrun
            // 
            this.labelUnderrun.AutoSize = true;
            this.labelUnderrun.BackColor = System.Drawing.Color.Red;
            this.labelUnderrun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelUnderrun.ForeColor = System.Drawing.Color.White;
            this.labelUnderrun.Location = new System.Drawing.Point(247, 71);
            this.labelUnderrun.Name = "labelUnderrun";
            this.labelUnderrun.Size = new System.Drawing.Size(117, 15);
            this.labelUnderrun.TabIndex = 24;
            this.labelUnderrun.Text = "BUFFER UNDERRUN";
            // 
            // labelOverrun
            // 
            this.labelOverrun.AutoSize = true;
            this.labelOverrun.BackColor = System.Drawing.Color.Red;
            this.labelOverrun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOverrun.ForeColor = System.Drawing.Color.White;
            this.labelOverrun.Location = new System.Drawing.Point(370, 71);
            this.labelOverrun.Name = "labelOverrun";
            this.labelOverrun.Size = new System.Drawing.Size(108, 15);
            this.labelOverrun.TabIndex = 25;
            this.labelOverrun.Text = "BUFFER OVERRUN";
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.Location = new System.Drawing.Point(314, 15);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(37, 13);
            this.labelDebug.TabIndex = 26;
            this.labelDebug.Text = "debug";
            this.labelDebug.Visible = false;
            // 
            // ExtremeBassBoost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 220);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.labelOverrun);
            this.Controls.Add(this.labelUnderrun);
            this.Controls.Add(this.labelFilterFreq);
            this.Controls.Add(this.labelBassBoost);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelClipping);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonDSPStop);
            this.Controls.Add(this.buttonDSPStart);
            this.Controls.Add(this.comboBoxPlay);
            this.Controls.Add(this.comboBoxRec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExtremeBassBoost";
            this.Text = "Extreme Bass Boost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtremeBassBoost_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRec;
        private System.Windows.Forms.ComboBox comboBoxPlay;
        private System.Windows.Forms.Button buttonDSPStop;
        private System.Windows.Forms.Button buttonDSPStart;
        private System.Windows.Forms.Timer timerStartup;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label labelClipping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelBassBoost;
        private System.Windows.Forms.Label labelFilterFreq;
        private System.Windows.Forms.Label labelUnderrun;
        private System.Windows.Forms.Label labelOverrun;
        private System.Windows.Forms.Label labelDebug;
    }
}

