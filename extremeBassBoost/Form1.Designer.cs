namespace extremeBassBoost
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
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStartRec = new System.Windows.Forms.Button();
            this.buttonStopRec = new System.Windows.Forms.Button();
            this.buttonStopPlay = new System.Windows.Forms.Button();
            this.buttonStartPlay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRec = new System.Windows.Forms.ComboBox();
            this.comboBoxPlay = new System.Windows.Forms.ComboBox();
            this.labelQueue = new System.Windows.Forms.Label();
            this.buttonDSPStop = new System.Windows.Forms.Button();
            this.buttonDSPStart = new System.Windows.Forms.Button();
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonStartRec
            // 
            this.buttonStartRec.Location = new System.Drawing.Point(25, 69);
            this.buttonStartRec.Name = "buttonStartRec";
            this.buttonStartRec.Size = new System.Drawing.Size(75, 23);
            this.buttonStartRec.TabIndex = 1;
            this.buttonStartRec.Text = "Start";
            this.buttonStartRec.UseVisualStyleBackColor = true;
            this.buttonStartRec.Click += new System.EventHandler(this.buttonStartRec_Click);
            // 
            // buttonStopRec
            // 
            this.buttonStopRec.Location = new System.Drawing.Point(25, 98);
            this.buttonStopRec.Name = "buttonStopRec";
            this.buttonStopRec.Size = new System.Drawing.Size(75, 23);
            this.buttonStopRec.TabIndex = 2;
            this.buttonStopRec.Text = "Stop";
            this.buttonStopRec.UseVisualStyleBackColor = true;
            this.buttonStopRec.Click += new System.EventHandler(this.buttonStopRec_Click);
            // 
            // buttonStopPlay
            // 
            this.buttonStopPlay.Location = new System.Drawing.Point(274, 98);
            this.buttonStopPlay.Name = "buttonStopPlay";
            this.buttonStopPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonStopPlay.TabIndex = 5;
            this.buttonStopPlay.Text = "Stop";
            this.buttonStopPlay.UseVisualStyleBackColor = true;
            this.buttonStopPlay.Click += new System.EventHandler(this.buttonStopPlay_Click);
            // 
            // buttonStartPlay
            // 
            this.buttonStartPlay.Location = new System.Drawing.Point(274, 69);
            this.buttonStartPlay.Name = "buttonStartPlay";
            this.buttonStartPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonStartPlay.TabIndex = 4;
            this.buttonStartPlay.Text = "Start";
            this.buttonStartPlay.UseVisualStyleBackColor = true;
            this.buttonStartPlay.Click += new System.EventHandler(this.buttonStartPlay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "REC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PLAY";
            // 
            // comboBoxRec
            // 
            this.comboBoxRec.FormattingEnabled = true;
            this.comboBoxRec.Location = new System.Drawing.Point(25, 127);
            this.comboBoxRec.Name = "comboBoxRec";
            this.comboBoxRec.Size = new System.Drawing.Size(217, 21);
            this.comboBoxRec.TabIndex = 8;
            // 
            // comboBoxPlay
            // 
            this.comboBoxPlay.FormattingEnabled = true;
            this.comboBoxPlay.Location = new System.Drawing.Point(274, 127);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDSPStop);
            this.Controls.Add(this.buttonDSPStart);
            this.Controls.Add(this.labelQueue);
            this.Controls.Add(this.comboBoxPlay);
            this.Controls.Add(this.comboBoxRec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonStopPlay);
            this.Controls.Add(this.buttonStartPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStopRec);
            this.Controls.Add(this.buttonStartRec);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonStartRec;
        private System.Windows.Forms.Button buttonStopRec;
        private System.Windows.Forms.Button buttonStopPlay;
        private System.Windows.Forms.Button buttonStartPlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRec;
        private System.Windows.Forms.ComboBox comboBoxPlay;
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Button buttonDSPStop;
        private System.Windows.Forms.Button buttonDSPStart;
        private System.Windows.Forms.Timer timerStartup;
    }
}

