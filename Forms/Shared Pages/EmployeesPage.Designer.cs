namespace FinalEDPOrderingSystem
{
    partial class EmployeesPage
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
            this.EmployeesViewer = new System.Windows.Forms.DataGridView();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.btnEditEmployees = new System.Windows.Forms.Button();
            this.btnAddEmployees = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeesViewer
            // 
            this.EmployeesViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeesViewer.BackgroundColor = System.Drawing.Color.Ivory;
            this.EmployeesViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeesViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeesViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(223)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmployeesViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeesViewer.GridColor = System.Drawing.Color.Black;
            this.EmployeesViewer.Location = new System.Drawing.Point(13, 68);
            this.EmployeesViewer.Name = "EmployeesViewer";
            this.EmployeesViewer.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeesViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeesViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.EmployeesViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeesViewer.Size = new System.Drawing.Size(989, 491);
            this.EmployeesViewer.TabIndex = 46;
            this.EmployeesViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeesViewer_CellContentClick);
            this.EmployeesViewer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.EmployeesViewer_DataBindingComplete);
            // 
            // filterComboBox
            // 
            this.filterComboBox.BackColor = System.Drawing.Color.Ivory;
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterComboBox.ForeColor = System.Drawing.Color.Black;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(13, 19);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(187, 33);
            this.filterComboBox.TabIndex = 47;
            // 
            // btnEditEmployees
            // 
            this.btnEditEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(97)))), ((int)(((byte)(172)))));
            this.btnEditEmployees.Image = global::FinalEDPOrderingSystem.Properties.Resources.mdi_edit;
            this.btnEditEmployees.Location = new System.Drawing.Point(827, 15);
            this.btnEditEmployees.Name = "btnEditEmployees";
            this.btnEditEmployees.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnEditEmployees.Size = new System.Drawing.Size(86, 37);
            this.btnEditEmployees.TabIndex = 44;
            this.btnEditEmployees.Text = "Edit";
            this.btnEditEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditEmployees.UseVisualStyleBackColor = false;
            this.btnEditEmployees.Click += new System.EventHandler(this.btnEditEmployees_Click);
            // 
            // btnAddEmployees
            // 
            this.btnAddEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            this.btnAddEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployees.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddEmployees.Image = global::FinalEDPOrderingSystem.Properties.Resources.mingcute_add_fill;
            this.btnAddEmployees.Location = new System.Drawing.Point(919, 15);
            this.btnAddEmployees.Name = "btnAddEmployees";
            this.btnAddEmployees.Size = new System.Drawing.Size(83, 37);
            this.btnAddEmployees.TabIndex = 45;
            this.btnAddEmployees.Text = "Add";
            this.btnAddEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddEmployees.UseVisualStyleBackColor = false;
            this.btnAddEmployees.Click += new System.EventHandler(this.btnAddEmployees_Click);
            // 
            // EmployeesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.EmployeesViewer);
            this.Controls.Add(this.btnEditEmployees);
            this.Controls.Add(this.btnAddEmployees);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EmployeesPage";
            this.Size = new System.Drawing.Size(1014, 575);
            this.Load += new System.EventHandler(this.EmployeesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView EmployeesViewer;
        private System.Windows.Forms.Button btnEditEmployees;
        private System.Windows.Forms.Button btnAddEmployees;
        private System.Windows.Forms.ComboBox filterComboBox;
    }
}
