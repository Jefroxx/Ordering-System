namespace FinalEDPOrderingSystem
{
    partial class CustomerMainForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(150, 59);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1134, 602);
            this.panelMain.TabIndex = 0;
            // 
            // flowLayoutCategories
            // 
            this.flowLayoutCategories.AutoScroll = true;
            this.flowLayoutCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutCategories.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutCategories.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutCategories.Name = "flowLayoutCategories";
            this.flowLayoutCategories.Size = new System.Drawing.Size(150, 661);
            this.flowLayoutCategories.TabIndex = 1;
            this.flowLayoutCategories.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLoggedUser);
            this.panel2.Controls.Add(this.BtnCart);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(150, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 59);
            this.panel2.TabIndex = 49;
            // 
            // BtnCart
            // 
            this.BtnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.BtnCart.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.Manage_Cart;
            this.BtnCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnCart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCart.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCart.ForeColor = System.Drawing.Color.White;
            this.BtnCart.Location = new System.Drawing.Point(914, 10);
            this.BtnCart.Name = "BtnCart";
            this.BtnCart.Size = new System.Drawing.Size(202, 37);
            this.BtnCart.TabIndex = 6;
            this.BtnCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCart.UseVisualStyleBackColor = false;
            this.BtnCart.Click += new System.EventHandler(this.BtnCart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.Search;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.SearchBar);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(473, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 42);
            this.panel1.TabIndex = 48;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.lblSearch.Image = global::FinalEDPOrderingSystem.Properties.Resources.Group_24;
            this.lblSearch.Location = new System.Drawing.Point(398, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(30, 25);
            this.lblSearch.TabIndex = 47;
            this.lblSearch.Text = "   ";
            // 
            // SearchBar
            // 
            this.SearchBar.BackColor = System.Drawing.Color.White;
            this.SearchBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBar.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(16)))), ((int)(((byte)(250)))));
            this.SearchBar.Location = new System.Drawing.Point(20, 11);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(372, 20);
            this.SearchBar.TabIndex = 46;
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoggedUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLoggedUser.Location = new System.Drawing.Point(17, 20);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(60, 20);
            this.lblLoggedUser.TabIndex = 49;
            this.lblLoggedUser.Text = "label1";
            // 
            // CustomerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutCategories);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerMainForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnCart;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCategories;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Label lblLoggedUser;
    }
}