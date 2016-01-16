/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.DataModel
{
    /// <summary>
    /// Selling price Data model
    /// </summary>
    public class SellingPriceDataModel
    {
        /// <summary>
        /// Gets or sets selling price ID
        /// </summary>
        public int SellingPriceID { get; set; }

        /// <summary>
        /// Gets or sets  price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets  transport costs
        /// </summary>
        public decimal? Transport { get; set; }

        /// <summary>
        /// Gets or sets  other costs 1
        /// </summary>
        public decimal? Other1 { get; set; }

        /// <summary>
        /// Gets or sets  other costs 2
        /// </summary>
        public decimal? Other2 { get; set; }

        /// <summary>
        /// Gets or sets  total selling
        /// </summary>
        public decimal? TotalSelling { get; set; }
    }
}
