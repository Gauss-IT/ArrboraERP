/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;

namespace Arrbora.Data.SQLLite.DataModel
{
    /// <summary>
    /// Product Delivery Data model class
    /// </summary>
    public class ProductDeliveryDataModel
    {
        /// <summary>
        /// Gets or sets product delivery ID
        /// </summary>
        public int ProductDeliveryID { get; set; }

        /// <summary>
        /// Gets or sets date of purchase
        /// </summary>
        public DateTime? DateOfPurchase { get; set; }

        /// <summary>
        /// Gets or sets land of origin
        /// </summary>
        public string LandOfOrigin { get; set; }

        /// <summary>
        /// Gets or sets current location
        /// </summary>
        public string CurrentLocation { get; set; }

        /// <summary>
        /// Gets or sets date of sale
        /// </summary>
        public DateTime? DateOfSale { get; set; }

        /// <summary>
        /// Gets or sets land of destination
        /// </summary>
        public string LandOfDestination { get; set; }

        /// <summary>
        /// Gets or sets product status
        /// </summary>
        public bool? ProductStatus { get; set; }

        /// <summary>
        /// Gets or sets seller
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets buyer
        /// </summary>
        public string Buyer { get; set; }

        /// <summary>
        /// Gets or sets product website
        /// </summary>
        public string ProductWebsite { get; set; }

        /// <summary>
        /// Gets or sets buyer
        /// </summary>
        public string ProductAttachment { get; set; }
    }
}
