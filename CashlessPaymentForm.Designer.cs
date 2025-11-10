namespace FinalEDPOrderingSystem
{
    partial class CashlessPaymentForm
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
            this.components = new System.ComponentModel.Container();
            this.panelPaymentArea = new System.Windows.Forms.Panel();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnQR = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelPaymentArea
            // 
            this.panelPaymentArea.BackColor = System.Drawing.Color.Snow;
            this.panelPaymentArea.Location = new System.Drawing.Point(233, 136);
            this.panelPaymentArea.Name = "panelPaymentArea";
            this.panelPaymentArea.Size = new System.Drawing.Size(834, 483);
            this.panelPaymentArea.TabIndex = 0;
            // 
            // btnCard
            // 
            this.btnCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.Location = new System.Drawing.Point(669, 57);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(398, 65);
            this.btnCard.TabIndex = 3;
            this.btnCard.Text = "PAY WITH CARD";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnQR
            // 
            this.btnQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQR.Location = new System.Drawing.Point(233, 57);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(398, 65);
            this.btnQR.TabIndex = 2;
            this.btnQR.Text = "SCAN QR";
            this.btnQR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnQR.UseVisualStyleBackColor = true;
            this.btnQR.Click += new System.EventHandler(this.btnQR_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CashlessPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnQR);
            this.Controls.Add(this.panelPaymentArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashlessPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashlessPaymentForm";
            this.Load += new System.EventHandler(this.CashlessPaymentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPaymentArea;
        private System.Windows.Forms.Button btnQR;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Timer timer1;
    }
}