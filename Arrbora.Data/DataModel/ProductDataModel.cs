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
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets other costs
        /// </summary>
        public int VIN { get; set; }

        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public string EnteriourColour { get; set; }
       
        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public string ExteriourColour { get; set; }
        
        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public int ModelYear { get; set; }
        
        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public int DLPNetto { get; set; }        
        
         /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public int DLPBrutto { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        public string Buyer { get; set; }
    }
}
