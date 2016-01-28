/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Windows.Forms;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.BusinessLogic.BussinessService;
using System;

namespace Arrbora.UI
{
    enum DataState
    {
        ReadFromUI =    1,
        WriteToUI   =   2
    }

    public partial class frmSalesManagement : Form
    {
        frmProductsOverview _parentForm;

        SalesManagementDataModel _salesManagementDataModel;

        SalesManagementService _salesManagementService;
        PaymentService _paymentService;
        PaymentUnitService _paymentUnitService;
        ProductService _productService;
        ProductDeliveryService _productDeliveryService;
        PurchasePriceService _purchasePriceService;
        SellingPriceService _sellingPriceService;

        PaymentDataModel _paymentDataModel;
        PaymentUnitDataModel _paymentUnitDataModel;
        ProductDataModel _productDataModel;
        ProductDeliveryDataModel _productDeliveryDataModel;
        PurchasePriceDataModel _purchasePriceDataModel;
        SellingPriceDataModel _sellingPriceDataModel;
        DataTable _paymentUnitsTable;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentForm"> A reference to the parent form</param>
        /// <param name="salesManagementDataModel">A reference to the sales management data model</param>
        /// <param name="selectedTabIndex">Index of the tab to initialize the form with</param>
        public frmSalesManagement(
            frmProductsOverview parentForm, SalesManagementDataModel salesManagementDataModel,  int selectedTabIndex)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _salesManagementDataModel = salesManagementDataModel;

            _salesManagementService = new SalesManagementService(salesManagementDataModel);
            _paymentService = new PaymentService();
            _paymentUnitService = new PaymentUnitService();
            _productService = new ProductService();
            _productDeliveryService = new ProductDeliveryService();
            _purchasePriceService = new PurchasePriceService();
            _sellingPriceService = new SellingPriceService();

            UpdateDataModels();
            UpdateSalesManagementTab(DataState.WriteToUI);

            saleManagementTabControl.SelectedIndex = selectedTabIndex;
        }

        /// <summary>
        /// Updates the data models 
        /// </summary>
        private void UpdateDataModels()
        {
            _paymentDataModel = _salesManagementService.PaymentDataModel;
            _productDataModel = _salesManagementService.ProductDataModel;
            _productDeliveryDataModel = _salesManagementService.ProductDeliveryDataModel;
            _purchasePriceDataModel = _salesManagementService.PurchasePriceDataModel;
            _sellingPriceDataModel = _salesManagementService.SellingPriceDataModel;
            _paymentUnitsTable = _salesManagementService.PaymentUnitsTable;
        }

        /// <summary>
        /// Updates the tabs of this form 
        /// </summary>
        /// <param name="dataState">An enum variable which is used to read data from or write data to form</param>
        private void UpdateSalesManagementTab(DataState dataState)
        {
            lblBrand.Text = _productDataModel.Brand;
            lblModel.Text = _productDataModel.Model;
            lblPurchaseDate.Text = _productDeliveryDataModel.DateOfPurchase.GetValueOrDefault().ToShortDateString();
            lblSalesPrice.Text = _sellingPriceDataModel.TotalSelling.ToString();

            UpdateProductTabPage(dataState);
            UpdateProductDeliveryTabPage(dataState);
            UpdatePurchasePriceTabPage(dataState);
            UpdateSellingPriceTabPage(dataState);
            UpdatePaymentsTabPage(dataState);
        }

        /// <summary>
        /// Update the products tab
        /// </summary>
        /// <param name="dataState">Read data from or write data to form</param>
        private void UpdateProductTabPage(DataState dataState)
        {
            switch (dataState) {
                case DataState.ReadFromUI:
                    decimal decimalValue;
                    int intValue;

                    _productDataModel.Brand = txtBrand.Text;
                    _productDataModel.Model = txtModel.Text;

                    _productDataModel.VIN = null;
                    if(decimal.TryParse(txtVIN.Text, out decimalValue))
                        _productDataModel.VIN = decimalValue;

                    _productDataModel.EnteriorColour = txtEnteriorColour.Text;
                    _productDataModel.ExteriorColour = txtExteriorColour.Text;

                    _productDataModel.ModelYear = null;
                    if (int.TryParse(txtModelYear.Text, out intValue))
                        _productDataModel.ModelYear = intValue;
                    break;
                case DataState.WriteToUI:
                    lblProductIDShow.Text = _productDataModel.ProductID.ToString();
                    txtBrand.Text = _productDataModel.Brand;
                    txtModel.Text = _productDataModel.Model;
                    txtVIN.Text = _productDataModel.VIN.ToString();
                    txtEnteriorColour.Text = _productDataModel.EnteriorColour;
                    txtExteriorColour.Text = _productDataModel.ExteriorColour;
                    txtModelYear.Text = _productDataModel.ModelYear.ToString();
                    txtDLPNetto.Text = _productDataModel.DLPNetto.ToString();
                    txtDLPBrutto.Text = _productDataModel.DLPBrutto.ToString();
                    break;
            }
        }

