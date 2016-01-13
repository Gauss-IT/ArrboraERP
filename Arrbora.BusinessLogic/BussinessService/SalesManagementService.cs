/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.BussinessService.Interfaces;
using System;

namespace Arrbora.Data.BussinessService
{
    public class SalesManagementService : ISalesManagementService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private ISalesManagementAccess salesManagementAccess;

        public SalesManagementDataModel salesManagementDataModel;

        private PaymentAccess _paymentAccess;
        private PaymentUnitAccess _paymentUnitAccess;
        private ProductAccess _productAccess;
        private ProductDeliveryAccess _productDeliveryAccess;
        private PurchasePriceAccess _purchasePriceAccess;
        private SellingPriceAccess _sellingPriceAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public SalesManagementService()
        {
            salesManagementAccess = new SalesManagementAccess();
            salesManagementDataModel = new SalesManagementDataModel();

            _paymentAccess = new PaymentAccess();
            _paymentUnitAccess = new PaymentUnitAccess();
            _productAccess = new ProductAccess();
            _productDeliveryAccess = new ProductDeliveryAccess();
            _purchasePriceAccess = new PurchasePriceAccess();
            _sellingPriceAccess = new SellingPriceAccess();
        }
        /// <summary>
        /// Method to create new sales management entry
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        public SalesManagementDataModel AddEmptySalesManagement()
        {
            salesManagementDataModel.PaymentID = _paymentAccess.AddEmptyPayment();
            salesManagementDataModel.ProductDeliveryID = _productDeliveryAccess.AddEmptyProductDelivery();
            salesManagementDataModel.ProductID = _productAccess.AddEmptyProduct();
            salesManagementDataModel.PurchasePriceID = _purchasePriceAccess.AddEmptyPurchasePrice();
            salesManagementDataModel.SellingPriceID = _sellingPriceAccess.AddEmptySellingPrice();

            salesManagementDataModel.SalesManagementID = salesManagementAccess.AddSalesManagement(salesManagementDataModel);
            return salesManagementDataModel;
        }
        /// <summary>
        /// Add a sales management instance to the table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public int AddSalesManagement(SalesManagementDataModel salesManagement)
        {
            return salesManagementAccess.AddSalesManagement(salesManagement);
        }

        /// <summary>
        /// Delete a sales management row by ID
        /// </summary>
        /// <param name="salesManagementID"></param>
        /// <returns></returns>
        public bool DeleteSalesManagementByID(int salesManagementID)
        {
            return salesManagementAccess.DeleteSalesManagementByID(salesManagementID);
        }

        /// <summary>
        /// Get the sales management table
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSalesManagement()
        {
            return salesManagementAccess.GetAllSalesManagement();
        }

        /// <summary>
        /// Get a sales management instance by ID
        /// </summary>
        /// <param name="salesManagementID"></param>
        /// <returns></returns>
        public DataRow GetSalesManagementById(int salesManagementID)
        {
            return salesManagementAccess.GetSalesManagementById(salesManagementID);
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
            return salesManagementAccess.SearchSalesManagement
                    (productID, productDeliveryID, paymentID, purchasePriceID);
        }

        /// <summary>
        /// Update an entry in the sales management table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public bool UpdateSalesManagement(SalesManagementDataModel salesManagement)
        {
            return salesManagementAccess.UpdateSalesManagement(salesManagement);
        }

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        public SalesManagementDataModel ConvertToDataModel(DataRow salesManagementRow)
        {
            return salesManagementAccess.ConvertToDataModel(salesManagementRow);
        }
    }
}
