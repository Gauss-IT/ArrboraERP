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
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsOverview()
        {
            InitializeComponent();
            Show();
            var productService = new ProductService();
            productService.GetAllProducts();

            var productOverviewService = new ProductOverviewService();
            DataTable data = productOverviewService.GetAllProductOverview();
            InitilizeDataGridViewStyle();
            LoadDataGridView(data);
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

        /// <summary>
        /// Event handler for a new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            var product = new ProductDataModel();
            var frm = new frmProduct(product);
            frm.Show();
        }

        private void addProductOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var salesManagementService = new SalesManagementService();
            var salesManagement = new SalesManagementDataModel();
            salesManagementService.AddSalesManagement(salesManagement);

            var productOverviewService = new ProductOverviewService();
            DataTable data = productOverviewService.GetAllProductOverview();
            LoadDataGridView(data);
        }

        private void dataGridViewProductOverview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var salesManagement = new SalesManagementDataModel();
            var frmSalesManagement = new frmSalesManagement(salesManagement);
            frmSalesManagement.Show();
        }
    }
}