        /// <summary>
        /// Update product delivery tab
        /// </summary>
        /// <param name="dataState">Read data from or write data to form</param>
        private void UpdateProductDeliveryTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
                    DateTime dateTime;

                    _productDeliveryDataModel.DateOfPurchase  = null;
                    if (DateTime.TryParse(txtDateOfPurchase.Text, out dateTime))
                        _productDeliveryDataModel.DateOfPurchase = dateTime;
                    _productDeliveryDataModel.CurrentLocation = txtCurentLocation.Text;
                    _productDeliveryDataModel.LandOfDestination = txtLandOfDestination.Text;
                    _productDeliveryDataModel.Seller = txtSeller.Text;
                    _productDeliveryDataModel.ProductWebsite = txtWebsite.Text;
                    _productDeliveryDataModel.LandOfOrigin = txtLandOfOrigin.Text;
                    _productDeliveryDataModel.DateOfSale = null;
                    if (DateTime.TryParse(txtDateOfSale.Text, out dateTime))
                        _productDeliveryDataModel.DateOfSale = dateTime;
                    _productDeliveryDataModel.Buyer = txtBuyer.Text;
                    _productDeliveryDataModel.ProductAttachment = txtAttachment.Text;
                    break;
                case DataState.WriteToUI:
                    txtDateOfPurchase.Text = _productDeliveryDataModel.DateOfPurchase.GetValueOrDefault().ToShortDateString();
                    txtCurentLocation.Text = _productDeliveryDataModel.CurrentLocation;
                    txtLandOfDestination.Text = _productDeliveryDataModel.LandOfDestination;
                    txtSeller.Text = _productDeliveryDataModel.Seller;
                    txtWebsite.Text = _productDeliveryDataModel.ProductWebsite;
                    txtLandOfOrigin.Text = _productDeliveryDataModel.LandOfOrigin;
                    txtDateOfSale.Text = _productDeliveryDataModel.DateOfSale.GetValueOrDefault().ToShortDateString();
                    txtBuyer.Text = _productDeliveryDataModel.Buyer;
                    txtAttachment.Text = _productDeliveryDataModel.ProductAttachment;
                    break;
            }
        }

        /// <summary>
        /// Update purchase price tab
        /// </summary>
        /// <param name="dataState">Read data from or write data to form</param>
        private void UpdatePurchasePriceTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
                    decimal decimalValue;

                    _purchasePriceDataModel.DistributorPrice = null;
                    if (decimal.TryParse(txtDistributorPrice.Text, out decimalValue))
                        _purchasePriceDataModel.DistributorPrice = decimalValue;
                    _purchasePriceDataModel.Transport = null;
                    if (decimal.TryParse(txtTransport.Text, out decimalValue))
                        _purchasePriceDataModel.Transport = decimalValue;
                    _purchasePriceDataModel.InternalTransport = null;
                    if (decimal.TryParse(txtInternalTransport.Text, out decimalValue))
                        _purchasePriceDataModel.InternalTransport = decimalValue;
                    _purchasePriceDataModel.KosovoCosts = null;
                    if (decimal.TryParse(txtKosovoCosts.Text, out decimalValue))
                        _purchasePriceDataModel.KosovoCosts = decimalValue;
                    _purchasePriceDataModel.Other1 = null;
                    if (decimal.TryParse(txtPurchaseOther1.Text, out decimalValue))
                        _purchasePriceDataModel.Other1 = decimalValue;
                    _purchasePriceDataModel.Other2 = null;
                    if (decimal.TryParse(txtPurchaseOther2.Text, out decimalValue))
                        _purchasePriceDataModel.Other2 = decimalValue;
                    _purchasePriceDataModel.TotalPurchase = null;
                    if (decimal.TryParse(lblPurchaseTotal.Text, out decimalValue))
                        _purchasePriceDataModel.TotalPurchase = decimalValue;
                    break;
                case DataState.WriteToUI:
                    txtDistributorPrice.Text = _purchasePriceDataModel.DistributorPrice.GetValueOrDefault().ToString();
                    txtTransport.Text = _purchasePriceDataModel.Transport.ToString();
                    txtInternalTransport.Text = _purchasePriceDataModel.InternalTransport.ToString();
                    txtKosovoCosts.Text = _purchasePriceDataModel.KosovoCosts.ToString();
                    txtPurchaseOther1.Text = _purchasePriceDataModel.Other1.ToString();
                    txtPurchaseOther2.Text = _purchasePriceDataModel.Other2.ToString();
                    lblPurchaseTotal.Text = _purchasePriceDataModel.TotalPurchase.ToString();
                    break;
            }

        }

        /// <summary>
        /// Update Selling Price Tab
        /// </summary>
        /// <param name="dataState">Read data from or write data to form</param>
        private void UpdateSellingPriceTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
                    decimal decimalValue;

                    _sellingPriceDataModel.Price = null;
                    if (decimal.TryParse(txtSellingPrice.Text, out decimalValue))
                        _sellingPriceDataModel.Price = decimalValue;
                    _sellingPriceDataModel.Transport = null;
                    if (decimal.TryParse(txtSellingPriceTransport.Text, out decimalValue))
                        _sellingPriceDataModel.Transport = decimalValue;
                    _sellingPriceDataModel.Other1 = null;
                    if (decimal.TryParse(txtPurchaseOther1.Text, out decimalValue))
                        _sellingPriceDataModel.Other1 = decimalValue;
                    _sellingPriceDataModel.Other2 = null;
                    if (decimal.TryParse(txtPurchaseOther2.Text, out decimalValue))
                        _sellingPriceDataModel.Other2 = decimalValue;
                    _sellingPriceDataModel.TotalSelling = null;
                    if (decimal.TryParse(lblSellingTotal.Text, out decimalValue))
                        _sellingPriceDataModel.TotalSelling = decimalValue;
                    break;
                case DataState.WriteToUI:
                    txtSellingPrice.Text = _sellingPriceDataModel.Price.ToString();
                    txtSellingPriceTransport.Text = _sellingPriceDataModel.Transport.ToString();
                    txtSellingOther1.Text = _sellingPriceDataModel.Other1.ToString();
                    txtSellingOther2.Text = _sellingPriceDataModel.Other2.ToString();
                    lblSellingTotal.Text = _sellingPriceDataModel.TotalSelling.ToString();
                    break;
            }
        }

        /// <summary>
        /// Update payments tab
        /// </summary>
        /// <param name="dataState">Read data from or write data to form</param>
        private void UpdatePaymentsTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
                    break;
                case DataState.WriteToUI:
                    lblPaymentsTotal.Text = _paymentDataModel.PaymentTotal.ToString();
                    // Data grid view column setting            
                    paymenetUnitsDataGridView.DataSource = _paymentUnitsTable;
                    paymenetUnitsDataGridView.DataMember = _paymentUnitsTable.TableName;
                    paymenetUnitsDataGridView.Columns[0].Visible = false;
                    paymenetUnitsDataGridView.Columns[1].Visible = false;
                    paymenetUnitsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }

        }
        private void UpdateSalesManagementDataModels()
        {
            _salesManagementService.PaymentDataModel = _paymentDataModel;
            _salesManagementService.ProductDataModel = _productDataModel;
            _salesManagementService.ProductDeliveryDataModel = _productDeliveryDataModel;
            _salesManagementService.PurchasePriceDataModel = _purchasePriceDataModel;
            _salesManagementService.SellingPriceDataModel = _sellingPriceDataModel;
            //_salesManagementService.PaymentUnitsTable = _paymentUnitsTable;

        }

        /// <summary>
        /// Event handler for cancel button click
        /// </summary>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _parentForm.UpdateDataGridView();
            Close();
        }

        /// <summary>
        /// Event handler for delete button click
        /// </summary>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _salesManagementService.DeleteSalesManagementByID(_salesManagementDataModel.SalesManagementID);
            _parentForm.UpdateDataGridView();
            Close();
        }

        /// <summary>
        /// Event handler for new button click
        /// </summary>
        private void btnNew_Click(object sender, System.EventArgs e)
        {
           _salesManagementDataModel = _salesManagementService.AddEmptySalesManagement();
            UpdateDataModels();
            UpdateSalesManagementTab(DataState.WriteToUI);
            _parentForm.UpdateDataGridView();
        }

        /// <summary>
        /// Event handler for save button click
        /// </summary>
        private void btnSaveAll_Click(object sender, System.EventArgs e)
        {
            UpdateSalesManagementTab(DataState.ReadFromUI);
            UpdateSalesManagementDataModels();
            _salesManagementService.UpdateSalesManagement(_salesManagementDataModel);
            _parentForm.UpdateDataGridView();
        }

        private void frmSalesManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parentForm.UpdateDataGridView();
        }

        private void btnSaveThis_Click(object sender, EventArgs e)
        {
            switch (saleManagementTabControl.SelectedTab.Name)
            {
                case "productTabPage":
                    UpdateProductTabPage(DataState.ReadFromUI);
                    _productService.UpdateProduct(_productDataModel);
                    break;
                case "productDeliveryTabPage":
                    UpdateProductDeliveryTabPage(DataState.ReadFromUI);
                    _productDeliveryService.UpdateProductDelivery(_productDeliveryDataModel);
                    break;
                case "purchasePriceTabPage":
                    UpdatePurchasePriceTabPage(DataState.ReadFromUI);
                    _purchasePriceService.UpdatePurchasePrice(_purchasePriceDataModel);
                    break;
                case "sellingPriceTabPage":
                    UpdateSellingPriceTabPage(DataState.ReadFromUI);
                    _sellingPriceService.UpdateSellingPrice(_sellingPriceDataModel);
                    break;
                case "paymentsTabPage":
                    UpdatePaymentsTabPage(DataState.ReadFromUI);
                    _paymentService.UpdatePayment(_paymentDataModel);
                    break;
            }
        }
    }
}
