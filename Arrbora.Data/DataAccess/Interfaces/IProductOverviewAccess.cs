﻿/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.Data.DataAccess.Interfaces
{
    public interface IProductOverviewAccess
    {
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
    }
}
