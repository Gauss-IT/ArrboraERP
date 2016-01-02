/// <summary>
/// Copyright Arrbora DOO
/// </summary>


namespace Arrbora.Data.DataModel
{
    /// <summary>
    /// Purchase price data model
    /// </summary>
    public class PurchasePriceDataModel
    {
        /// <summary>
        /// Gets or sets purchase price ID
        /// </summary>
        public int PurchasePriceID { get; set; }

        /// <summary>
        /// Gets or sets distributor price
        /// </summary>
        public decimal DistributorPrice { get; set; }

        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public decimal Transport { get; set; }

        /// <summary>
        /// Gets or sets internal transport costs
        /// </summary>
        public decimal InternalTransport { get; set; }
        
        /// <summary>
        /// Gets or sets kosovo company costs
        /// </summary>
        public decimal KosovoCosts { get; set; }

        /// <summary>
        /// Gets or sets other costs 1
        /// </summary>
        public decimal Other1 { get; set; }

        /// <summary>
        /// Gets or sets other costs 2
        /// </summary>
        public decimal Other2 { get; set; }

        /// <summary>
        /// Gets or sets total purchase price
        /// </summary>
        public decimal TotalPurchase { get; set; }
    }
}
