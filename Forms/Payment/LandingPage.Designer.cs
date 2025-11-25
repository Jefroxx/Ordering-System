namespace FinalEDPOrderingSystem
{
    partial class LandingPage
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
            this.BtnCustomer = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCustomer
            // 
            this.BtnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(97)))), ((int)(((byte)(172)))));
            this.BtnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomer.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomer.ForeColor = System.Drawing.Color.Ivory;
            this.BtnCustomer.Location = new System.Drawing.Point(485, 479);
            this.BtnCustomer.Name = "BtnCustomer";
            this.BtnCustomer.Size = new System.Drawing.Size(318, 57);
            this.BtnCustomer.TabIndex = 2;
            this.BtnCustomer.Text = "Click To Order";
            this.BtnCustomer.UseVisualStyleBackColor = false;
            this.BtnCustomer.Click += new System.EventHandler(this.BtnCustomer_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.AutoSize = true;
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.btnAdmin.Image = global::FinalEDPOrderingSystem.Properties.Resources.BTN_admin;
            this.btnAdmin.Location = new System.Drawing.Point(1232, 600);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(40, 42);
            this.btnAdmin.TabIndex = 40;
            this.btnAdmin.Text = "  ";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.btnClose.Image = global::FinalEDPOrderingSystem.Properties.Resources.BTN_Cancel;
            this.btnClose.Location = new System.Drawing.Point(1232, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 42);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "  ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(51)))), ((int)(((byte)(238)))));
            this.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.BGF_LandingPage1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.BtnCustomer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCustomer;
        private System.Windows.Forms.Label btnAdmin;
        private System.Windows.Forms.Label btnClose;
    }
}

