namespace FinalEDPOrderingSystem
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.lblProductName.Location = new System.Drawing.Point(4, 239);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(251, 62);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "label1";
            this.lblProductName.UseCompatibleTextRendering = true;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(130)))), ((int)(((byte)(148)))));
            this.lblProductPrice.Location = new System.Drawing.Point(4, 289);
            this.lblProductPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(118, 40);
            this.lblProductPrice.TabIndex = 1;
            this.lblProductPrice.Text = "label1";
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxProduct.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(259, 201);
            this.pictureBoxProduct.TabIndex = 0;
            this.pictureBoxProduct.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(174)))), ((int)(((byte)(220)))));
            this.lblCategory.Location = new System.Drawing.Point(4, 214);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(56, 21);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "label1";
            this.lblCategory.Visible = false;
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pictureBoxProduct);
            this.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(259, 345);
            this.Load += new System.EventHandler(this.ProductCard_Load);
            this.Click += new System.EventHandler(this.ProductCard_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblCategory;
    }
}
