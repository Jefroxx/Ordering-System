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
            this.TxtCardNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.TxtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCardNumber.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.TxtCardNumber.Location = new System.Drawing.Point(172, 165);
            this.TxtCardNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCardNumber.Name = "TxtCardNumber";
            this.TxtCardNumber.Size = new System.Drawing.Size(554, 38);
            this.TxtCardNumber.TabIndex = 0;
            this.TxtCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCardNumber_KeyPress);
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtCardHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardHolderName.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardHolderName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.txtCardHolderName.Location = new System.Drawing.Point(172, 266);
            this.txtCardHolderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(795, 38);
            this.txtCardHolderName.TabIndex = 1;
            this.txtCardHolderName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardHolderName_KeyPress);
            // 
            // txtCVC
            // 
            this.txtCVC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.txtCVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVC.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.txtCVC.Location = new System.Drawing.Point(768, 165);
            this.txtCVC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCVC.Name = "txtCVC";
            this.txtCVC.Size = new System.Drawing.Size(199, 38);
            this.txtCVC.TabIndex = 4;
            this.txtCVC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCVC_KeyPress);
            // 
            // pickerExpDate
            // 
            this.pickerExpDate.CalendarFont = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerExpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.pickerExpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.pickerExpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.pickerExpDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.pickerExpDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.pickerExpDate.CustomFormat = "MMMM dd, yyyy";
            this.pickerExpDate.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerExpDate.Location = new System.Drawing.Point(173, 377);
            this.pickerExpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pickerExpDate.MinDate = new System.DateTime(2025, 11, 5, 0, 0, 0, 0);
            this.pickerExpDate.Name = "pickerExpDate";
            this.pickerExpDate.Size = new System.Drawing.Size(795, 38);
            this.pickerExpDate.TabIndex = 5;
            this.pickerExpDate.ValueChanged += new System.EventHandler(this.pickerExpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(167, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Card Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(763, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "CVC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label3.Location = new System.Drawing.Point(167, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Card Holder Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label4.Location = new System.Drawing.Point(168, 338);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Expiration Date";
            // 
            // btnPayNow
            // 
            this.btnPayNow.BackColor = System.Drawing.Color.Transparent;
            this.btnPayNow.BackgroundImage = global::FinalEDPOrderingSystem.Properties.Resources.Group_31;
            this.btnPayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayNow.ForeColor = System.Drawing.Color.Transparent;
            this.btnPayNow.Location = new System.Drawing.Point(441, 448);
            this.btnPayNow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(252, 73);
            this.btnPayNow.TabIndex = 9;
            this.btnPayNow.UseVisualStyleBackColor = false;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // CardPaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.btnPayNow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pickerExpDate);
            this.Controls.Add(this.txtCVC);
            this.Controls.Add(this.txtCardHolderName);
            this.Controls.Add(this.TxtCardNumber);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CardPaymentControl";
            this.Size = new System.Drawing.Size(1112, 594);
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
