namespace FinalEDPOrderingSystem
{
    partial class TransactionsPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LowInStockViewer = new System.Windows.Forms.DataGridView();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.LowInStockViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // LowInStockViewer
            // 
            this.LowInStockViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LowInStockViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.LowInStockViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LowInStockViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LowInStockViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LowInStockViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.LowInStockViewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            this.LowInStockViewer.Location = new System.Drawing.Point(13, 68);
            this.LowInStockViewer.Name = "LowInStockViewer";
            this.LowInStockViewer.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LowInStockViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.LowInStockViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.LowInStockViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LowInStockViewer.Size = new System.Drawing.Size(989, 491);
            this.LowInStockViewer.TabIndex = 50;
            // 
            // filterComboBox
            // 
            this.filterComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(13, 20);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(237, 33);
            this.filterComboBox.TabIndex = 51;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // TransactionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.LowInStockViewer);
            this.Name = "TransactionsPage";
            this.Size = new System.Drawing.Size(1014, 575);
            ((System.ComponentModel.ISupportInitialize)(this.LowInStockViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView LowInStockViewer;
        private System.Windows.Forms.ComboBox filterComboBox;
    }
}
