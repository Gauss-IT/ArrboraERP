using Arrbora.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool DeleteProductByID(int productManagementID)
        {
            return productOverviewAccess.DeleteProductByID(productManagementID);
        }

        public DataTable GetAllProductOverview()
        {
            return productOverviewAccess.GetAllProductOverview();
        }

        public DataRow GetProductOverviewById(int productManagementID)
        {
            return productOverviewAccess.GetProductOverviewById(productManagementID);
        }

        public DataTable SearchProductOverview(object productManagementID, object brand, object model)
        {
            return productOverviewAccess.SearchProductOverview(productManagementID, brand, model);
        }
    }
}
