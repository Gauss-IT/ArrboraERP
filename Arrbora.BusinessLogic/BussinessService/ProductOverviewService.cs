/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.BussinessService.Interfaces;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using System;
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

        public DataTable SearchProductOverview(object brand, object model, 
                    DateTime minDate, DateTime maxDate, decimal priceFrom, decimal priceTo)
        {
            return productOverviewAccess.SearchProductOverview(brand, model, minDate,maxDate, priceFrom, priceTo);
        }
    }
}
