namespace prjSANnet
{
    partial class deleteZoneCustom
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
            this.messageText = new System.Windows.Forms.RichTextBox();
            this.removeCfg = new System.Windows.Forms.Button();
            this.deleteZone = new System.Windows.Forms.Button();
            this.allFlow = new System.Windows.Forms.Button();
            this.returnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageText
            // 
            this.messageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageText.Enabled = false;
            this.messageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageText.Location = new System.Drawing.Point(132, 12);
            this.messageText.Name = "messageText";
            this.messageText.ReadOnly = true;
            this.messageText.Size = new System.Drawing.Size(221, 40);
            this.messageText.TabIndex = 2;
            this.messageText.Text = "Scegliere il processo:";
            // 
            // removeCfg
            // 
            this.removeCfg.Location = new System.Drawing.Point(29, 53);
            this.removeCfg.Name = "removeCfg";
            this.removeCfg.Size = new System.Drawing.Size(97, 22);
            this.removeCfg.TabIndex = 3;
            this.removeCfg.Text = "Remove Config";
            this.removeCfg.UseVisualStyleBackColor = true;
            this.removeCfg.Click += new System.EventHandler(this.removeCfg_Click);
            // 
            // deleteZone
            // 
            this.deleteZone.Location = new System.Drawing.Point(132, 52);
            this.deleteZone.Name = "deleteZone";
            this.deleteZone.Size = new System.Drawing.Size(95, 23);
            this.deleteZone.TabIndex = 4;
            this.deleteZone.Text = "Delete Zone";
            this.deleteZone.UseVisualStyleBackColor = true;
            this.deleteZone.Click += new System.EventHandler(this.deleteZone_Click);
            // 
            // allFlow
            // 
            this.allFlow.Location = new System.Drawing.Point(233, 53);
            this.allFlow.Name = "allFlow";
            this.allFlow.Size = new System.Drawing.Size(87, 22);
            this.allFlow.TabIndex = 5;
            this.allFlow.Text = "All Flow";
            this.allFlow.UseVisualStyleBackColor = true;
            this.allFlow.Click += new System.EventHandler(this.allFlow_Click);
            // 
            // returnBack
            // 
            this.returnBack.Location = new System.Drawing.Point(326, 53);
            this.returnBack.Name = "returnBack";
            this.returnBack.Size = new System.Drawing.Size(97, 22);
            this.returnBack.TabIndex = 6;
            this.returnBack.Text = "Cancel";
            this.returnBack.UseVisualStyleBackColor = true;
            this.returnBack.Click += new System.EventHandler(this.returnBack_Click);
            // 
            // deleteZoneCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 88);
            this.Controls.Add(this.returnBack);
            this.Controls.Add(this.allFlow);
            this.Controls.Add(this.deleteZone);
            this.Controls.Add(this.removeCfg);
            this.Controls.Add(this.messageText);
            this.Name = "deleteZoneCustom";
            this.Text = "Delete Cfg - Zone";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox messageText;
        private System.Windows.Forms.Button removeCfg;
        private System.Windows.Forms.Button deleteZone;
        private System.Windows.Forms.Button allFlow;
        private System.Windows.Forms.Button returnBack;
    }
}