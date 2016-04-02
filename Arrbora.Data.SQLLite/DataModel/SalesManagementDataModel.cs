/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.SQLLite.DataModel
{
    public class SalesManagementDataModel
    {
        /// <summary>
        /// Gets or sets product management id
        /// </summary>
        public int SalesManagementID { get; set; }

        /// <summary>
        /// Gets or sets product id
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets product delivery info id
        /// </summary>
        public int ProductDeliveryID { get; set; }

        /// <summary>
        /// Gets or sets payment id
        /// </summary>
        public int PaymentID { get; set; }

        /// <summary>
        /// Gets or sets purchase price id
        /// </summary>
        public int PurchasePriceID { get; set; }

        /// <summary>
        /// Gets or sets purchase price id
        /// </summary>
        public int SellingPriceID { get; set; }
    }
}
