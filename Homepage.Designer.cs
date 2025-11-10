namespace FinalEDPOrderingSystem
{
    partial class Homepage
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
            this.flowLayoutBestSellers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutBestSellers
            // 
            this.flowLayoutBestSellers.AutoScroll = true;
            this.flowLayoutBestSellers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutBestSellers.Location = new System.Drawing.Point(0, 157);
            this.flowLayoutBestSellers.Name = "flowLayoutBestSellers";
            this.flowLayoutBestSellers.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutBestSellers.Size = new System.Drawing.Size(1109, 435);
            this.flowLayoutBestSellers.TabIndex = 0;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.lblProductPrice.Location = new System.Drawing.Point(2, 124);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(140, 28);
            this.lblProductPrice.TabIndex = 2;
            this.lblProductPrice.Text = "Best Sellers";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.Rectangle_921;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1106, 116);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutBestSellers);
            this.Name = "Homepage";
            this.Size = new System.Drawing.Size(1109, 592);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutBestSellers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProductPrice;
    }
}
