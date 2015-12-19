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
        public int VIN { get; }

        /// <summary>
        /// Gets purchase price
        /// </summary>
        public int PurchasePrice { get; }

        /// <summary>
        /// Gets selling price
        /// </summary>
        public int SellingPrice { get; }

        /// <summary>
        /// Gets total payment
        /// </summary>
        public int TotalPayment { get; }
    }
}
