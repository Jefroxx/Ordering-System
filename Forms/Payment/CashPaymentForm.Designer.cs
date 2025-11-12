namespace FinalEDPOrderingSystem
{
    partial class CashPaymentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrderNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnOrderAgain = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.lblOrderNum);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(253, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 404);
            this.panel1.TabIndex = 0;
            // 
            // lblOrderNum
            // 
            this.lblOrderNum.AutoSize = true;
            this.lblOrderNum.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderNum.Font = new System.Drawing.Font("Cambria", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(16)))), ((int)(((byte)(250)))));
            this.lblOrderNum.Location = new System.Drawing.Point(230, 137);
            this.lblOrderNum.Name = "lblOrderNum";
            this.lblOrderNum.Size = new System.Drawing.Size(332, 112);
            this.lblOrderNum.TabIndex = 5;
            this.lblOrderNum.Text = "10001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(174)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(175, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Please present this number at the counter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(231, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Your Order Number is ";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(662, 581);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(194, 52);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnOrderAgain
            // 
            this.btnOrderAgain.Location = new System.Drawing.Point(454, 581);
            this.btnOrderAgain.Name = "btnOrderAgain";
            this.btnOrderAgain.Size = new System.Drawing.Size(194, 52);
            this.btnOrderAgain.TabIndex = 1;
            this.btnOrderAgain.Text = "Order Again?";
            this.btnOrderAgain.UseVisualStyleBackColor = true;
            this.btnOrderAgain.Click += new System.EventHandler(this.btnOrderAgain_Click);
            // 
            // CashPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.btnOrderAgain);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashPaymentForm";
            this.Load += new System.EventHandler(this.CashPaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrderNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnOrderAgain;
    }
}