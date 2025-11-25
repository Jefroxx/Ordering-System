namespace FinalEDPOrderingSystem
{
    partial class CartProductCard
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
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.MinusQuantity = new System.Windows.Forms.Label();
            this.addQuantity = new System.Windows.Forms.Label();
            this.removeQuantity = new System.Windows.Forms.Label();
            this.Productimage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Productimage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(250, 59);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(166, 20);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Review Shopping Cart";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(604, 59);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(166, 20);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Review Shopping Cart";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Ivory;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(954, 57);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(52, 26);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinusQuantity
            // 
            this.MinusQuantity.BackColor = System.Drawing.Color.Transparent;
            this.MinusQuantity.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinusQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(16)))), ((int)(((byte)(250)))));
            this.MinusQuantity.Image = global::FinalEDPOrderingSystem.Properties.Resources.lsicon_minus_filled;
            this.MinusQuantity.Location = new System.Drawing.Point(919, 56);
            this.MinusQuantity.Name = "MinusQuantity";
            this.MinusQuantity.Size = new System.Drawing.Size(30, 27);
            this.MinusQuantity.TabIndex = 5;
            this.MinusQuantity.Text = "    ";
            this.MinusQuantity.Click += new System.EventHandler(this.MinusQuantity_Click);
            // 
            // addQuantity
            // 
            this.addQuantity.BackColor = System.Drawing.Color.Transparent;
            this.addQuantity.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(16)))), ((int)(((byte)(250)))));
            this.addQuantity.Image = global::FinalEDPOrderingSystem.Properties.Resources.gridicons_add1;
            this.addQuantity.Location = new System.Drawing.Point(1009, 57);
            this.addQuantity.Name = "addQuantity";
            this.addQuantity.Size = new System.Drawing.Size(33, 27);
            this.addQuantity.TabIndex = 5;
            this.addQuantity.Text = "   ";
            this.addQuantity.Click += new System.EventHandler(this.addQuantity_Click);
            // 
            // removeQuantity
            // 
            this.removeQuantity.BackColor = System.Drawing.Color.Transparent;
            this.removeQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeQuantity.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeQuantity.ForeColor = System.Drawing.Color.White;
            this.removeQuantity.Image = global::FinalEDPOrderingSystem.Properties.Resources.mdi_remove_bold;
            this.removeQuantity.Location = new System.Drawing.Point(1142, 57);
            this.removeQuantity.Name = "removeQuantity";
            this.removeQuantity.Size = new System.Drawing.Size(31, 30);
            this.removeQuantity.TabIndex = 5;
            this.removeQuantity.Text = "    ";
            this.removeQuantity.Click += new System.EventHandler(this.removeQuantity_Click);
            // 
            // Productimage
            // 
            this.Productimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Productimage.Location = new System.Drawing.Point(60, 20);
            this.Productimage.Name = "Productimage";
            this.Productimage.Size = new System.Drawing.Size(114, 97);
            this.Productimage.TabIndex = 0;
            this.Productimage.TabStop = false;
            // 
            // CartProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.MinusQuantity);
            this.Controls.Add(this.addQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.removeQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.Productimage);
            this.Name = "CartProductCard";
            this.Size = new System.Drawing.Size(1212, 140);
            ((System.ComponentModel.ISupportInitialize)(this.Productimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Productimage;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label removeQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label addQuantity;
        private System.Windows.Forms.Label MinusQuantity;
    }
}
