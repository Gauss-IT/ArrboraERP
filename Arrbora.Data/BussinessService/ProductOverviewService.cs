/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.BussinessService.Interfaces;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.Data.BussinessService
{
    public class ProductOverviewService :IProductOverviewService
    {
        /// <summary>
        /// Interface of Product Overview Access
        /// </summary>
        private IProductOverviewAccess productOverviewAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public ProductOverviewService()
        {
            productOverviewAccess = new ProductOverviewAccess();
        }

        public bool AddProductOverview(ProductOverviewDataModel productOverview)
        {
            return productOverviewAccess.AddProductOverview(productOverview);
        }

        public bool DeleteProductByID(int SalesManagementID)
        {
            return productOverviewAccess.DeleteProductOverviewByID(SalesManagementID);
        }

        public DataTable GetAllProductOverview()
        {
            return productOverviewAccess.GetAllProductOverview();
        }

        public DataRow GetProductOverviewById(int SalesManagementID)
        {
            return productOverviewAccess.GetProductOverviewById(SalesManagementID);
        }

        public DataTable SearchProductOverview(object SalesManagementID, object brand, object model)
        {
            return productOverviewAccess.SearchProductOverview(SalesManagementID, brand, model);
        }
    }
}
