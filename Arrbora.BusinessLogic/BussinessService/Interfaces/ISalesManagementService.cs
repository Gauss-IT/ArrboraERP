/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.Data.BussinessService.Interfaces
{
    /// <summary>
    /// Interface to Sales Management Service
    /// </summary>
    public interface ISalesManagementService
    {
        /// <summary>
        /// Method to get a single sales management row by ID
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetSalesManagementById(int salesManagementID);

        /// <summary>
        /// Method to get all sales management
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllSalesManagement();

        /// <summary>
        /// Method to search sales management by parameters
        /// </summary>
        /// <returns>Data table</returns>
        DataTable SearchSalesManagement(object productID, object productDeliveryID,
                                    object paymentID, object purchasePriceID);

        /// <summary>
        /// Method to create new sales management entry
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        SalesManagementDataModel AddEmptySalesManagement();

        /// <summary>
        /// Method to create new sales management entry
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        int AddSalesManagement(SalesManagementDataModel salesManagement);

        /// <summary>
        /// Method to update sales management details
        /// </summary>
        /// <param name="product">club member</param>
        /// <returns></returns>
        bool UpdateSalesManagement(SalesManagementDataModel salesManagement);

        /// <summary>
        /// Method to delete a sales management row
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
