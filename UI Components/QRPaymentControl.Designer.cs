namespace FinalEDPOrderingSystem
{
    partial class QRPaymentControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.QR = new System.Windows.Forms.PictureBox();
            this.txtQRInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.QR)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label3.Location = new System.Drawing.Point(248, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Place QR inside the frame to scan\r\n";
            // 
            // QR
            // 
            this.QR.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources._5eddb68e_d751_42a9_9154_a856d52e215b;
            this.QR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.QR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QR.Location = new System.Drawing.Point(230, 60);
            this.QR.Name = "QR";
            this.QR.Size = new System.Drawing.Size(378, 382);
            this.QR.TabIndex = 0;
            this.QR.TabStop = false;
            // 
            // txtQRInput
            // 
            this.txtQRInput.Location = new System.Drawing.Point(370, 448);
            this.txtQRInput.Name = "txtQRInput";
            this.txtQRInput.Size = new System.Drawing.Size(100, 20);
            this.txtQRInput.TabIndex = 7;
            this.txtQRInput.TabStop = false;
            this.txtQRInput.Visible = false;
            // 
            // QRPaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.Controls.Add(this.txtQRInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QR);
            this.Name = "QRPaymentControl";
            this.Size = new System.Drawing.Size(834, 483);
            ((System.ComponentModel.ISupportInitialize)(this.QR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQRInput;
    }
}
