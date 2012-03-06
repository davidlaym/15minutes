namespace _15minutes
{
    partial class FormMain
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
            this.buttonStartOk = new System.Windows.Forms.Button();
            this.label5min = new System.Windows.Forms.Label();
            this.label15min = new System.Windows.Forms.Label();
            this.label25min = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.labelWebSite = new System.Windows.Forms.Label();
            this.label45min = new System.Windows.Forms.Label();
            this.labelOther = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblOptions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartOk
            // 
            this.buttonStartOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonStartOk.Location = new System.Drawing.Point(0, 88);
            this.buttonStartOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartOk.Name = "buttonStartOk";
            this.buttonStartOk.Size = new System.Drawing.Size(295, 37);
            this.buttonStartOk.TabIndex = 0;
            this.buttonStartOk.Text = "Start";
            this.buttonStartOk.UseVisualStyleBackColor = true;
            this.buttonStartOk.Click += new System.EventHandler(this.buttonStartOk_Click);
            // 
            // label5min
            // 
            this.label5min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5min.AutoSize = true;
            this.label5min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5min.Location = new System.Drawing.Point(258, 2);
            this.label5min.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5min.Name = "label5min";
            this.label5min.Size = new System.Drawing.Size(37, 15);
            this.label5min.TabIndex = 1;
            this.label5min.Text = "5 min";
            this.label5min.Click += new System.EventHandler(this.label5min_Click);
            // 
            // label15min
            // 
            this.label15min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15min.AutoSize = true;
            this.label15min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15min.Location = new System.Drawing.Point(252, 17);
            this.label15min.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15min.Name = "label15min";
            this.label15min.Size = new System.Drawing.Size(43, 15);
            this.label15min.TabIndex = 2;
            this.label15min.Text = "15 min";
            this.label15min.Click += new System.EventHandler(this.label15min_Click);
            // 
            // label25min
            // 
            this.label25min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25min.AutoSize = true;
            this.label25min.BackColor = System.Drawing.Color.White;
            this.label25min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25min.Location = new System.Drawing.Point(252, 32);
            this.label25min.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25min.Name = "label25min";
            this.label25min.Size = new System.Drawing.Size(43, 15);
            this.label25min.TabIndex = 3;
            this.label25min.Text = "25 min";
            this.label25min.Click += new System.EventHandler(this.label25min_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(150, 88);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(145, 37);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Visible = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPauseResume.Location = new System.Drawing.Point(0, 88);
            this.buttonPauseResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(145, 37);
            this.buttonPauseResume.TabIndex = 5;
            this.buttonPauseResume.Text = "Pause";
            this.buttonPauseResume.UseVisualStyleBackColor = true;
            this.buttonPauseResume.Visible = false;
            this.buttonPauseResume.Click += new System.EventHandler(this.buttonPauseResume_Click);
            // 
            // labelWebSite
            // 
            this.labelWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWebSite.AutoSize = true;
            this.labelWebSite.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelWebSite.Location = new System.Drawing.Point(2, 62);
            this.labelWebSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWebSite.Name = "labelWebSite";
            this.labelWebSite.Size = new System.Drawing.Size(95, 21);
            this.labelWebSite.TabIndex = 6;
            this.labelWebSite.Text = "visit website";
            this.labelWebSite.Click += new System.EventHandler(this.labelWebSite_Click);
            // 
            // label45min
            // 
            this.label45min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label45min.AutoSize = true;
            this.label45min.BackColor = System.Drawing.Color.White;
            this.label45min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45min.Location = new System.Drawing.Point(252, 47);
            this.label45min.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45min.Name = "label45min";
            this.label45min.Size = new System.Drawing.Size(43, 15);
            this.label45min.TabIndex = 7;
            this.label45min.Text = "45 min";
            this.label45min.Click += new System.EventHandler(this.label45min_Click);
            // 
            // labelOther
            // 
            this.labelOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOther.AutoSize = true;
            this.labelOther.BackColor = System.Drawing.Color.White;
            this.labelOther.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOther.Location = new System.Drawing.Point(248, 62);
            this.labelOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOther.Name = "labelOther";
            this.labelOther.Size = new System.Drawing.Size(47, 15);
            this.labelOther.TabIndex = 8;
            this.labelOther.Text = "custom";
            this.labelOther.Click += new System.EventHandler(this.labelOther_Click);
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(2, 2);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(65, 21);
            this.lblOptions.TabIndex = 9;
            this.lblOptions.Text = "Options";
            this.lblOptions.Click += new System.EventHandler(this.lblOptions_Click);
            this.lblOptions.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblOptions.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(295, 125);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.labelOther);
            this.Controls.Add(this.label45min);
            this.Controls.Add(this.labelWebSite);
            this.Controls.Add(this.buttonPauseResume);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label25min);
            this.Controls.Add(this.label15min);
            this.Controls.Add(this.label5min);
            this.Controls.Add(this.buttonStartOk);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "15minutes v2.0a";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartOk;
        private System.Windows.Forms.Label label5min;
        private System.Windows.Forms.Label label15min;
        private System.Windows.Forms.Label label25min;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.Windows.Forms.Label labelWebSite;
        private System.Windows.Forms.Label label45min;
        private System.Windows.Forms.Label labelOther;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblOptions;
    }
}

