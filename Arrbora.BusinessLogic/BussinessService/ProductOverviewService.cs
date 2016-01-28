/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.BussinessService.Interfaces;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.BusinessLogic.BussinessService
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


        public DataTable GetAllProductOverview()
        {
            return productOverviewAccess.GetAllProductOverview();
        }

        public DataTable SearchProductOverview(object SalesManagementID, object brand, object model)
        {
            return productOverviewAccess.SearchProductOverview(SalesManagementID, brand, model);
        }
    }
}
