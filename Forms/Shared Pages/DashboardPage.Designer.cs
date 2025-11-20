namespace FinalEDPOrderingSystem
{
    partial class DashboardPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.soldCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BestSellingProductsViewer = new System.Windows.Forms.DataGridView();
            this.LowInStockViewer = new System.Windows.Forms.DataGridView();
            this.recentTransactionsViewer = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.earningsCounter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BestSellingProductsViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowInStockViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentTransactionsViewer)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.soldCounter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 125);
            this.panel1.TabIndex = 0;
            // 
            // soldCounter
            // 
            this.soldCounter.AutoSize = true;
            this.soldCounter.BackColor = System.Drawing.Color.Transparent;
            this.soldCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldCounter.ForeColor = System.Drawing.Color.MediumOrchid;
            this.soldCounter.Location = new System.Drawing.Point(3, 0);
            this.soldCounter.Name = "soldCounter";
            this.soldCounter.Size = new System.Drawing.Size(98, 108);
            this.soldCounter.TabIndex = 0;
            this.soldCounter.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(318, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products Sold";
            // 
            // BestSellingProductsViewer
            // 
            this.BestSellingProductsViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BestSellingProductsViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.BestSellingProductsViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle61.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BestSellingProductsViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.BestSellingProductsViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Dubai Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(138)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BestSellingProductsViewer.DefaultCellStyle = dataGridViewCellStyle62;
            this.BestSellingProductsViewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.BestSellingProductsViewer.Location = new System.Drawing.Point(13, 187);
            this.BestSellingProductsViewer.Name = "BestSellingProductsViewer";
            this.BestSellingProductsViewer.ReadOnly = true;
            dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle63.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle63.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle63.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle63.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle63.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BestSellingProductsViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle63;
            this.BestSellingProductsViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle64.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle64.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle64.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle64.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.BestSellingProductsViewer.RowsDefaultCellStyle = dataGridViewCellStyle64;
            this.BestSellingProductsViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BestSellingProductsViewer.Size = new System.Drawing.Size(484, 171);
            this.BestSellingProductsViewer.TabIndex = 33;
            // 
            // LowInStockViewer
            // 
            this.LowInStockViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LowInStockViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.LowInStockViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle65.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle65.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LowInStockViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle65;
            this.LowInStockViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle66.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle66.Font = new System.Drawing.Font("Dubai Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle66.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(138)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle66.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LowInStockViewer.DefaultCellStyle = dataGridViewCellStyle66;
            this.LowInStockViewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.LowInStockViewer.Location = new System.Drawing.Point(517, 187);
            this.LowInStockViewer.Name = "LowInStockViewer";
            this.LowInStockViewer.ReadOnly = true;
            dataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle67.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle67.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LowInStockViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle67;
            this.LowInStockViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle68.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle68.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.LowInStockViewer.RowsDefaultCellStyle = dataGridViewCellStyle68;
            this.LowInStockViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LowInStockViewer.Size = new System.Drawing.Size(484, 171);
            this.LowInStockViewer.TabIndex = 33;
            // 
            // recentTransactionsViewer
            // 
            this.recentTransactionsViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recentTransactionsViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.recentTransactionsViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle69.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle69.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle69.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle69.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recentTransactionsViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle69;
            this.recentTransactionsViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle70.Font = new System.Drawing.Font("Dubai Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle70.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(138)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle70.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recentTransactionsViewer.DefaultCellStyle = dataGridViewCellStyle70;
            this.recentTransactionsViewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.recentTransactionsViewer.Location = new System.Drawing.Point(13, 396);
            this.recentTransactionsViewer.Name = "recentTransactionsViewer";
            this.recentTransactionsViewer.ReadOnly = true;
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle71.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recentTransactionsViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle71;
            this.recentTransactionsViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle72.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle72.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.recentTransactionsViewer.RowsDefaultCellStyle = dataGridViewCellStyle72;
            this.recentTransactionsViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recentTransactionsViewer.Size = new System.Drawing.Size(988, 171);
            this.recentTransactionsViewer.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(9, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Best Selling Products";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label4.Location = new System.Drawing.Point(515, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Items Low in Stock";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.label5.Location = new System.Drawing.Point(10, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Recent Transactions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label3.Location = new System.Drawing.Point(308, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Earnings";
            // 
            // earningsCounter
            // 
            this.earningsCounter.AutoSize = true;
            this.earningsCounter.BackColor = System.Drawing.Color.Transparent;
            this.earningsCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earningsCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.earningsCounter.Location = new System.Drawing.Point(3, 8);
            this.earningsCounter.Name = "earningsCounter";
            this.earningsCounter.Size = new System.Drawing.Size(57, 63);
            this.earningsCounter.TabIndex = 0;
            this.earningsCounter.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(88)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.earningsCounter);
            this.panel2.Location = new System.Drawing.Point(517, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 125);
            this.panel2.TabIndex = 0;
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.Controls.Add(this.recentTransactionsViewer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LowInStockViewer);
            this.Controls.Add(this.BestSellingProductsViewer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DashboardPage";
            this.Size = new System.Drawing.Size(1014, 574);
            this.Load += new System.EventHandler(this.DashboardPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BestSellingProductsViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowInStockViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentTransactionsViewer)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label soldCounter;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView BestSellingProductsViewer;
        public System.Windows.Forms.DataGridView LowInStockViewer;
        public System.Windows.Forms.DataGridView recentTransactionsViewer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label earningsCounter;
        private System.Windows.Forms.Panel panel2;
    }
}
