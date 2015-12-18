using Arrbora.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrbora.Data.BussinessService
{
    public interface IProductOverviewService
    {
        /// <summary>
        /// Method to get a single product overview
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetProductOverviewById(int productManagementID);

        /// <summary>
        /// Method to get all products overview
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllProductOverview();

        /// <summary>
        /// Method to search products overview by parameters
        /// </summary>
        /// <returns>Data table</returns>
        DataTable SearchProductOverview(object productManagementID, object brand, object model);

        /// <summary>
        /// Method to create new product overview
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddProductOverview(ProductOverviewDataModel productOverview);

        /// <summary>
        /// Method to delete a product overview by ID
        /// </summary>
        /// <param name="productManagementID">Product ManagementID</param>
        /// <returns>true / false</returns>
        bool DeleteProductByID(int productManagementID);

    }
}
