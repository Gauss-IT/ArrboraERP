/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Windows.Forms;
using System.Data;
using System.Linq;
using System;
using ArrboraERP.ArrboraDatabaseEntities;
using System.Collections.Generic;

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
        SalesManagement _salesManagement;
        List<PaymentUnit> _paymentUnits;
        ArrboraDatabase _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parentForm"> A reference to the parent form</param>
        /// <param name="salesManagementDataModel">A reference to the sales management data model</param>
        /// <param name="selectedTabIndex">Index of the tab to initialize the form with</param>
        public frmSalesManagement(
            frmProductsOverview parentForm, SalesManagement salesManagement,  int selectedTabIndex)
        {
            using (var context = new ArrboraDatabase())
            {
                var data = context.SalesManagements.ToList();
                var selectedSalesManagement = data.Where(p => p.SalesManagementID == salesManagement.SalesManagementID).First();
            }
            using (var context1 = new ArrboraDatabase())
            {
                var s = context1.Payments.ToList();
                var y = context1.SellingPrices.ToList();
            }
            _dbContext = new ArrboraDatabase();
            InitializeComponent();
            _salesManagement = _dbContext.SalesManagements.Where(
                        p => p.SalesManagementID == salesManagement.SalesManagementID).First();
            _paymentUnits = _dbContext.PaymentUnits.Where(
                        p => p.PaymentID == salesManagement.PaymentID).ToList();

            _parentForm = parentForm;

            //UpdateDataModels();
            UpdateSalesManagementForm(DataState.WriteToUI);

            saleManagementTabControl.SelectedIndex = selectedTabIndex;
        }

        /// <summary>
        /// Updates the data models 
        /// </summary>
        //private void UpdateDataModels()
        //{
        //    _salesManagement.Payment = _salesManagement.Payment;
        //    _salesManagement.Product = _salesManagement.Product;
        //    _salesManagement.ProductDelivery = _salesManagement.ProductDelivery;
        //    _salesManagement.PurchasePrice = _salesManagement.PurchasePrice;
        //    _salesManagement.SellingPrice = _salesManagement.SellingPrice;
        //    _salesManagement.Payment.PaymentUnits = _salesManagement.Payment.PaymentUnits;
        //}

        /// <summary>
        /// Updates the tabs of this form 
        /// </summary>
        /// <param name="dataState">An enum variable which is used to read data from or write data to form</param>
        private void UpdateSalesManagementForm(DataState dataState)
        {
            
            lblBrand.Text = _salesManagement.Product.Brand;
            lblModel.Text = _salesManagement.Product.Model;
            lblPurchaseDate.Text = _salesManagement.ProductDelivery.DateOfPurchase.GetValueOrDefault().ToShortDateString();
            lblSalesPrice.Text = _salesManagement.SellingPrice.TotalSelling.ToString();

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

                    _salesManagement.Product.Brand = txtBrand.Text;
                    _salesManagement.Product.Model = txtModel.Text;

                    _salesManagement.Product.VIN = null;
                    if(decimal.TryParse(txtVIN.Text, out decimalValue))
                        _salesManagement.Product.VIN = (long)decimalValue;

                    _salesManagement.Product.EnteriorColour = txtEnteriorColour.Text;
                    _salesManagement.Product.ExteriorColour = txtExteriorColour.Text;

                    _salesManagement.Product.ModelYear = null;
                    if (int.TryParse(txtModelYear.Text, out intValue))
                        _salesManagement.Product.ModelYear = intValue;
                    break;
                case DataState.WriteToUI:
                    lblProductIDShow.Text = _salesManagement.Product.ProductID.ToString();
                    txtBrand.Text = _salesManagement.Product.Brand;
                    txtModel.Text = _salesManagement.Product.Model;
                    txtVIN.Text = _salesManagement.Product.VIN.ToString();
                    txtEnteriorColour.Text = _salesManagement.Product.EnteriorColour;
                    txtExteriorColour.Text = _salesManagement.Product.ExteriorColour;
                    txtModelYear.Text = _salesManagement.Product.ModelYear.ToString();
                    txtDLPNetto.Text = _salesManagement.Product.DLPNetto.ToString();
                    txtDLPBrutto.Text = _salesManagement.Product.DLPBrutto.ToString();
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
                    _salesManagement.ProductDelivery.DateOfPurchase  = null;
                    _salesManagement.ProductDelivery.DateOfPurchase = dtpDateOfPurchase.Value;
                    _salesManagement.ProductDelivery.CurrentLocation = txtCurentLocation.Text;
                    _salesManagement.ProductDelivery.LandOfDestination = txtLandOfDestination.Text;
                    _salesManagement.ProductDelivery.Seller = txtSeller.Text;
                    _salesManagement.ProductDelivery.ProductWebsite = txtWebsite.Text;
                    _salesManagement.ProductDelivery.LandOfOrigin = txtLandOfOrigin.Text;
                    _salesManagement.ProductDelivery.DateOfSale = null;
                    _salesManagement.ProductDelivery.DateOfSale = dtpDateOfSale.Value;
                    _salesManagement.ProductDelivery.Buyer = txtBuyer.Text;
                    //_salesManagement.ProductDelivery.ProductAttachment = txtAttachment.Text;
                    break;
                case DataState.WriteToUI:
                    dtpDateOfPurchase.Value = _salesManagement.ProductDelivery.DateOfPurchase == null ? DateTime.Now.Date :
                        _salesManagement.ProductDelivery.DateOfPurchase.GetValueOrDefault().Date;
                    txtCurentLocation.Text = _salesManagement.ProductDelivery.CurrentLocation;
                    txtLandOfDestination.Text = _salesManagement.ProductDelivery.LandOfDestination;
                    txtSeller.Text = _salesManagement.ProductDelivery.Seller;
                    txtWebsite.Text = _salesManagement.ProductDelivery.ProductWebsite;
                    txtLandOfOrigin.Text = _salesManagement.ProductDelivery.LandOfOrigin;
                    dtpDateOfSale.Value = _salesManagement.ProductDelivery.DateOfSale == null ? DateTime.Now.Date :
                        _salesManagement.ProductDelivery.DateOfSale.GetValueOrDefault().Date;
                    txtBuyer.Text = _salesManagement.ProductDelivery.Buyer;
                    //txtAttachment.Text = _salesManagement.ProductDelivery.ProductAttachment;
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

                    _salesManagement.PurchasePrice.DistributorPrice = null;
                    if (decimal.TryParse(txtDistributorPrice.Text, out decimalValue))
                        _salesManagement.PurchasePrice.DistributorPrice = (long)decimalValue;
                    _salesManagement.PurchasePrice.Transport = null;
                    if (decimal.TryParse(txtTransport.Text, out decimalValue))
                        _salesManagement.PurchasePrice.Transport = (long)decimalValue;
                    _salesManagement.PurchasePrice.InternalTransport = null;
                    if (decimal.TryParse(txtInternalTransport.Text, out decimalValue))
                        _salesManagement.PurchasePrice.InternalTransport = (long)decimalValue;
                    _salesManagement.PurchasePrice.KosovoCosts = null;
                    if (decimal.TryParse(txtKosovoCosts.Text, out decimalValue))
                        _salesManagement.PurchasePrice.KosovoCosts = (long)decimalValue;
                    _salesManagement.PurchasePrice.Other1 = null;
                    if (decimal.TryParse(txtPurchaseOther1.Text, out decimalValue))
                        _salesManagement.PurchasePrice.Other1 = (long)decimalValue;
                    _salesManagement.PurchasePrice.Other2 = null;
                    if (decimal.TryParse(txtPurchaseOther2.Text, out decimalValue))
                        _salesManagement.PurchasePrice.Other2 = (long)decimalValue;
                    _salesManagement.PurchasePrice.TotalPurchase = null;
                    if (decimal.TryParse(lblPurchaseTotal.Text, out decimalValue))
                        _salesManagement.PurchasePrice.TotalPurchase = (long)decimalValue;
                    break;
                case DataState.WriteToUI:
                    txtDistributorPrice.Text = _salesManagement.PurchasePrice.DistributorPrice.GetValueOrDefault().ToString();
                    txtTransport.Text = _salesManagement.PurchasePrice.Transport.ToString();
                    txtInternalTransport.Text = _salesManagement.PurchasePrice.InternalTransport.ToString();
                    txtKosovoCosts.Text = _salesManagement.PurchasePrice.KosovoCosts.ToString();
                    txtPurchaseOther1.Text = _salesManagement.PurchasePrice.Other1.ToString();
                    txtPurchaseOther2.Text = _salesManagement.PurchasePrice.Other2.ToString();
                    lblPurchaseTotal.Text = _salesManagement.PurchasePrice.TotalPurchase.ToString();
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

                    _salesManagement.SellingPrice.Price = null;
                    if (decimal.TryParse(txtSellingPrice.Text, out decimalValue))
                        _salesManagement.SellingPrice.Price = (long)decimalValue;
                    _salesManagement.SellingPrice.Transport = null;
                    if (decimal.TryParse(txtSellingPriceTransport.Text, out decimalValue))
                        _salesManagement.SellingPrice.Transport = (long)decimalValue;
                    _salesManagement.SellingPrice.Other1 = null;
                    if (decimal.TryParse(txtPurchaseOther1.Text, out decimalValue))
                        _salesManagement.SellingPrice.Other1 = (long)decimalValue;
                    _salesManagement.SellingPrice.Other2 = null;
                    if (decimal.TryParse(txtPurchaseOther2.Text, out decimalValue))
                        _salesManagement.SellingPrice.Other2 = (long)decimalValue;
                    _salesManagement.SellingPrice.TotalSelling = null;
                    if (decimal.TryParse(lblSellingTotal.Text, out decimalValue))
                        _salesManagement.SellingPrice.TotalSelling = (long)decimalValue;
                    break;
                case DataState.WriteToUI:
                    txtSellingPrice.Text = _salesManagement.SellingPrice.Price.ToString();
                    txtSellingPriceTransport.Text = _salesManagement.SellingPrice.Transport.ToString();
                    txtSellingOther1.Text = _salesManagement.SellingPrice.Other1.ToString();
                    txtSellingOther2.Text = _salesManagement.SellingPrice.Other2.ToString();
                    lblSellingTotal.Text = _salesManagement.SellingPrice.TotalSelling.ToString();
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
                    var dataTable = ConvertToDataTable(paymenetUnitsDataGridView);
                    _salesManagement.Payment.PaymentTotal = (long)CalculateTotalPayments();
                    break;
                case DataState.WriteToUI:
                    lblPaymentsTotal.Text = _salesManagement.Payment.PaymentTotal.ToString();
                    lblDueAmount.Text = CalculateDueAmount().ToString();
                    // Data grid view column setting                               
                    paymenetUnitsDataGridView.DataSource = _salesManagement.Payment.PaymentUnits;
                    paymenetUnitsDataGridView.Columns["PaymentUnitID"].Visible = false;
                    paymenetUnitsDataGridView.Columns["PaymentID"].Visible = false;
                    paymenetUnitsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }

        }
        private void UpdateSalesManagementDataModels()
        {
            _salesManagement.Payment = _salesManagement.Payment;
            _salesManagement.Product = _salesManagement.Product;
            _salesManagement.ProductDelivery= _salesManagement.ProductDelivery;
            _salesManagement.PurchasePrice = _salesManagement.PurchasePrice;
            _salesManagement.SellingPrice = _salesManagement.SellingPrice;
            //_salesManagement.PaymentUnitsTable = _paymentUnitsTable;

        }

        private DataTable ConvertToDataTable(DataGridView dataGrid)
        {
            var dtTable = new DataTable();
            //Type t = typeof(PaymentUnitDataModel);
            foreach (DataGridViewColumn dgvColumn in dataGrid.Columns)
            {
                dtTable.Columns.Add(dgvColumn.Name);
                //dtTable.Columns[dgvColumn.Name].DataType = _paymentUnitsTable.Columns[dgvColumn.Name].DataType;
            }

            DataRow newRow;
            foreach (DataGridViewRow dRow in dataGrid.Rows)
            {
                if (dRow.Index == dataGrid.Rows.Count - 1) continue;
                newRow = dtTable.NewRow();
                foreach (DataGridViewColumn dgvColumn in dataGrid.Columns)
                {

                    newRow[dgvColumn.Name] = dRow.Cells[dgvColumn.Name].Value ?? DBNull.Value;
                    //always set the PaymentID value to current sales management value
                    //if (dgvColumn.Name == "PaymentID")
                       // newRow[dgvColumn.Name] = _salesManagementDataModel.PaymentID;
                }

                dtTable.Rows.Add(newRow);
            }
            return dtTable;
        }

        private decimal CalculateTotalPayments()
        {
            decimal result = 0;
            //if (_paymentUnitsTable.Rows.Count == 0) return 0;
            //foreach (DataRow row in _paymentUnitsTable.Rows)
            //{
            //    if(row["Amount"] != null)
            //        result += (decimal)row["Amount"];
            //}

            return result;
        }

        private decimal CalculateDueAmount()
        {
            return (_salesManagement.SellingPrice.TotalSelling ?? 0) - (_salesManagement.Payment.PaymentTotal ?? 0);
        }

        /// <summary>
        /// Event handler for cancel button click
        /// </summary>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            _parentForm.UpdateDataGridView();
            Close();
        }

        /// <summary>
        /// Event handler for delete button click
        /// </summary>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            //_salesManagementService.DeleteSalesManagementByID(_salesManagementDataModel.SalesManagementID);
            _parentForm.UpdateDataGridView();
            Close();
        }

        /// <summary>
        /// Event handler for new button click
        /// </summary>
        private void btnNew_Click(object sender, System.EventArgs e)
        {
           //_salesManagementDataModel = _salesManagementService.AddEmptySalesManagement();
            //UpdateDataModels();
            UpdateSalesManagementForm(DataState.WriteToUI);
            _parentForm.UpdateDataGridView();
        }

        /// <summary>
        /// Event handler for save button click
        /// </summary>
        private void btnSaveAll_Click(object sender, System.EventArgs e)
        {
            UpdateSalesManagementForm(DataState.ReadFromUI);
            UpdateSalesManagementDataModels();
            //_salesManagementService.UpdateSalesManagement(_salesManagementDataModel);
            UpdateSalesManagementForm(DataState.WriteToUI);
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
                    //_productService.UpdateProduct(_productDataModel);
                    UpdateProductTabPage(DataState.WriteToUI);
                    break;
                case "productDeliveryTabPage":
                    UpdateProductDeliveryTabPage(DataState.ReadFromUI);
                    //_productDeliveryService.UpdateProductDelivery(_productDeliveryDataModel);
                    UpdateProductDeliveryTabPage(DataState.WriteToUI);
                    break;
                case "purchasePriceTabPage":
                    UpdatePurchasePriceTabPage(DataState.ReadFromUI);
                    //_purchasePriceService.UpdatePurchasePrice(_purchasePriceDataModel);
                    UpdatePurchasePriceTabPage(DataState.WriteToUI);
                    break;
                case "sellingPriceTabPage":
                    UpdateSellingPriceTabPage(DataState.ReadFromUI);
                    //_sellingPriceService.UpdateSellingPrice(_sellingPriceDataModel);
                    UpdateSellingPriceTabPage(DataState.WriteToUI);
                    break;
                case "paymentsTabPage":
                    UpdatePaymentsTabPage(DataState.ReadFromUI);
                    //_paymentService.UpdatePayment(_paymentDataModel);
                    //_paymentUnitService.UpdatePaymentUnitDataTable(_paymentUnitsTable);
                    UpdatePaymentsTabPage(DataState.WriteToUI);
                    break;
            }
        }

        private void paymenetUnitsDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var selectedRowID = e.Row.Cells["PaymentUnitID"].Value;
            if (selectedRowID == DBNull.Value) return;
            //_paymentUnitService.DeletePaymentUnitByID((int)selectedRowID);
            //_paymentUnitsTable = _paymentUnitService.GetAllPaymentUnits();
            //_paymentDataModel.PaymentTotal = CalculateTotalPayments();
            //UpdatePaymentsTabPage(DataState.WriteToUI);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //_salesManagementService.PopulateDataModels();
            //UpdateDataModels();
            UpdateSalesManagementForm(DataState.WriteToUI);
        }
    }
}
