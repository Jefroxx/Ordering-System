namespace FinalEDPOrderingSystem
{
    partial class LoginPage
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
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.TxtPassword.Location = new System.Drawing.Point(160, 348);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(469, 38);
            this.TxtPassword.TabIndex = 38;
            // 
            // TxtUsername
            // 
            this.TxtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.TxtUsername.Location = new System.Drawing.Point(160, 262);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(469, 38);
            this.TxtUsername.TabIndex = 37;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(310, 412);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(190, 48);
            this.btnLogin.TabIndex = 36;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.btnClose.Image = global::FinalEDPOrderingSystem.Properties.Resources.BTN_Cancel;
            this.btnClose.Location = new System.Drawing.Point(734, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 42);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "  ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label3.Location = new System.Drawing.Point(157, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label1.Image = global::FinalEDPOrderingSystem.Properties.Resources.Password_;
            this.label1.Location = new System.Drawing.Point(154, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 44);
            this.label1.TabIndex = 41;
            this.label1.Text = "            ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label2.Image = global::FinalEDPOrderingSystem.Properties.Resources.Username_;
            this.label2.Location = new System.Drawing.Point(157, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 44);
            this.label2.TabIndex = 42;
            this.label2.Text = "            ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(174)))), ((int)(((byte)(220)))));
            this.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.BG_Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(788, 574);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}