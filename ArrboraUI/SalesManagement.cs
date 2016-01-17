/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Windows.Forms;
using System.Globalization;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.BussinessService;

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

        PaymentDataModel _paymentDataModel;
        PaymentUnitDataModel _paymentUnitDataModel;
        ProductDataModel _productDataModel;
        ProductDeliveryDataModel _productDeliveryDataModel;
        PurchasePriceDataModel _purchasePriceDataModel;
        SellingPriceDataModel _sellingPriceDataModel;
        DataTable _paymentUnitsTable;

        public frmSalesManagement(
            frmProductsOverview parentForm, SalesManagementDataModel salesManagementDataModel,  int selectedTabIndex)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _salesManagementDataModel = salesManagementDataModel;
            _salesManagementService = new SalesManagementService(salesManagementDataModel);
            UpdateDataModels();
            UpdateSalesManagementTab(DataState.WriteToUI);

            saleManagementTabControl.SelectedIndex = selectedTabIndex;
        }

        private void UpdateDataModels()
        {
            _paymentDataModel = _salesManagementService.PaymentDataModel;
            _productDataModel = _salesManagementService.ProductDataModel;
            _productDeliveryDataModel = _salesManagementService.ProductDeliveryDataModel;
            _purchasePriceDataModel = _salesManagementService.PurchasePriceDataModel;
            _sellingPriceDataModel = _salesManagementService.SellingPriceDataModel;
            _paymentUnitsTable = _salesManagementService.PaymentUnitsTable;
        }

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
        private void UpdateProductDeliveryTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
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
        private void UpdatePurchasePriceTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
                    break;
                case DataState.WriteToUI:
                    txtDistributorPrice.Text = _purchasePriceDataModel.DistributorPrice.GetValueOrDefault().ToString(CultureInfo.CreateSpecificCulture("us-US"));
                    txtTransport.Text = _purchasePriceDataModel.Transport.ToString();
                    txtInternalTransport.Text = _purchasePriceDataModel.InternalTransport.ToString();
                    txtKosovoCosts.Text = _purchasePriceDataModel.KosovoCosts.ToString();
                    txtPurchaseOther1.Text = _purchasePriceDataModel.Other1.ToString();
                    txtPurchaseOther2.Text = _purchasePriceDataModel.Other2.ToString();
                    lblPurchaseTotal.Text = _purchasePriceDataModel.TotalPurchase.ToString();
                    break;
            }

        }
        private void UpdateSellingPriceTabPage(DataState dataState)
        {
            switch (dataState)
            {
                case DataState.ReadFromUI:
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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _salesManagementService.DeleteSalesManagementByID(_salesManagementDataModel.SalesManagementID);
            _parentForm.UpdateDataGridView();
            Close();
        }

        private void btnNew_Click(object sender, System.EventArgs e)
        {
           _salesManagementDataModel = _salesManagementService.AddEmptySalesManagement();
            UpdateDataModels();
            UpdateSalesManagementTab(DataState.WriteToUI);
            _parentForm.UpdateDataGridView();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            UpdateSalesManagementTab(DataState.WriteToUI);
        }
    }
}
