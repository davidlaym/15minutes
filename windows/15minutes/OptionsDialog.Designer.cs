namespace _15minutes
{
    partial class OptionsDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOnTopNever = new System.Windows.Forms.RadioButton();
            this.chkOnTopRunning = new System.Windows.Forms.RadioButton();
            this.chkOnTop = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSoundTickTack = new System.Windows.Forms.CheckBox();
            this.chkSoundAlarm = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(310, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(206, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveButtonClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOnTopNever);
            this.groupBox1.Controls.Add(this.chkOnTopRunning);
            this.groupBox1.Controls.Add(this.chkOnTop);
            this.groupBox1.Location = new System.Drawing.Point(33, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keep window on top";
            // 
            // chkOnTopNever
            // 
            this.chkOnTopNever.AutoSize = true;
            this.chkOnTopNever.Location = new System.Drawing.Point(6, 78);
            this.chkOnTopNever.Name = "chkOnTopNever";
            this.chkOnTopNever.Size = new System.Drawing.Size(61, 21);
            this.chkOnTopNever.TabIndex = 6;
            this.chkOnTopNever.TabStop = true;
            this.chkOnTopNever.Text = "Never";
            this.chkOnTopNever.UseVisualStyleBackColor = true;
            // 
            // chkOnTopRunning
            // 
            this.chkOnTopRunning.AutoSize = true;
            this.chkOnTopRunning.Location = new System.Drawing.Point(6, 24);
            this.chkOnTopRunning.Name = "chkOnTopRunning";
            this.chkOnTopRunning.Size = new System.Drawing.Size(173, 21);
            this.chkOnTopRunning.TabIndex = 5;
            this.chkOnTopRunning.TabStop = true;
            this.chkOnTopRunning.Text = "Only when clock is ticking";
            this.chkOnTopRunning.UseVisualStyleBackColor = true;
            // 
            // chkOnTop
            // 
            this.chkOnTop.AutoSize = true;
            this.chkOnTop.Location = new System.Drawing.Point(6, 51);
            this.chkOnTop.Name = "chkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(68, 21);
            this.chkOnTop.TabIndex = 5;
            this.chkOnTop.TabStop = true;
            this.chkOnTop.Text = "Allways";
            this.chkOnTop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSoundAlarm);
            this.groupBox2.Controls.Add(this.chkSoundTickTack);
            this.groupBox2.Location = new System.Drawing.Point(264, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 119);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sounds";
            // 
            // chkSundTickTack
            // 
            this.chkSoundTickTack.AutoSize = true;
            this.chkSoundTickTack.Location = new System.Drawing.Point(6, 25);
            this.chkSoundTickTack.Name = "chkSoundTickTack";
            this.chkSoundTickTack.Size = new System.Drawing.Size(101, 21);
            this.chkSoundTickTack.TabIndex = 0;
            this.chkSoundTickTack.Text = "Play tick-tack";
            this.chkSoundTickTack.UseVisualStyleBackColor = true;
            // 
            // chkSoundAlarm
            // 
            this.chkSoundAlarm.AutoSize = true;
            this.chkSoundAlarm.Location = new System.Drawing.Point(6, 51);
            this.chkSoundAlarm.Name = "chkSoundAlarm";
            this.chkSoundAlarm.Size = new System.Drawing.Size(132, 21);
            this.chkSoundAlarm.TabIndex = 1;
            this.chkSoundAlarm.Text = "Play alarm on end";
            this.chkSoundAlarm.UseVisualStyleBackColor = true;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton chkOnTopRunning;
        private System.Windows.Forms.RadioButton chkOnTop;
        private System.Windows.Forms.RadioButton chkOnTopNever;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSoundAlarm;
        private System.Windows.Forms.CheckBox chkSoundTickTack;
    }
}