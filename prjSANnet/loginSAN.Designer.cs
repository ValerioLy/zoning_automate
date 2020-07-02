namespace prjSANnet
{
    partial class loginSAN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginSAN));
            this.userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.loginToSAN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selAmbiente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(101, 92);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(156, 20);
            this.userName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(101, 121);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(156, 20);
            this.password.TabIndex = 1;
            // 
            // loginToSAN
            // 
            this.loginToSAN.Location = new System.Drawing.Point(41, 177);
            this.loginToSAN.Name = "loginToSAN";
            this.loginToSAN.Size = new System.Drawing.Size(215, 24);
            this.loginToSAN.TabIndex = 3;
            this.loginToSAN.Text = "Login";
            this.loginToSAN.UseVisualStyleBackColor = true;
            this.loginToSAN.Click += new System.EventHandler(this.loginToSAN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // selAmbiente
            // 
            this.selAmbiente.FormattingEnabled = true;
            this.selAmbiente.Location = new System.Drawing.Point(101, 150);
            this.selAmbiente.Name = "selAmbiente";
            this.selAmbiente.Size = new System.Drawing.Size(155, 21);
            this.selAmbiente.TabIndex = 2;
            this.selAmbiente.SelectedIndexChanged += new System.EventHandler(this.selAmbiente_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SAN Env";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // loginSAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 214);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selAmbiente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginToSAN);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.Name = "loginSAN";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.loginSAN_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.loginSAN_FormClosed);
            this.Load += new System.EventHandler(this.loginSAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox password;
        private System.Windows.Forms.Button loginToSAN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selAmbiente;
        private System.Windows.Forms.Label label3;
    }
}