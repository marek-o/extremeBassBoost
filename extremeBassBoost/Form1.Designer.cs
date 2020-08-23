﻿namespace extremeBassBoost
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRec = new System.Windows.Forms.ComboBox();
            this.comboBoxPlay = new System.Windows.Forms.ComboBox();
            this.labelQueue = new System.Windows.Forms.Label();
            this.buttonDSPStop = new System.Windows.Forms.Button();
            this.buttonDSPStart = new System.Windows.Forms.Button();
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.labelClipping = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.labelBassBoost = new System.Windows.Forms.Label();
            this.labelFilterFreq = new System.Windows.Forms.Label();
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
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Input device:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output device:";
            // 
            // comboBoxRec
            // 
            this.comboBoxRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRec.FormattingEnabled = true;
            this.comboBoxRec.Location = new System.Drawing.Point(25, 25);
            this.comboBoxRec.Name = "comboBoxRec";
            this.comboBoxRec.Size = new System.Drawing.Size(217, 21);
            this.comboBoxRec.TabIndex = 8;
            // 
            // comboBoxPlay
            // 
            this.comboBoxPlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlay.FormattingEnabled = true;
            this.comboBoxPlay.Location = new System.Drawing.Point(274, 25);
            this.comboBoxPlay.Name = "comboBoxPlay";
            this.comboBoxPlay.Size = new System.Drawing.Size(217, 21);
            this.comboBoxPlay.TabIndex = 9;
            // 
            // labelQueue
            // 
            this.labelQueue.AutoSize = true;
            this.labelQueue.Location = new System.Drawing.Point(22, 174);
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.Size = new System.Drawing.Size(35, 13);
            this.labelQueue.TabIndex = 10;
            this.labelQueue.Text = "label5";
            // 
            // buttonDSPStop
            // 
            this.buttonDSPStop.Location = new System.Drawing.Point(25, 242);
            this.buttonDSPStop.Name = "buttonDSPStop";
            this.buttonDSPStop.Size = new System.Drawing.Size(75, 23);
            this.buttonDSPStop.TabIndex = 12;
            this.buttonDSPStop.Text = "Stop";
            this.buttonDSPStop.UseVisualStyleBackColor = true;
            this.buttonDSPStop.Click += new System.EventHandler(this.buttonDSPStop_Click);
            // 
            // buttonDSPStart
            // 
            this.buttonDSPStart.Location = new System.Drawing.Point(25, 213);
            this.buttonDSPStart.Name = "buttonDSPStart";
            this.buttonDSPStart.Size = new System.Drawing.Size(75, 23);
            this.buttonDSPStart.TabIndex = 11;
            this.buttonDSPStart.Text = "Start";
            this.buttonDSPStart.UseVisualStyleBackColor = true;
            this.buttonDSPStart.Click += new System.EventHandler(this.buttonDSPStart_Click);
            // 
            // timerStartup
            // 
            this.timerStartup.Enabled = true;
            this.timerStartup.Interval = 10;
            this.timerStartup.Tick += new System.EventHandler(this.timerStartup_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10000;
            this.trackBar1.Location = new System.Drawing.Point(172, 277);
            this.trackBar1.Maximum = 1000000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(466, 45);
            this.trackBar1.SmallChange = 1000;
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickFrequency = 100000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 39);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5fas\r\nfasdfsd\r\ndsafs\r\n";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10000;
            this.trackBar2.Location = new System.Drawing.Point(172, 315);
            this.trackBar2.Maximum = 1000000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(466, 45);
            this.trackBar2.SmallChange = 1000;
            this.trackBar2.TabIndex = 15;
            this.trackBar2.TickFrequency = 100000;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 10000;
            this.trackBar3.Location = new System.Drawing.Point(172, 354);
            this.trackBar3.Maximum = 1000000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(466, 45);
            this.trackBar3.SmallChange = 1000;
            this.trackBar3.TabIndex = 16;
            this.trackBar3.TickFrequency = 100000;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // labelClipping
            // 
            this.labelClipping.AutoSize = true;
            this.labelClipping.BackColor = System.Drawing.Color.Red;
            this.labelClipping.ForeColor = System.Drawing.Color.White;
            this.labelClipping.Location = new System.Drawing.Point(122, 218);
            this.labelClipping.Name = "labelClipping";
            this.labelClipping.Size = new System.Drawing.Size(56, 13);
            this.labelClipping.TabIndex = 17;
            this.labelClipping.Text = "CLIPPING";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 38);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filter frequency (roughly)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Bass boost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Master volume";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(137, 354);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(21, 13);
            this.labelVolume.TabIndex = 21;
            this.labelVolume.Text = "0%";
            // 
            // labelBassBoost
            // 
            this.labelBassBoost.AutoSize = true;
            this.labelBassBoost.Location = new System.Drawing.Point(137, 315);
            this.labelBassBoost.Name = "labelBassBoost";
            this.labelBassBoost.Size = new System.Drawing.Size(21, 13);
            this.labelBassBoost.TabIndex = 22;
            this.labelBassBoost.Text = "x 0";
            // 
            // labelFilterFreq
            // 
            this.labelFilterFreq.AutoSize = true;
            this.labelFilterFreq.Location = new System.Drawing.Point(137, 277);
            this.labelFilterFreq.Name = "labelFilterFreq";
            this.labelFilterFreq.Size = new System.Drawing.Size(29, 13);
            this.labelFilterFreq.TabIndex = 23;
            this.labelFilterFreq.Text = "0 Hz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 402);
            this.Controls.Add(this.labelFilterFreq);
            this.Controls.Add(this.labelBassBoost);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelClipping);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonDSPStop);
            this.Controls.Add(this.buttonDSPStart);
            this.Controls.Add(this.labelQueue);
            this.Controls.Add(this.comboBoxPlay);
            this.Controls.Add(this.comboBoxRec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Button buttonDSPStop;
        private System.Windows.Forms.Button buttonDSPStart;
        private System.Windows.Forms.Timer timerStartup;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label labelClipping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelBassBoost;
        private System.Windows.Forms.Label labelFilterFreq;
    }
}

