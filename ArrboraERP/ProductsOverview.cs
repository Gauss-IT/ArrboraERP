/// <summary>
/// Copyright Arrbora DOO
/// </summary>


using System.Data;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using ArrboraERP.ArrboraDatabaseEntities; 

namespace Arrbora.UI
{
    public partial class frmProductsOverview : Form
    {
        //An instance of the database context class
        private ArrboraDatabase _dbInstance;

        private bool _dataGridControlSizeReduced = false;

        private Dictionary<string, int> _columnNameToTabIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        public frmProductsOverview()
        {
            InitializeComponent();
            _dbInstance = new ArrboraDatabase();
            //InsertData();

            InitializeDataGridViewStyle();
            InitializeColumsToTabsMapping();

            _dataGridControlSizeReduced = true;
            

            UpdateDataGridView();
            LoadPriceCombo();

            Show();
        }

        private void InsertData()
        {
            var salesManagement = new SalesManagement();

            var payment = new Payment()
            {
                PaymentTotal = 1200
            };
            payment.SalesManagements.Add(salesManagement);

            var paymentUnit = new PaymentUnit()
            {
                PaymentUnitDate = DateTime.Now,
                Amount = 1700,
                PaymentType = "Transaction",
                PayedBy = "Husein",
                Payment = payment
            };

            var product = new Product()
            {
                Brand = "Audi",
                Model = "A4",
                VIN = 231654987454,
                EnteriorColour = "Black",
                ExteriorColour = "Red",
                ModelYear = 2013,
                DLPNetto = 15000,
                DLPBrutto = 17000
            };
            product.SalesManagements.Add(salesManagement);

            var productDelivery = new ProductDelivery()
            {
                DateOfPurchase = DateTime.Now,
                LandOfOrigin = "Germany",
                CurrentLocation = "Istanbul",
                DateOfSale = DateTime.Now,
                LandOfDestination = "Turkey",
                ProductStatus = true,
                Seller = "Husein",
                Buyer = "Munur",
            };
            productDelivery.SalesManagements.Add(salesManagement);

            var purchasePrice = new PurchasePrice()
            {
                DistributorPrice = 17000,
                Transport = 3000,
                InternalTransport = 700,
                KosovoCosts = 1300,
                Other1 = 200,
                Other2 = 0,
                TotalPurchase = 22000
            };
            purchasePrice.SalesManagements.Add(salesManagement);

            var sellingPrice = new SellingPrice()
            {
                Price = 26000,
                Transport = 2000,
                Other1 = 500,
                Other2 = 1200,
                TotalSelling = 29700
            };
            sellingPrice.SalesManagements.Add(salesManagement);

            _dbInstance.SalesManagements.Add(salesManagement);
            _dbInstance.Payments.Add(payment);
            _dbInstance.PaymentUnits.Add(paymentUnit);
            _dbInstance.Products.Add(product);
            _dbInstance.ProductDeliveries.Add(productDelivery);
            _dbInstance.PurchasePrices.Add(purchasePrice);
            _dbInstance.SellingPrices.Add(sellingPrice);

            _dbInstance.SaveChanges();
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
        private void LoadDataGridView(ICollection<ProductOverview> data)
        {
            // Data grid view column setting            
            dataGridViewProductOverview.DataSource = data;
            dataGridViewProductOverview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadPriceCombo()
        {
            var priceComboList = new List<string>() {""};

            for (decimal i = 10000; i < 150000; i += 10000)
                priceComboList.Add(i.ToString("0,0"));
            cmbPriceFrom.DataSource = priceComboList;
            cmbPriceTo.DataSource = new List<string>(priceComboList);
        }
        /// <summary>
        /// Load data into the Grid view
        /// </summary>
        /// <param name="data"></param>
        public void UpdateDataGridView()
        {
            using (var context = new ArrboraDatabase())
            {
                var data = context.ProductOverviews.ToList();
                UpdateBrandCombo(data);
                UpdateModelCombo(data, "");
                // Data grid view column setting            
                dataGridViewProductOverview.DataSource = data;
                dataGridViewProductOverview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
                          
            
        }

        private void UpdateBrandCombo(ICollection<ProductOverview> data)
        {
            var brandsList = new List<string>() { "" };
            string brand;

            foreach (var row in data)
            {
                brand = row.Brand;

                if (!brandsList.Contains(brand) && brand != "")
                    brandsList.Add(brand);             
            }

            cmbBrand.DataSource = brandsList;
        }

        private void UpdateModelCombo(ICollection<ProductOverview> data, string Brand)
        {

            var modelsList = new List<string>() { "" };
            string brand, model;
            foreach (var row in data)
            {
                brand = row.Brand;

                if (brand == Brand)
                {
                    model = row.Model;
                    if (!modelsList.Contains(model) && model != "")
                        modelsList.Add(model);
                }
            }

            cmbModel.DataSource = modelsList;
        }


        private void InitializeColumsToTabsMapping()
        {
            _columnNameToTabIndex = new Dictionary<string, int>();
            _columnNameToTabIndex.Add(nameof(ProductOverview.SalesManagementID), 0);
            _columnNameToTabIndex.Add(nameof(ProductOverview.Brand), 0);
            _columnNameToTabIndex.Add(nameof(ProductOverview.Model), 0);
            _columnNameToTabIndex.Add(nameof(ProductOverview.VIN), 0);
            _columnNameToTabIndex.Add(nameof(ProductOverview.DateOfPurchase), 1);
            _columnNameToTabIndex.Add(nameof(ProductOverview.DateOfSale), 1);
            _columnNameToTabIndex.Add(nameof(ProductOverview.TotalPurchase), 2);
            _columnNameToTabIndex.Add(nameof(ProductOverview.TotalSelling), 3);
            _columnNameToTabIndex.Add(nameof(ProductOverview.PaymentTotal), 4);
        }


        private void addProductOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            using (var context = new ArrboraDatabase())
            {
                var data = context.ProductOverviews.ToList();
                LoadDataGridView(data);
            }
            
        }

        private void dataGridViewProductOverview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var selectedColumn = dataGridViewProductOverview.Columns[e.ColumnIndex].DataPropertyName;
            var activeTab = _columnNameToTabIndex[selectedColumn];

            var salesManagementID
                = (int)dataGridViewProductOverview.Rows[e.RowIndex].Cells["SalesManagementID"].Value;

            using (var context = new ArrboraDatabase())
            {
                var data = context.SalesManagements.ToList();
                //LoadDataGridView(data);
                var selectedSalesManagement = data.Where(p=> p.SalesManagementID == salesManagementID).First();

                //var salesManagementDataModel = _salesManagementService.ConvertToDataModel(selectedSalesManagement);
                var frmSalesManagement = new frmSalesManagement(this, selectedSalesManagement, activeTab);
                frmSalesManagement.Show();
            }
        }

        private void productOverviewContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dataGridViewProductOverview.CurrentCell == null) return;
            var salesManagementID = (long)dataGridViewProductOverview.CurrentCell.OwningRow.Cells["SalesManagementID"].Value;
            var selectedColumnName = dataGridViewProductOverview.CurrentCell.OwningColumn.HeaderText;
            SalesManagement selectedSalesManagement;
            //using (var context = new ArrboraDatabase())
            //{
            //    var data = context.SalesManagements.ToList();
            //    //LoadDataGridView(data);
            //    selectedSalesManagement = data.Where(p => p.SalesManagementID == salesManagementID).First();              
            //}

