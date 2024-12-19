namespace Hebrews_Coffee
{
    partial class catArchive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.productTableAdapter2 = new Hebrews_Coffee.HebrewsDataSet24TableAdapters.ProductTableAdapter();
            this.hebrewsDataSet24 = new Hebrews_Coffee.HebrewsDataSet24();
            this.productTableAdapter1 = new Hebrews_Coffee.HebrewsDataSet23TableAdapters.ProductTableAdapter();
            this.btnclose = new Guna.UI2.WinForms.Guna2Button();
            this.btnarchive = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.productTableAdapter = new Hebrews_Coffee.HebrewsDataSet22TableAdapters.ProductTableAdapter();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hebrewsDataSet22 = new Hebrews_Coffee.HebrewsDataSet22();
            this.productBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hebrewsDataSet23 = new Hebrews_Coffee.HebrewsDataSet23();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvarchive = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDeleteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hebrewsDataSet27 = new Hebrews_Coffee.HebrewsDataSet27();
            this.hebrewsDataSet25 = new Hebrews_Coffee.HebrewsDataSet25();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new Hebrews_Coffee.HebrewsDataSet25TableAdapters.CategoryTableAdapter();
            this.hebrewsDataSet26 = new Hebrews_Coffee.HebrewsDataSet26();
            this.categoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter1 = new Hebrews_Coffee.HebrewsDataSet26TableAdapters.CategoryTableAdapter();
            this.categoryTableAdapter2 = new Hebrews_Coffee.HebrewsDataSet27TableAdapters.CategoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvarchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // productTableAdapter2
            // 
            this.productTableAdapter2.ClearBeforeFill = true;
            // 
            // hebrewsDataSet24
            // 
            this.hebrewsDataSet24.DataSetName = "HebrewsDataSet24";
            this.hebrewsDataSet24.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnclose.AutoRoundedCorners = true;
            this.btnclose.BorderRadius = 21;
            this.btnclose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnclose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnclose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnclose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnclose.FillColor = System.Drawing.Color.White;
            this.btnclose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.Black;
            this.btnclose.Location = new System.Drawing.Point(827, 512);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(180, 45);
            this.btnclose.TabIndex = 18;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnarchive
            // 
            this.btnarchive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnarchive.AutoRoundedCorners = true;
            this.btnarchive.BorderRadius = 21;
            this.btnarchive.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnarchive.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnarchive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnarchive.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnarchive.FillColor = System.Drawing.Color.White;
            this.btnarchive.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnarchive.ForeColor = System.Drawing.Color.Black;
            this.btnarchive.Location = new System.Drawing.Point(641, 512);
            this.btnarchive.Name = "btnarchive";
            this.btnarchive.Size = new System.Drawing.Size(180, 45);
            this.btnarchive.TabIndex = 17;
            this.btnarchive.Text = "Restore";
            this.btnarchive.Click += new System.EventHandler(this.btnarchive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARCHIVE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.hebrewsDataSet22;
            // 
            // hebrewsDataSet22
            // 
            this.hebrewsDataSet22.DataSetName = "HebrewsDataSet22";
            this.hebrewsDataSet22.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource2
            // 
            this.productBindingSource2.DataMember = "Product";
            this.productBindingSource2.DataSource = this.hebrewsDataSet24;
            // 
            // hebrewsDataSet23
            // 
            this.hebrewsDataSet23.DataSetName = "HebrewsDataSet23";
            this.hebrewsDataSet23.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "Product";
            this.productBindingSource1.DataSource = this.hebrewsDataSet23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 58);
            this.panel1.TabIndex = 16;
            // 
            // dgvarchive
            // 
            this.dgvarchive.AllowUserToAddRows = false;
            this.dgvarchive.AllowUserToDeleteRows = false;
            this.dgvarchive.AllowUserToResizeColumns = false;
            this.dgvarchive.AllowUserToResizeRows = false;
            this.dgvarchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvarchive.AutoGenerateColumns = false;
            this.dgvarchive.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvarchive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvarchive.ColumnHeadersHeight = 40;
            this.dgvarchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvarchive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nameDataGridViewTextBoxColumn,
            this.isDeleteDataGridViewTextBoxColumn});
            this.dgvarchive.DataSource = this.categoryBindingSource2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvarchive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvarchive.GridColor = System.Drawing.Color.White;
            this.dgvarchive.Location = new System.Drawing.Point(13, 78);
            this.dgvarchive.Name = "dgvarchive";
            this.dgvarchive.ReadOnly = true;
            this.dgvarchive.RowHeadersVisible = false;
            this.dgvarchive.RowHeadersWidth = 51;
            this.dgvarchive.RowTemplate.Height = 24;
            this.dgvarchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvarchive.Size = new System.Drawing.Size(993, 413);
            this.dgvarchive.TabIndex = 19;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 75;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isDeleteDataGridViewTextBoxColumn
            // 
            this.isDeleteDataGridViewTextBoxColumn.DataPropertyName = "IsDelete";
            this.isDeleteDataGridViewTextBoxColumn.HeaderText = "IsDelete";
            this.isDeleteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.isDeleteDataGridViewTextBoxColumn.Name = "isDeleteDataGridViewTextBoxColumn";
            this.isDeleteDataGridViewTextBoxColumn.ReadOnly = true;
            this.isDeleteDataGridViewTextBoxColumn.Visible = false;
            this.isDeleteDataGridViewTextBoxColumn.Width = 125;
            // 
            // categoryBindingSource2
            // 
            this.categoryBindingSource2.DataMember = "Category";
            this.categoryBindingSource2.DataSource = this.hebrewsDataSet27;
            // 
            // hebrewsDataSet27
            // 
            this.hebrewsDataSet27.DataSetName = "HebrewsDataSet27";
            this.hebrewsDataSet27.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hebrewsDataSet25
            // 
            this.hebrewsDataSet25.DataSetName = "HebrewsDataSet25";
            this.hebrewsDataSet25.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.hebrewsDataSet25;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // hebrewsDataSet26
            // 
            this.hebrewsDataSet26.DataSetName = "HebrewsDataSet26";
            this.hebrewsDataSet26.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource1
            // 
            this.categoryBindingSource1.DataMember = "Category";
            this.categoryBindingSource1.DataSource = this.hebrewsDataSet26;
            // 
            // categoryTableAdapter1
            // 
            this.categoryTableAdapter1.ClearBeforeFill = true;
            // 
            // categoryTableAdapter2
            // 
            this.categoryTableAdapter2.ClearBeforeFill = true;
            // 
            // catArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1019, 569);
            this.Controls.Add(this.dgvarchive);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnarchive);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "catArchive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "catArchive";
            this.Load += new System.EventHandler(this.catArchive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvarchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hebrewsDataSet26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HebrewsDataSet24TableAdapters.ProductTableAdapter productTableAdapter2;
        private HebrewsDataSet24 hebrewsDataSet24;
        private HebrewsDataSet23TableAdapters.ProductTableAdapter productTableAdapter1;
        private Guna.UI2.WinForms.Guna2Button btnclose;
        private Guna.UI2.WinForms.Guna2Button btnarchive;
        private System.Windows.Forms.Label label1;
        private HebrewsDataSet22TableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource;
        private HebrewsDataSet22 hebrewsDataSet22;
        private System.Windows.Forms.BindingSource productBindingSource2;
        private HebrewsDataSet23 hebrewsDataSet23;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvarchive;
        private HebrewsDataSet25 hebrewsDataSet25;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private HebrewsDataSet25TableAdapters.CategoryTableAdapter categoryTableAdapter;
        private HebrewsDataSet26 hebrewsDataSet26;
        private System.Windows.Forms.BindingSource categoryBindingSource1;
        private HebrewsDataSet26TableAdapters.CategoryTableAdapter categoryTableAdapter1;
        private HebrewsDataSet27 hebrewsDataSet27;
        private System.Windows.Forms.BindingSource categoryBindingSource2;
        private HebrewsDataSet27TableAdapters.CategoryTableAdapter categoryTableAdapter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDeleteDataGridViewTextBoxColumn;
    }
}