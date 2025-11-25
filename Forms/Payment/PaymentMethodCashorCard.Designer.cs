namespace FinalEDPOrderingSystem
{
    partial class PaymentMethodCashorCard
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
            this.btnBack = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCashless = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Info;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 101);
            this.panel1.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.btnBack.Image = global::FinalEDPOrderingSystem.Properties.Resources.BTn_Back;
            this.btnBack.Location = new System.Drawing.Point(19, 38);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(22, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "  ";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(505, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose Payment Method";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label3.Location = new System.Drawing.Point(47, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Review Cart";
            // 
            // btnCashless
            // 
            this.btnCashless.BackColor = System.Drawing.Color.White;
            this.btnCashless.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCashless.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashless.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashless.ForeColor = System.Drawing.Color.Transparent;
            this.btnCashless.Image = global::FinalEDPOrderingSystem.Properties.Resources.Cashless123123;
            this.btnCashless.Location = new System.Drawing.Point(749, 217);
            this.btnCashless.Name = "btnCashless";
            this.btnCashless.Size = new System.Drawing.Size(374, 351);
            this.btnCashless.TabIndex = 2;
            this.btnCashless.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCashless.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCashless.UseVisualStyleBackColor = false;
            this.btnCashless.Click += new System.EventHandler(this.btnCashless_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.White;
            this.btnCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.Color.Transparent;
            this.btnCash.Image = global::FinalEDPOrderingSystem.Properties.Resources.cash__1_;
            this.btnCash.Location = new System.Drawing.Point(197, 217);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(333, 351);
            this.btnCash.TabIndex = 2;
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // PaymentMethodCashorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.CASHLESS__1_;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.btnCashless);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentMethodCashorCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentMethodCashorCard";
            this.Load += new System.EventHandler(this.PaymentMethodCashorCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCashless;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnBack;
        private System.Windows.Forms.Label label3;
    }
}