namespace Arrbora.UI
{
    partial class frmProductsOverview
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
            this.dataGridViewProductOverview = new System.Windows.Forms.DataGridView();
            this.productOverviewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.addProductOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProductOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtmDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtmDateTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPriceRange = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailedReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBxSearchButtons = new System.Windows.Forms.GroupBox();
            this.flwLytPnlToggleControls = new System.Windows.Forms.FlowLayoutPanel();
            this.chkbxSearch = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOverview)).BeginInit();
            this.productOverviewContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpBxSearchButtons.SuspendLayout();
            this.flwLytPnlToggleControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProductOverview
            // 
            this.dataGridViewProductOverview.AllowUserToAddRows = false;
            this.dataGridViewProductOverview.AllowUserToDeleteRows = false;
            this.dataGridViewProductOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductOverview.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewProductOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductOverview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProductOverview.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewProductOverview.MultiSelect = false;
            this.dataGridViewProductOverview.Name = "dataGridViewProductOverview";
            this.dataGridViewProductOverview.ReadOnly = true;
            this.dataGridViewProductOverview.RowTemplate.ContextMenuStrip = this.productOverviewContextMenuStrip;
            this.dataGridViewProductOverview.Size = new System.Drawing.Size(951, 325);
            this.dataGridViewProductOverview.TabIndex = 0;
            this.dataGridViewProductOverview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductOverview_CellDoubleClick);
            // 
            // productOverviewContextMenuStrip
            // 
            this.productOverviewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripSeparator,
            this.addProductOverviewToolStripMenuItem,
            this.editProductOverviewToolStripMenuItem,
            this.deleteProductOverviewToolStripMenuItem});
            this.productOverviewContextMenuStrip.Name = "productOverviewContextMenuStrip";
            this.productOverviewContextMenuStrip.Size = new System.Drawing.Size(171, 101);
            this.productOverviewContextMenuStrip.Text = "Product Overview";
            this.productOverviewContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.productOverviewContextMenuStrip_ItemClicked);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(110, 23);
            this.toolStripTextBox1.Text = "Product Overview";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(167, 6);
            // 
            // addProductOverviewToolStripMenuItem
            // 
            this.addProductOverviewToolStripMenuItem.Name = "addProductOverviewToolStripMenuItem";
            this.addProductOverviewToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addProductOverviewToolStripMenuItem.Text = "Add...";
            this.addProductOverviewToolStripMenuItem.Click += new System.EventHandler(this.addProductOverviewToolStripMenuItem_Click);
            // 
            // editProductOverviewToolStripMenuItem
            // 
            this.editProductOverviewToolStripMenuItem.Name = "editProductOverviewToolStripMenuItem";
            this.editProductOverviewToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.editProductOverviewToolStripMenuItem.Text = "Edit...";
            // 
            // deleteProductOverviewToolStripMenuItem
            // 
            this.deleteProductOverviewToolStripMenuItem.Name = "deleteProductOverviewToolStripMenuItem";
            this.deleteProductOverviewToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteProductOverviewToolStripMenuItem.Text = "Delete... ";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(14, 291);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Brand";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // txtSearchString
            // 
            this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchString.Location = new System.Drawing.Point(14, 33);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(183, 20);
            this.txtSearchString.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1018, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Reference nr.";
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(14, 136);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(183, 21);
            this.cmbModel.TabIndex = 4;
            // 
            // cmbBrand
            // 
            this.cmbBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(14, 84);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(183, 21);
            this.cmbBrand.TabIndex = 4;
            this.cmbBrand.SelectedValueChanged += new System.EventHandler(this.cmbBrand_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "To";
            // 
            // dtmDateFrom
            // 
            this.dtmDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateFrom.Location = new System.Drawing.Point(14, 188);
            this.dtmDateFrom.Name = "dtmDateFrom";
            this.dtmDateFrom.Size = new System.Drawing.Size(80, 20);
            this.dtmDateFrom.TabIndex = 5;
            // 
            // dtmDateTo
            // 
            this.dtmDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDateTo.Location = new System.Drawing.Point(111, 188);
            this.dtmDateTo.Name = "dtmDateTo";
            this.dtmDateTo.Size = new System.Drawing.Size(86, 20);
            this.dtmDateTo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Price range";
            // 
            // cmbPriceRange
            // 
            this.cmbPriceRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriceRange.FormattingEnabled = true;
            this.cmbPriceRange.Location = new System.Drawing.Point(14, 239);
            this.cmbPriceRange.Name = "cmbPriceRange";
            this.cmbPriceRange.Size = new System.Drawing.Size(183, 21);
            this.cmbPriceRange.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDatabaseToolStripMenuItem,
            this.importFromDatabaseToolStripMenuItem,
            this.saveToExcelToolStripMenuItem,
            this.importFromExcelToolStripMenuItem,
            this.exportToExcelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            this.saveDatabaseToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveDatabaseToolStripMenuItem.Text = "Save Database";
            // 
            // importFromDatabaseToolStripMenuItem
            // 
            this.importFromDatabaseToolStripMenuItem.Name = "importFromDatabaseToolStripMenuItem";
            this.importFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.importFromDatabaseToolStripMenuItem.Text = "Import From Database";
            // 
            // saveToExcelToolStripMenuItem
            // 
            this.saveToExcelToolStripMenuItem.Name = "saveToExcelToolStripMenuItem";
            this.saveToExcelToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveToExcelToolStripMenuItem.Text = "Save to Excel";
            // 
            // importFromExcelToolStripMenuItem
            // 
            this.importFromExcelToolStripMenuItem.Name = "importFromExcelToolStripMenuItem";
            this.importFromExcelToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.importFromExcelToolStripMenuItem.Text = "Import from Excel";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsOverviewToolStripMenuItem,
            this.detailedReportToolStripMenuItem,
            this.salesReportToolStripMenuItem,
            this.paymentsReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // productsOverviewToolStripMenuItem
            // 
            this.productsOverviewToolStripMenuItem.Name = "productsOverviewToolStripMenuItem";
            this.productsOverviewToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.productsOverviewToolStripMenuItem.Text = "Products Overview";
            // 
            // detailedReportToolStripMenuItem
            // 
            this.detailedReportToolStripMenuItem.Name = "detailedReportToolStripMenuItem";
            this.detailedReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.detailedReportToolStripMenuItem.Text = "Detailed Report";
            // 
            // salesReportToolStripMenuItem
            // 
            this.salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
            this.salesReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.salesReportToolStripMenuItem.Text = "Sales Report";
            // 
            // paymentsReportToolStripMenuItem
            // 
            this.paymentsReportToolStripMenuItem.Name = "paymentsReportToolStripMenuItem";
            this.paymentsReportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.paymentsReportToolStripMenuItem.Text = "Payments Report";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Search string";
            // 
            // grpBxSearchButtons
            // 
            this.grpBxSearchButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxSearchButtons.Controls.Add(this.btnReset);
            this.grpBxSearchButtons.Controls.Add(this.btnFind);
            this.grpBxSearchButtons.Controls.Add(this.txtSearchString);
            this.grpBxSearchButtons.Controls.Add(this.dtmDateTo);
            this.grpBxSearchButtons.Controls.Add(this.label1);
            this.grpBxSearchButtons.Controls.Add(this.dtmDateFrom);
            this.grpBxSearchButtons.Controls.Add(this.label5);
            this.grpBxSearchButtons.Controls.Add(this.cmbBrand);
            this.grpBxSearchButtons.Controls.Add(this.label6);
            this.grpBxSearchButtons.Controls.Add(this.cmbPriceRange);
            this.grpBxSearchButtons.Controls.Add(this.label2);
            this.grpBxSearchButtons.Controls.Add(this.cmbModel);
            this.grpBxSearchButtons.Controls.Add(this.label3);
            this.grpBxSearchButtons.Controls.Add(this.label4);
            this.grpBxSearchButtons.Location = new System.Drawing.Point(984, 28);
            this.grpBxSearchButtons.Name = "grpBxSearchButtons";
            this.grpBxSearchButtons.Size = new System.Drawing.Size(212, 327);
            this.grpBxSearchButtons.TabIndex = 7;
            this.grpBxSearchButtons.TabStop = false;
            this.grpBxSearchButtons.Text = "Search";
            // 
            // flwLytPnlToggleControls
            // 
            this.flwLytPnlToggleControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flwLytPnlToggleControls.Controls.Add(this.chkbxSearch);
            this.flwLytPnlToggleControls.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwLytPnlToggleControls.Location = new System.Drawing.Point(1202, 27);
            this.flwLytPnlToggleControls.Name = "flwLytPnlToggleControls";
            this.flwLytPnlToggleControls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flwLytPnlToggleControls.Size = new System.Drawing.Size(29, 327);
            this.flwLytPnlToggleControls.TabIndex = 8;
            // 
            // chkbxSearch
            // 
            this.chkbxSearch.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkbxSearch.Checked = true;
            this.chkbxSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxSearch.Location = new System.Drawing.Point(3, 3);
            this.chkbxSearch.Name = "chkbxSearch";
            this.chkbxSearch.Size = new System.Drawing.Size(23, 104);
            this.chkbxSearch.TabIndex = 0;
            this.chkbxSearch.Text = "Search";
            this.chkbxSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkbxSearch.UseVisualStyleBackColor = true;
            this.chkbxSearch.CheckedChanged += new System.EventHandler(this.chkbxSearch_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(122, 291);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmProductsOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 372);
            this.Controls.Add(this.flwLytPnlToggleControls);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridViewProductOverview);
            this.Controls.Add(this.grpBxSearchButtons);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmProductsOverview";
            this.Text = "Products Overview";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOverview)).EndInit();
            this.productOverviewContextMenuStrip.ResumeLayout(false);
            this.productOverviewContextMenuStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpBxSearchButtons.ResumeLayout(false);
            this.grpBxSearchButtons.PerformLayout();
            this.flwLytPnlToggleControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProductOverview;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip productOverviewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addProductOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem editProductOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtmDateFrom;
        private System.Windows.Forms.DateTimePicker dtmDateTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPriceRange;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailedReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBxSearchButtons;
        private System.Windows.Forms.FlowLayoutPanel flwLytPnlToggleControls;
        private System.Windows.Forms.CheckBox chkbxSearch;
        private System.Windows.Forms.Button btnReset;
    }
}