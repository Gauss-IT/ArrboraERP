namespace Arrbora.Data.DataModel
{
    /// <summary>
    /// Data model for product overview, 
    /// all the properties are read only because this table is a view
    /// </summary>
    public class ProductOverviewDataModel
    {
        /// <summary>
        /// Gets product management ID
        /// </summary>
        public int SalesManagementID { get;}

        /// <summary>
        /// Gets Brand
        /// </summary>
        public string Brand { get;}

        /// <summary>
        /// Gets Model
        /// </summary>
        public string Model { get;}

        /// <summary>
        /// Gets VIN number
        /// </summary>
        public decimal VIN { get; }

        /// <summary>
        /// Gets purchase price
        /// </summary>
        public decimal PurchasePrice { get; }

        /// <summary>
        /// Gets selling price
        /// </summary>
        public decimal SellingPrice { get; }

        /// <summary>
        /// Gets total payment
        /// </summary>
        public decimal TotalPayment { get; }
    }
}
