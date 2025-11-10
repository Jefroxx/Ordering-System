namespace FinalEDPOrderingSystem
{
    partial class CategoryPage
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
            this.flowLayoutProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutProducts
            // 
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutProducts.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutProducts.Name = "flowLayoutProducts";
            this.flowLayoutProducts.Size = new System.Drawing.Size(150, 617);
            this.flowLayoutProducts.TabIndex = 0;
            // 
            // CategoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutProducts);
            this.Name = "CategoryPage";
            this.Size = new System.Drawing.Size(150, 617);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutProducts;
    }
}
