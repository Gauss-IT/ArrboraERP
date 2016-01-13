/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Windows.Forms;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess;
using System.Globalization;
using System.Data;

namespace Arrbora.UI
{
    public partial class frmSalesManagement : Form
    {
        SalesManagementDataModel _salesManagementDataModel;
        PaymentDataModel _paymentDataModel;
        PaymentUnitDataModel _paymentUnitDataModel;
        ProductDataModel _productDataModel;
        ProductDeliveryDataModel _productDeliveryDataModel;
        PurchasePriceDataModel _purchasePriceDataModel;
        SellingPriceDataModel _sellingPriceDataModel;
        DataTable _paymentUnitsTable;

        SalesManagementAccess _salesManagementAccess;
        PaymentAccess _paymentAccess;
        PaymentUnitAccess _paymentUnitAccess;
        ProductAccess _productAccess;
        ProductDeliveryAccess _productDeliveryAccess;
        PurchasePriceAccess _purchasePriceAccess;
        SellingPriceAccess _sellingPriceAccess;

        public frmSalesManagement(SalesManagementDataModel salesManagementDataModel, int selectedTabIndex)
        {
            InitializeComponent();
            _salesManagementDataModel = salesManagementDataModel;
            InitializeDataAccess();
            InitializeDataModels();
            InitializeSalesManagementTab();

            saleManagementTabControl.SelectedIndex = selectedTabIndex;
        }

        private void InitializeDataAccess()
        {
            _salesManagementAccess = new SalesManagementAccess();
            _paymentAccess = new PaymentAccess();
            _paymentUnitAccess = new PaymentUnitAccess();
            _productAccess = new ProductAccess();
            _productDeliveryAccess = new ProductDeliveryAccess();
            _purchasePriceAccess = new PurchasePriceAccess();
            _sellingPriceAccess = new SellingPriceAccess(); 
        }

        private void InitializeDataModels()
        {
            _paymentDataModel = _paymentAccess.ConvertToDataModel(
                                _paymentAccess.GetPaymentById(
                                    _salesManagementDataModel.PaymentID));        
            _productDataModel = _productAccess.ConvertToDataModel(
                                _productAccess.GetProductById(
                                    _salesManagementDataModel.ProductID));
            _productDeliveryDataModel = _productDeliveryAccess.ConvertToDataModel(
                                _productDeliveryAccess.GetProductDeliveryById(
                                    _salesManagementDataModel.ProductDeliveryID));
            _purchasePriceDataModel = _purchasePriceAccess.ConvertToDataModel(
                                _purchasePriceAccess.GetPurchasePriceById(
                                    _salesManagementDataModel.PurchasePriceID));
            _sellingPriceDataModel = _sellingPriceAccess.ConvertToDataModel(
                                _sellingPriceAccess.GetSellingPriceById(
                                    _salesManagementDataModel.SellingPriceID));
            _paymentUnitsTable = _paymentUnitAccess.GetAllPaymentUnitsForPayment(
                                    _paymentDataModel.PaymentID);

        }

        private void InitializeSalesManagementTab()
        {
            lblBrand.Text = _productDataModel.Brand;
            lblModel.Text = _productDataModel.Model;
            lblPurchaseDate.Text = _productDeliveryDataModel.DateOfPurchase.ToShortDateString();
            lblSalesPrice.Text = _sellingPriceDataModel.TotalSelling.ToString();

            InitializeProductTabPage();
            InitializeProductDeliveryTabPage();
            InitializePurchasePriceTabPage();
            InitializeSellingPriceTabPage();
            InitializePaymentsTabPage();
        }
        private void InitializeProductTabPage()
        {
            lblProductIDShow.Text = _productDataModel.ProductID.ToString();
            txtBrand.Text = _productDataModel.Brand;
            txtModel.Text = _productDataModel.Model;
            txtVIN.Text = _productDataModel.VIN.ToString();
            txtEnteriorColour.Text = _productDataModel.EnteriorColour;
            txtExteriorColour.Text = _productDataModel.ExteriorColour;
            txtModelYear.Text = _productDataModel.ModelYear.ToString();
            txtDLPNetto.Text = _productDataModel.DLPNetto.ToString();
            txtDLPBrutto.Text = _productDataModel.DLPBrutto.ToString();
        }
        private void InitializeProductDeliveryTabPage()
        {
            txtDateOfPurchase.Text = _productDeliveryDataModel.DateOfPurchase.ToShortDateString();
            txtCurentLocation.Text = _productDeliveryDataModel.CurrentLocation;
            txtLandOfDestination.Text = _productDeliveryDataModel.LandOfDestination;
            txtSeller.Text = _productDeliveryDataModel.Seller;
            txtWebsite.Text = _productDeliveryDataModel.ProductWebsite;
            txtLandOfOrigin.Text = _productDeliveryDataModel.LandOfOrigin;
            txtDateOfSale.Text = _productDeliveryDataModel.DateOfSale.Date.ToShortDateString();
            txtBuyer.Text = _productDeliveryDataModel.Buyer;
            txtAttachment.Text = _productDeliveryDataModel.ProductAttachment;

        }
        private void InitializePurchasePriceTabPage()
        {
            txtDistributorPrice.Text = _purchasePriceDataModel.DistributorPrice.ToString(CultureInfo.CreateSpecificCulture("us-US"));
            txtTransport.Text = _purchasePriceDataModel.Transport.ToString();
            txtInternalTransport.Text = _purchasePriceDataModel.InternalTransport.ToString();
            txtKosovoCosts.Text = _purchasePriceDataModel.KosovoCosts.ToString();
            txtPurchaseOther1.Text = _purchasePriceDataModel.Other1.ToString();
            txtPurchaseOther2.Text = _purchasePriceDataModel.Other2.ToString();
            lblPurchaseTotal.Text = _purchasePriceDataModel.TotalPurchase.ToString();
        }
        private void InitializeSellingPriceTabPage()
        {
            txtSellingPrice.Text = _sellingPriceDataModel.Price.ToString();
            txtSellingPriceTransport.Text = _sellingPriceDataModel.Transport.ToString();
            txtSellingOther1.Text = _sellingPriceDataModel.Other1.ToString();
            txtSellingOther2.Text = _sellingPriceDataModel.Other2.ToString();
            lblSellingTotal.Text = _sellingPriceDataModel.TotalSelling.ToString();
        }
        private void InitializePaymentsTabPage()
        {
            lblPaymentsTotal.Text = _paymentDataModel.PaymentTotal.ToString();
            // Data grid view column setting            
            paymenetUnitsDataGridView.DataSource = _paymentUnitsTable;
            paymenetUnitsDataGridView.DataMember = _paymentUnitsTable.TableName;
            paymenetUnitsDataGridView.Columns[0].Visible = false;
            paymenetUnitsDataGridView.Columns[1].Visible = false;
            paymenetUnitsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


    }
}