            var data = _dbInstance.SalesManagements.ToList();
            selectedSalesManagement = data.Where(p => p.SalesManagementID == salesManagementID).First();
            frmSalesManagement frmSalesManagement;
            switch (e.ClickedItem.Name)
            {
                
                case "addProductOverviewToolStripMenuItem":
                    var newSalesManagement = new SalesManagement()
                            {
                                Product = new Product(),
                                Payment = new Payment(),
                                ProductDelivery = new ProductDelivery(),
                                PurchasePrice = new PurchasePrice(),
                                SellingPrice = new SellingPrice()
                            };
                    newSalesManagement.Payment.PaymentUnits.Add(new PaymentUnit());
                    frmSalesManagement = new frmSalesManagement(this, newSalesManagement, 0);
                    frmSalesManagement.Show();
                    UpdateDataGridView();
                    break;
                case "editProductOverviewToolStripMenuItem":                    
                    var activeTab = _columnNameToTabIndex[selectedColumnName];
                    frmSalesManagement = new frmSalesManagement(this, selectedSalesManagement, activeTab);
                    frmSalesManagement.Show();
                    break;
                case "deleteProductOverviewToolStripMenuItem":
                   // _salesManagementService.DeleteSalesManagementByID(_selectedRowID);
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
            var dateFrom = DateTime.MinValue;
            var dateTo = DateTime.MaxValue;
            if (dtmDateFrom.Checked)
                dateFrom = dtmDateFrom.Value;
            if (dtmDateTo.Checked)
                dateTo = dtmDateTo.Value;
            decimal priceFrom, priceTo;
            decimal.TryParse((string)cmbPriceFrom.SelectedValue, out priceFrom);
            decimal.TryParse((string)cmbPriceTo.SelectedValue, out priceTo);
            var data = SearchProductOverview((string)cmbBrand.SelectedValue, (string)cmbModel.SelectedValue, 
                                              dateFrom, dateTo, (long)priceFrom, (long)priceTo);            
            LoadDataGridView(data);
        }
        private List<ProductOverview> SearchProductOverview(string brand, string model,
                    DateTime minDate, DateTime maxDate, long priceFrom, long priceTo)
        {
            using (var context = new ArrboraDatabase())
            {                
                var data = context.ProductOverviews.ToList();
                return (from product in data
                          where ((brand == "" || product.Brand == brand) &&
                                 (model == "" || product.Model == model) && 
                                 product.DateOfPurchase > minDate &&
                                 product.DateOfPurchase < maxDate &&
                                 (priceFrom == 0 || product.TotalPurchase >priceFrom) &&
                                 (priceTo == 0 || product.TotalPurchase < priceTo))
                          select product).ToList();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtmDateFrom.Checked = false;
            dtmDateTo.Checked = false;
            cmbPriceFrom.ResetText();
            cmbPriceTo.ResetText();
            using (var context = new ArrboraDatabase())
            {
                var data = context.ProductOverviews.ToList();
                UpdateDataGridView();
                UpdateBrandCombo(data);
                UpdateModelCombo(data, "");
            }
        }

        private void cmbBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedBrand = (string)cmbBrand.SelectedValue;
            using (var context = new ArrboraDatabase())
            {
                var data = context.ProductOverviews.ToList();
                UpdateModelCombo(data, (string)cmbBrand.SelectedValue);
            }
        }
    }
}
