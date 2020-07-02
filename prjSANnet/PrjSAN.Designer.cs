namespace prjSANnet
{
    partial class PrjSAN
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBox = new System.Windows.Forms.ListBox();
            this.hostName = new System.Windows.Forms.TextBox();
            this.configName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SANcombo = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.newZoning = new System.Windows.Forms.Button();
            this.deleteZone = new System.Windows.Forms.Button();
            this.zoneShow = new System.Windows.Forms.Button();
            this.aliShow = new System.Windows.Forms.Button();
            this.customCMD = new System.Windows.Forms.Button();
            this.findWWN = new System.Windows.Forms.Button();
            this.cmdNewZoneFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.swVersion = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelInfo_acc = new System.Windows.Forms.Label();
            this.openDocumentation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(292, 8);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(468, 82);
            this.logBox.TabIndex = 3;
            // 
            // hostName
            // 
            this.hostName.Location = new System.Drawing.Point(113, 35);
            this.hostName.Name = "hostName";
            this.hostName.Size = new System.Drawing.Size(173, 20);
            this.hostName.TabIndex = 1;
            // 
            // configName
            // 
            this.configName.Location = new System.Drawing.Point(113, 9);
            this.configName.Name = "configName";
            this.configName.Size = new System.Drawing.Size(173, 20);
            this.configName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "HOST name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Config Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SAN A or SAN B";
            // 
            // SANcombo
            // 
            this.SANcombo.FormattingEnabled = true;
            this.SANcombo.Location = new System.Drawing.Point(114, 61);
            this.SANcombo.Name = "SANcombo";
            this.SANcombo.Size = new System.Drawing.Size(172, 21);
            this.SANcombo.TabIndex = 2;
            this.SANcombo.SelectedIndexChanged += new System.EventHandler(this.SANcombo_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView1.Location = new System.Drawing.Point(12, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(738, 259);
            this.dataGridView1.TabIndex = 10;
            // 
            // newZoning
            // 
            this.newZoning.Enabled = false;
            this.newZoning.Location = new System.Drawing.Point(325, 96);
            this.newZoning.Name = "newZoning";
            this.newZoning.Size = new System.Drawing.Size(191, 22);
            this.newZoning.TabIndex = 11;
            this.newZoning.Text = "Create new Zoning";
            this.newZoning.UseVisualStyleBackColor = true;
            // 
            // deleteZone
            // 
            this.deleteZone.Enabled = false;
            this.deleteZone.Location = new System.Drawing.Point(522, 96);
            this.deleteZone.Name = "deleteZone";
            this.deleteZone.Size = new System.Drawing.Size(191, 22);
            this.deleteZone.TabIndex = 13;
            this.deleteZone.Text = "Deleting Zone (Cfg - Zone)";
            this.deleteZone.UseVisualStyleBackColor = true;
            this.deleteZone.Click += new System.EventHandler(this.deleteZone_Click);
            // 
            // zoneShow
            // 
            this.zoneShow.Location = new System.Drawing.Point(22, 88);
            this.zoneShow.Name = "zoneShow";
            this.zoneShow.Size = new System.Drawing.Size(129, 22);
            this.zoneShow.TabIndex = 15;
            this.zoneShow.Text = "Search Zone";
            this.zoneShow.UseVisualStyleBackColor = true;
            this.zoneShow.Click += new System.EventHandler(this.zoneShow_Click);
            // 
            // aliShow
            // 
            this.aliShow.Location = new System.Drawing.Point(157, 88);
            this.aliShow.Name = "aliShow";
            this.aliShow.Size = new System.Drawing.Size(129, 22);
            this.aliShow.TabIndex = 16;
            this.aliShow.Text = "Search Alias";
            this.aliShow.UseVisualStyleBackColor = true;
            this.aliShow.Click += new System.EventHandler(this.aliShow_Click);
            // 
            // customCMD
            // 
            this.customCMD.Location = new System.Drawing.Point(22, 116);
            this.customCMD.Name = "customCMD";
            this.customCMD.Size = new System.Drawing.Size(129, 22);
            this.customCMD.TabIndex = 17;
            this.customCMD.Text = "Custom CMD";
            this.customCMD.UseVisualStyleBackColor = true;
            this.customCMD.Click += new System.EventHandler(this.customCMD_Click);
            // 
            // findWWN
            // 
            this.findWWN.Location = new System.Drawing.Point(157, 115);
            this.findWWN.Name = "findWWN";
            this.findWWN.Size = new System.Drawing.Size(129, 22);
            this.findWWN.TabIndex = 18;
            this.findWWN.Text = "Find WWN";
            this.findWWN.UseVisualStyleBackColor = true;
            this.findWWN.Click += new System.EventHandler(this.findWWN_Click);
            // 
            // cmdNewZoneFile
            // 
            this.cmdNewZoneFile.Location = new System.Drawing.Point(325, 124);
            this.cmdNewZoneFile.Name = "cmdNewZoneFile";
            this.cmdNewZoneFile.Size = new System.Drawing.Size(191, 22);
            this.cmdNewZoneFile.TabIndex = 19;
            this.cmdNewZoneFile.Text = "Create new Zoning From File";
            this.cmdNewZoneFile.UseVisualStyleBackColor = true;
            this.cmdNewZoneFile.Click += new System.EventHandler(this.cmdNewZoneFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "File CSV|*.csv";
            // 
            // swVersion
            // 
            this.swVersion.FormattingEnabled = true;
            this.swVersion.Location = new System.Drawing.Point(522, 125);
            this.swVersion.Name = "swVersion";
            this.swVersion.Size = new System.Drawing.Size(117, 21);
            this.swVersion.TabIndex = 20;
            this.swVersion.SelectedIndexChanged += new System.EventHandler(this.swVersion_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 152);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(738, 27);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 21;
            // 
            // labelInfo_acc
            // 
            this.labelInfo_acc.AutoSize = true;
            this.labelInfo_acc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo_acc.Location = new System.Drawing.Point(12, 454);
            this.labelInfo_acc.Name = "labelInfo_acc";
            this.labelInfo_acc.Size = new System.Drawing.Size(0, 16);
            this.labelInfo_acc.TabIndex = 22;
            // 
            // openDocumentation
            // 
            this.openDocumentation.Location = new System.Drawing.Point(721, 121);
            this.openDocumentation.Name = "openDocumentation";
            this.openDocumentation.Size = new System.Drawing.Size(29, 25);
            this.openDocumentation.TabIndex = 23;
            this.openDocumentation.Text = "?";
            this.openDocumentation.UseVisualStyleBackColor = true;
            this.openDocumentation.Click += new System.EventHandler(this.openDocumentation_Click);
            // 
            // PrjSAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 481);
            this.Controls.Add(this.openDocumentation);
            this.Controls.Add(this.labelInfo_acc);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.swVersion);
            this.Controls.Add(this.cmdNewZoneFile);
            this.Controls.Add(this.findWWN);
            this.Controls.Add(this.customCMD);
            this.Controls.Add(this.aliShow);
            this.Controls.Add(this.zoneShow);
            this.Controls.Add(this.deleteZone);
            this.Controls.Add(this.newZoning);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SANcombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.configName);
            this.Controls.Add(this.hostName);
            this.Controls.Add(this.logBox);
            this.Name = "PrjSAN";
            this.Text = "PrjSAN";
            this.Load += new System.EventHandler(this.PrjSAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.TextBox hostName;
        private System.Windows.Forms.TextBox configName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SANcombo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button newZoning;
        private System.Windows.Forms.Button deleteZone;
        private System.Windows.Forms.Button zoneShow;
        private System.Windows.Forms.Button aliShow;
        private System.Windows.Forms.Button customCMD;
        private System.Windows.Forms.Button findWWN;
        private System.Windows.Forms.Button cmdNewZoneFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox swVersion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelInfo_acc;
        private System.Windows.Forms.Button openDocumentation;
    }
}

