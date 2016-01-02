/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.BussinessService;
using Arrbora.Data.DataModel;
using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace Arrbora.UI
{
    public partial class ProductsOverview : Form
    {
        //An instance of a product overview class
        private ProductOverviewService _productOverviewService;

        //An instance of a sales management class
        private SalesManagementService _salesManagementService;

        //An instance of a sales management class
        private DataTable _dataGridTable;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsOverview()
        {
            InitializeComponent();           

            var productOverviewService = new ProductOverviewService();
            _salesManagementService = new SalesManagementService();
            _productOverviewService = new ProductOverviewService();

            _dataGridTable = productOverviewService.GetAllProductOverview();
            InitilizeDataGridViewStyle();
            LoadDataGridView(_dataGridTable);

            Show();
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridViewStyle()
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
            var selectedColumn = _dataGridTable.Columns[e.ColumnIndex].ColumnName.ToString();
            var activeTab = SelectActiveTabFromColumn(selectedColumn);

            var selectedRowID
                = _dataGridTable.Rows[e.RowIndex].Field<int>("SalesManagementID");
            var selectedSalesManagement = _salesManagementService.GetSalesManagementById(selectedRowID);

            var salesManagementDataModel = _salesManagementService.ConvertToDataModel(selectedSalesManagement);
            var frmSalesManagement = new frmSalesManagement(salesManagementDataModel);
            frmSalesManagement.Show();
        }

        private void dataGridViewProductOverview_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
           
        }

        private string SelectActiveTabFromColumn(string columnName)
        {
            return string.Empty;
        }
    }
}
