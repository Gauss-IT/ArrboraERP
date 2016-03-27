/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.BussinessService.Interfaces;
using System;
using Arrbora.BusinessLogic.BussinessService;

namespace Arrbora.BusinessLogic.BussinessService
{
    public class SalesManagementService : ISalesManagementService
    {
        /// <summary>
        /// Interface of sales management Access
        /// </summary>
        private ISalesManagementAccess _salesManagementAccess;
        
        /// <summary>
        /// Initialize services
        /// </summary>
        private PaymentService _paymentService;
        private PaymentUnitService _paymentUnitService;
        private ProductService _productService;
        private ProductDeliveryService _productDeliveryService;
        private PurchasePriceService _purchasePriceService;
        private SellingPriceService _sellingPriceService;

        /// <summary>
        /// Data models
        /// </summary>
        public SalesManagementDataModel SalesManagementDataModel { get; set; }
        public PaymentDataModel PaymentDataModel { get; set; }
        public PaymentUnitDataModel PaymentUnitDataModel { get; set; }
        public ProductDataModel ProductDataModel { get; set; }
        public ProductDeliveryDataModel ProductDeliveryDataModel { get; set; }
        public PurchasePriceDataModel PurchasePriceDataModel { get; set; }
        public SellingPriceDataModel SellingPriceDataModel { get; set; }
        public DataTable PaymentUnitsTable { get; set; }

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public SalesManagementService()
        {
            _salesManagementAccess = new SalesManagementAccess();
            SalesManagementDataModel = new SalesManagementDataModel();

            _paymentService = new PaymentService();
            _paymentUnitService = new PaymentUnitService();
            _productService = new ProductService();
            _productDeliveryService = new ProductDeliveryService();
            _purchasePriceService = new PurchasePriceService();
            _sellingPriceService = new SellingPriceService();
        }

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public SalesManagementService(SalesManagementDataModel salesManagementDataModel)
        {
            _salesManagementAccess = new SalesManagementAccess();
            SalesManagementDataModel = salesManagementDataModel;

            _paymentService = new PaymentService();
            _paymentUnitService = new PaymentUnitService();
            _productService = new ProductService();
            _productDeliveryService = new ProductDeliveryService();
            _purchasePriceService = new PurchasePriceService();
            _sellingPriceService = new SellingPriceService();

            PopulateDataModels();
        }


        /// <summary>
        /// Method to create new sales management entry
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        public SalesManagementDataModel AddEmptySalesManagement()
        {
            SalesManagementDataModel.PaymentID = _paymentService.AddEmptyPayment();
            SalesManagementDataModel.ProductDeliveryID = _productDeliveryService.AddEmptyProductDelivery();
            SalesManagementDataModel.ProductID = _productService.AddEmptyProduct();
            SalesManagementDataModel.PurchasePriceID = _purchasePriceService.AddEmptyPurchasePrice();
            SalesManagementDataModel.SellingPriceID = _sellingPriceService.AddEmptySellingPrice();

            PopulateDataModels();

            SalesManagementDataModel.SalesManagementID = _salesManagementAccess.AddSalesManagement(SalesManagementDataModel);
            return SalesManagementDataModel;
        }

        /// <summary>
        /// Add a sales management instance to the table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public int AddSalesManagement(SalesManagementDataModel salesManagement)
        {
            //TODO:implement necessary logic
            return _salesManagementAccess.AddSalesManagement(salesManagement);
        }

        /// <summary>
        /// Delete a sales management row by ID
        /// </summary>
        /// <param name="salesManagementID"></param>
        /// <returns></returns>
        public bool DeleteSalesManagementByID(int salesManagementID)
        {
            //TODO : implement necessary logic
            var success = true;
            SalesManagementDataModel = ConvertToDataModel( GetSalesManagementById(salesManagementID));
            success = _paymentUnitService.DeleteAllPaymentUnitsForPaymentID(SalesManagementDataModel.PaymentID);
            success =_paymentService.DeletePaymentByID(SalesManagementDataModel.PaymentID) && success;
            success =_productDeliveryService.DeleteProductDeliveryByID(SalesManagementDataModel.ProductDeliveryID) && success;
            success =_productService.DeleteProductByID(SalesManagementDataModel.ProductID) && success;
            success =_purchasePriceService.DeletePurchasePriceByID(SalesManagementDataModel.PurchasePriceID) && success;
            success =_sellingPriceService.DeleteSellingPriceByID(SalesManagementDataModel.SellingPriceID) && success;
            success =_salesManagementAccess.DeleteSalesManagementByID(salesManagementID) && success;
            return success;
        }

        /// <summary>
        /// Get the sales management table
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSalesManagement()
        {
            return _salesManagementAccess.GetAllSalesManagement();
        }

        /// <summary>
        /// Get a sales management instance by ID
        /// </summary>
        /// <param name="salesManagementID"></param>
        /// <returns></returns>
        public DataRow GetSalesManagementById(int salesManagementID)
        {
            return _salesManagementAccess.GetSalesManagementById(salesManagementID);
        }

        /// <summary>
        /// Retrieve a search query from the sales management table
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productDeliveryID"></param>
        /// <param name="paymentID"></param>
        /// <param name="purchasePriceID"></param>
        /// <returns></returns>
        public DataTable SearchSalesManagement(object productID, object productDeliveryID, object paymentID, object purchasePriceID)
        {
            return _salesManagementAccess.SearchSalesManagement
                    (productID, productDeliveryID, paymentID, purchasePriceID);
        }

        /// <summary>
        /// Update an entry in the sales management table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public bool UpdateSalesManagement(SalesManagementDataModel salesManagement)
        {
            var success = true;
            success = _paymentService.UpdatePayment(PaymentDataModel) && success;
            success = _productDeliveryService.UpdateProductDelivery(ProductDeliveryDataModel) && success;
            success = _productService.UpdateProduct(ProductDataModel) && success;
            success = _purchasePriceService.UpdatePurchasePrice(PurchasePriceDataModel) && success;
            success = _sellingPriceService.UpdateSellingPrice(SellingPriceDataModel) && success;
            success = _paymentUnitService.UpdatePaymentUnitDataTable(PaymentUnitsTable) && success;
            //success = _salesManagementAccess.UpdateSalesManagement(SalesManagementDataModel) && success;
             return success;
        }

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        public SalesManagementDataModel ConvertToDataModel(DataRow salesManagementRow)
        {
            return _salesManagementAccess.ConvertToDataModel(salesManagementRow);
        }

        public void PopulateDataModels()
        {
            PaymentDataModel = _paymentService.ConvertToDataModel(
                                _paymentService.GetPaymentById(
                                    SalesManagementDataModel.PaymentID));
            ProductDataModel = _productService.ConvertToDataModel(
                                _productService.GetProductById(
                                    SalesManagementDataModel.ProductID));
            ProductDeliveryDataModel = _productDeliveryService.ConvertToDataModel(
                                _productDeliveryService.GetProductDeliveryById(
                                    SalesManagementDataModel.ProductDeliveryID));
            PurchasePriceDataModel = _purchasePriceService.ConvertToDataModel(
                                _purchasePriceService.GetPurchasePriceById(
                                    SalesManagementDataModel.PurchasePriceID));
            SellingPriceDataModel = _sellingPriceService.ConvertToDataModel(
                                _sellingPriceService.GetSellingPriceById(
                                    SalesManagementDataModel.SellingPriceID));
            PaymentUnitsTable = _paymentUnitService.GetAllPaymentUnitsForPayment(
                                    PaymentDataModel.PaymentID);
        }
    }
}
