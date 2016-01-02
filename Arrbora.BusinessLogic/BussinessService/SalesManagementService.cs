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

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public SalesManagementService()
        {
            salesManagementAccess = new SalesManagementAccess();
        }

        /// <summary>
        /// Add a sales management instance to the table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public bool AddSalesManagement(SalesManagementDataModel salesManagement)
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
        /// <param name="productDeliveryInfoID"></param>
        /// <param name="paymentID"></param>
        /// <param name="purchasePriceID"></param>
        /// <returns></returns>
        public DataTable SearchSalesManagement(object productID, object productDeliveryInfoID, object paymentID, object purchasePriceID)
        {
            return salesManagementAccess.SearchSalesManagement
                    (productID, productDeliveryInfoID, paymentID, purchasePriceID);
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
