/// <summary>
/// Copyright Arrbora DOO
/// </summary>


using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using Arrbora.BusinessLogic.BussinessService;
using Arrbora.Data.DataModel;

namespace Arrbora.UI
{
    public partial class frmProductsOverview : Form
    {       
        //An instance of a product overview class
        private ProductOverviewService _productOverviewService;

        //An instance of a sales management class
        private SalesManagementService _salesManagementService;

        //An instance of a sales management class
        private DataTable _dataGridTable;

        private bool _dataGridControlSizeReduced = false;

        int _selectedRowID;
        string _selectedColumnName;
        private Dictionary<string, int> _columnNameToTabIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        public frmProductsOverview()
        {
            InitializeComponent();           

            var productOverviewService = new ProductOverviewService();
            _salesManagementService = new SalesManagementService();
            _productOverviewService = new ProductOverviewService();

            _dataGridTable = productOverviewService.GetAllProductOverview();


            InitializeDataGridViewStyle();
            InitializeColumsToTabsMapping();

            //grpBxSearchButtons.Visible = true;
            _dataGridControlSizeReduced = true;
            //chkbxSearch.Checked = false;
            

            UpdateDataGridView();

            Show();
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitializeDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            dataGridViewProductOverview.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewProductOverview.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dataGridViewProductOverview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewProductOverview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProductOverview.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewProductOverview.DefaultCellStyle.BackColor = Color.Empty;
            dataGridViewProductOverview.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dataGridViewProductOverview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewProductOverview.GridColor = SystemColors.ControlDarkDark;
        }

        /// <summary>
        /// Load data into the Grid view
        /// </summary>
        /// <param name="data"></param>
        private void LoadDataGridView(DataTable data)
        {
            // Data grid view column setting            
            dataGridViewProductOverview.DataSource = data;
            dataGridViewProductOverview.DataMember = data.TableName;
            dataGridViewProductOverview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        
        /// <summary>
        /// Load data into the Grid view
        /// </summary>
        /// <param name="data"></param>
        public void UpdateDataGridView()
        {
            var data = _productOverviewService.GetAllProductOverview();
            UpdateBrandCombo(data);
            UpdateModelCombo(data, "");
            // Data grid view column setting            
            dataGridViewProductOverview.DataSource = data;
            dataGridViewProductOverview.DataMember = data.TableName;
            dataGridViewProductOverview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void UpdateBrandCombo(DataTable data)
        {
            var brandsList = new List<string>();
            string brand;
            foreach (DataRow row in data.Rows)
            {
                brand = row.Field<string>("Brand");

                if (!brandsList.Contains(brand) && brand != "")
                    brandsList.Add(brand);             
            }

            cmbBrand.DataSource = brandsList;
        }

        private void UpdateModelCombo(DataTable data, string Brand)
        {

            var modelsList = new List<string>();
            string brand, model;
            foreach (DataRow row in data.Rows)
            {
                //if (Brand == "") break;
                brand = row.Field<string>("Brand");

                if (brand == Brand)
                {
                    model = row.Field<string>("Model");
                    if (!modelsList.Contains(model) && model != "")
                        modelsList.Add(model);
                }
            }

            cmbModel.DataSource = modelsList;
        }
        private void InitializeColumsToTabsMapping()
        {
            _columnNameToTabIndex = new Dictionary<string, int>();
            _columnNameToTabIndex.Add(_dataGridTable.Columns[0].ColumnName,0);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[1].ColumnName, 0);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[2].ColumnName, 0);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[3].ColumnName, 0);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[4].ColumnName, 1);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[5].ColumnName, 1);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[6].ColumnName, 2);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[7].ColumnName, 3);
            _columnNameToTabIndex.Add(_dataGridTable.Columns[8].ColumnName, 4);
        }


        private void addProductOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //_dataGridTable;
            //var salesManagementService = new SalesManagementService();
            //var salesManagement = new SalesManagementDataModel();
            //salesManagementService.AddSalesManagement(salesManagement);
            
            var productOverviewService = new ProductOverviewService();
            DataTable data = productOverviewService.GetAllProductOverview();
            //var data = new DataTable();
            LoadDataGridView(data);
        }

        private void dataGridViewProductOverview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var selectedColumn = _dataGridTable.Columns[e.ColumnIndex].ColumnName;
            var activeTab = _columnNameToTabIndex[selectedColumn];

            _selectedRowID
                = (int)dataGridViewProductOverview.Rows[e.RowIndex].Cells["SalesManagementID"].Value;
            var selectedSalesManagement = _salesManagementService.GetSalesManagementById(_selectedRowID);

            var salesManagementDataModel = _salesManagementService.ConvertToDataModel(selectedSalesManagement);
            var frmSalesManagement = new frmSalesManagement(this,salesManagementDataModel, activeTab);
            frmSalesManagement.Show();
        }

        private void productOverviewContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           // if (_selectedRowID == -1) return;
            if (dataGridViewProductOverview.CurrentCell == null) return;
            _selectedRowID = (int)dataGridViewProductOverview.CurrentCell.OwningRow.Cells["SalesManagementID"].Value;
            _selectedColumnName = dataGridViewProductOverview.CurrentCell.OwningColumn.HeaderText;
            var salesManagementDataRow = _salesManagementService.GetSalesManagementById(_selectedRowID);
            var salesManagementDataModel = _salesManagementService.ConvertToDataModel(salesManagementDataRow);
            switch (e.ClickedItem.Name)
            {
                case "addProductOverviewToolStripMenuItem":
                    var salesManagementID = _salesManagementService.AddEmptySalesManagement();
                    UpdateDataGridView();
                    break;
                case "editProductOverviewToolStripMenuItem":                    
                    var activeTab = _columnNameToTabIndex[_selectedColumnName];
                    var frmSalesManagement = new frmSalesManagement(this,salesManagementDataModel, activeTab);
                    frmSalesManagement.Show();
                    break;
                case "deleteProductOverviewToolStripMenuItem":
                    _salesManagementService.DeleteSalesManagementByID(_selectedRowID);
                    UpdateDataGridView();
                    break;
            } 
        }

        private void chkbxSearch_CheckedChanged(object sender, EventArgs e)
        {
            grpBxSearchButtons.Visible = chkbxSearch.Checked;
            if (grpBxSearchButtons.Visible && !_dataGridControlSizeReduced)
            {
                dataGridViewProductOverview.Width -= grpBxSearchButtons.Width;
                _dataGridControlSizeReduced = true;
            }
            else if (!grpBxSearchButtons.Visible && _dataGridControlSizeReduced)
            {
                dataGridViewProductOverview.Width += grpBxSearchButtons.Width;
                _dataGridControlSizeReduced = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var data = _productOverviewService.SearchProductOverview(cmbBrand.SelectedValue,cmbModel.SelectedValue);            
            LoadDataGridView(data);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var data = _productOverviewService.GetAllProductOverview();
            UpdateDataGridView();
            UpdateBrandCombo(data);
            UpdateModelCombo(data, "");
        }

        private void cmbBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedBrand = (string)cmbBrand.SelectedValue;
            var data = _productOverviewService.GetAllProductOverview();
            UpdateModelCombo(data, (string)cmbBrand.SelectedValue);
            //if(cmbBrand.ValueMember != "")
                //cmbBrand.SelectedText = selectedBrand;
        }
    }
}
