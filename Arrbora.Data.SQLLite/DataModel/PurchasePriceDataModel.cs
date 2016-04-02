/// <summary>
/// Copyright Arrbora DOO
/// </summary>


namespace Arrbora.Data.SQLLite.DataModel
{
    /// <summary>
    /// Purchase price data model
    /// </summary>
    public class PurchasePriceDataModel
    {
        private decimal? _totalPurchase;
        /// <summary>
        /// Gets or sets purchase price ID
        /// </summary>
        public int PurchasePriceID { get; set; }

        /// <summary>
        /// Gets or sets distributor price
        /// </summary>
        public decimal? DistributorPrice { get; set; }

        /// <summary>
        /// Gets or sets transport costs
        /// </summary>
        public decimal? Transport { get; set; }

        /// <summary>
        /// Gets or sets internal transport costs
        /// </summary>
        public decimal? InternalTransport { get; set; }
        
        /// <summary>
        /// Gets or sets kosovo company costs
        /// </summary>
        public decimal? KosovoCosts { get; set; }

        /// <summary>
        /// Gets or sets other costs 1
        /// </summary>
        public decimal? Other1 { get; set; }

        /// <summary>
        /// Gets or sets other costs 2
        /// </summary>
        public decimal? Other2 { get; set; }

        /// <summary>
        /// Gets or sets total purchase price
        /// </summary>
        public decimal? TotalPurchase
        { get
            {
                _totalPurchase = (DistributorPrice ?? 0) + (Transport ?? 0) + (InternalTransport ?? 0) +
                     (KosovoCosts ?? 0) + (Other1 ?? 0) + (Other2 ?? 0);
                return _totalPurchase;
            }
            set { _totalPurchase = value; }
        }
    }
}
