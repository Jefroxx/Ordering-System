namespace FinalEDPOrderingSystem
{
    partial class CardPaymentControl
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
            this.TxtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.txtCVC = new System.Windows.Forms.TextBox();
            this.pickerExpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPayNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtCardNumber
            // 
            this.TxtCardNumber.BackColor = System.Drawing.Color.Ivory;
            this.TxtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCardNumber.ForeColor = System.Drawing.Color.Black;
            this.TxtCardNumber.Location = new System.Drawing.Point(126, 117);
            this.TxtCardNumber.Name = "TxtCardNumber";
            this.TxtCardNumber.Size = new System.Drawing.Size(416, 31);
            this.TxtCardNumber.TabIndex = 0;
            this.TxtCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCardNumber_KeyPress);
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BackColor = System.Drawing.Color.Ivory;
            this.txtCardHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardHolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardHolderName.ForeColor = System.Drawing.Color.Black;
            this.txtCardHolderName.Location = new System.Drawing.Point(126, 199);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(597, 31);
            this.txtCardHolderName.TabIndex = 1;
            this.txtCardHolderName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardHolderName_KeyPress);
            // 
            // txtCVC
            // 
            this.txtCVC.BackColor = System.Drawing.Color.Ivory;
            this.txtCVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVC.ForeColor = System.Drawing.Color.Black;
            this.txtCVC.Location = new System.Drawing.Point(573, 117);
            this.txtCVC.Name = "txtCVC";
            this.txtCVC.Size = new System.Drawing.Size(150, 31);
            this.txtCVC.TabIndex = 4;
            this.txtCVC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCVC_KeyPress);
            // 
            // pickerExpDate
            // 
            this.pickerExpDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerExpDate.CalendarForeColor = System.Drawing.Color.Black;
            this.pickerExpDate.CalendarMonthBackground = System.Drawing.Color.Ivory;
            this.pickerExpDate.CalendarTitleBackColor = System.Drawing.Color.Ivory;
            this.pickerExpDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pickerExpDate.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.pickerExpDate.CustomFormat = "MMMM dd, yyyy";
            this.pickerExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerExpDate.Location = new System.Drawing.Point(127, 289);
            this.pickerExpDate.MinDate = new System.DateTime(2025, 11, 5, 0, 0, 0, 0);
            this.pickerExpDate.Name = "pickerExpDate";
            this.pickerExpDate.Size = new System.Drawing.Size(597, 31);
            this.pickerExpDate.TabIndex = 5;
            this.pickerExpDate.ValueChanged += new System.EventHandler(this.pickerExpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(62)))));
            this.label2.Location = new System.Drawing.Point(122, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Card Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(569, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "CVC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(62)))));
            this.label3.Location = new System.Drawing.Point(122, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Card Holder Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(62)))));
            this.label4.Location = new System.Drawing.Point(123, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Expiration Date";
            // 
            // btnPayNow
            // 
            this.btnPayNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(97)))), ((int)(((byte)(172)))));
            this.btnPayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayNow.ForeColor = System.Drawing.Color.Ivory;
            this.btnPayNow.Location = new System.Drawing.Point(353, 355);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(189, 59);
            this.btnPayNow.TabIndex = 9;
            this.btnPayNow.Text = "Pay Now";
            this.btnPayNow.UseVisualStyleBackColor = false;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // CardPaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.btnPayNow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pickerExpDate);
            this.Controls.Add(this.txtCVC);
            this.Controls.Add(this.txtCardHolderName);
            this.Controls.Add(this.TxtCardNumber);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(53)))), ((int)(((byte)(62)))));
            this.Name = "CardPaymentControl";
            this.Size = new System.Drawing.Size(834, 483);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCardNumber;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.TextBox txtCVC;
        private System.Windows.Forms.DateTimePicker pickerExpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPayNow;
    }
}
