/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrbora.Data.DataModel
{
    /// <summary>
    /// Product data model
    /// </summary>
    public class ProductDataModel
    {
        /// <summary>
        /// Gets or sets price id
        /// </summary>
        int PriceID { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        int Price { get; set; }
        
        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        int Transport { get; set; }

        /// <summary>
        /// Gets or sets other costs
        /// </summary>
        int Other1 { get; set; }

        /// <summary>
        /// Gets or sets secondary other costs
        /// </summary>
        int Other2 { get; set; }
    }
}
