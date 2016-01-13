/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.Data.DataAccess.Interfaces
{
    /// <summary>
    /// Interface ISalesManagementDataAccess
    /// </summary>
    public interface ISalesManagementAccess
    {
        /// <summary>
        /// Method to get a single product management row by ID
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetSalesManagementById(int salesManagementID);
        
        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllSalesManagement();

        /// <summary>
        /// Method to search club products by parameters
        /// </summary>
        /// <returns>Data table</returns>
        DataTable SearchSalesManagement(object productID, object productDeliveryID, 
                                    object paymentID, object purchasePriceID);

        /// <summary>
        /// Method to create new product
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        int AddSalesManagement(SalesManagementDataModel salesManagement);

        /// <summary>
        /// Method to updateproduct details
        /// </summary>
        /// <param name="product">club member</param>
        /// <returns></returns>
        bool UpdateSalesManagement(SalesManagementDataModel salesManagement);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeleteSalesManagementByID(int salesManagementID);

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        SalesManagementDataModel ConvertToDataModel(DataRow salesManagementRow);

    }
}
