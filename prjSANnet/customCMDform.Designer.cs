namespace prjSANnet
{
    partial class customCMDform
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
            this.customCMD = new System.Windows.Forms.TextBox();
            this.customBt = new System.Windows.Forms.Button();
            this.customOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // customCMD
            // 
            this.customCMD.Location = new System.Drawing.Point(12, 12);
            this.customCMD.Name = "customCMD";
            this.customCMD.Size = new System.Drawing.Size(575, 20);
            this.customCMD.TabIndex = 0;
            // 
            // customBt
            // 
            this.customBt.Location = new System.Drawing.Point(593, 12);
            this.customBt.Name = "customBt";
            this.customBt.Size = new System.Drawing.Size(56, 20);
            this.customBt.TabIndex = 1;
            this.customBt.Text = "GO";
            this.customBt.UseVisualStyleBackColor = true;
            this.customBt.Click += new System.EventHandler(this.customBt_Click);
            // 
            // customOutput
            // 
            this.customOutput.Location = new System.Drawing.Point(12, 38);
            this.customOutput.Name = "customOutput";
            this.customOutput.Size = new System.Drawing.Size(637, 518);
            this.customOutput.TabIndex = 2;
            this.customOutput.Text = "";
            // 
            // customCMDform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 568);
            this.Controls.Add(this.customOutput);
            this.Controls.Add(this.customBt);
            this.Controls.Add(this.customCMD);
            this.Name = "customCMDform";
            this.Text = "Custom CMD";
            this.Load += new System.EventHandler(this.customCMDform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customCMD;
        private System.Windows.Forms.Button customBt;
        private System.Windows.Forms.RichTextBox customOutput;
    }
}