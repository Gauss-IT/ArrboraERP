/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.Data.DataAccess.Interfaces
{
    public interface IProductOverviewAccess
    {
        /// <summary>
        /// Method to get a single product overview
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetProductOverviewById(int SalesManagementID);

        /// <summary>
        /// Method to get all products overview
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllProductOverview();

        /// <summary>
        /// Method to search products overview by parameters
        /// </summary>
        /// <returns>Data table</returns>
        DataTable SearchProductOverview(object SalesManagementID, object brand, object model);

        /// <summary>
        /// Method to create new product overview
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddProductOverview(ProductOverviewDataModel productOverview);

        /// <summary>
        /// Method to delete a product overview by ID
        /// </summary>
        /// <param name="SalesManagementID">Product ManagementID</param>
        /// <returns>true / false</returns>
        bool DeleteProductOverviewByID(int SalesManagementID);
    }
}
