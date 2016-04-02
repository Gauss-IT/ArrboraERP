/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrbora.Data.SQLLite.DataModel
{
    /// <summary>
    /// Product data model
    /// </summary>
    public class ProductDataModel
    {     
        /// <summary>
        /// Gets or sets product id
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the model brand
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// Gets or sets the model name
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the VIN number
        /// </summary>
        public decimal? VIN { get; set; }

        /// <summary>
        /// Gets or sets enteriour colour
        /// </summary>
        public string EnteriorColour { get; set; }
       
        /// <summary>
        /// Gets or sets exterior colour
        /// </summary>
        public string ExteriorColour { get; set; }
        
        /// <summary>
        /// Gets or sets model year
        /// </summary>
        public int? ModelYear { get; set; }
        
        /// <summary>
        /// Gets or sets netto price
        /// </summary>
        public decimal? DLPNetto { get; set; }        
        
         /// <summary>
        /// Gets or sets brutto price
        /// </summary>
        public decimal? DLPBrutto { get; set; }

    }
}
