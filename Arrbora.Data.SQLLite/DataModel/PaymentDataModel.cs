/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.SQLLite.DataModel
{
    /// <summary>
    /// Payment Data model
    /// </summary>
    public class PaymentDataModel
    {
        /// <summary>
        /// Gets or sets payment ID
        /// </summary>
        public int PaymentID { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        public decimal? PaymentTotal { get; set; }
    }
}
