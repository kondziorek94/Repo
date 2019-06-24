namespace Recorder
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
            this.StartRecordingButton = new System.Windows.Forms.Button();
            this.FinishRecordingButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartRecordingButton
            // 
            this.StartRecordingButton.Location = new System.Drawing.Point(37, 173);
            this.StartRecordingButton.Name = "StartRecordingButton";
            this.StartRecordingButton.Size = new System.Drawing.Size(317, 144);
            this.StartRecordingButton.TabIndex = 0;
            this.StartRecordingButton.Text = "Start";
            this.StartRecordingButton.UseVisualStyleBackColor = true;
            this.StartRecordingButton.Click += new System.EventHandler(this.StartRecordingButton_Click);
            // 
            // FinishRecordingButton
            // 
            this.FinishRecordingButton.Location = new System.Drawing.Point(402, 173);
            this.FinishRecordingButton.Name = "FinishRecordingButton";
            this.FinishRecordingButton.Size = new System.Drawing.Size(317, 144);
            this.FinishRecordingButton.TabIndex = 1;
            this.FinishRecordingButton.Text = "Finish";
            this.FinishRecordingButton.UseVisualStyleBackColor = true;
            this.FinishRecordingButton.Click += new System.EventHandler(this.FinishRecordingButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(37, 63);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(682, 31);
            this.infoBox.TabIndex = 2;
            this.infoBox.Text = "Press Start to start recording";
            this.infoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.FinishRecordingButton);
            this.Controls.Add(this.StartRecordingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartRecordingButton;
        private System.Windows.Forms.Button FinishRecordingButton;
        private System.Windows.Forms.TextBox infoBox;
    }
}

