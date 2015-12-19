/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;

namespace Arrbora.Data.DataModel
{
    /// <summary>
    /// Payment Unit Data model
    /// </summary>
    public class PaymentUnitDataModel
    {
        /// <summary>
        /// Gets or sets payment unit ID
        /// </summary>
        public int PaymentUnitID { get; set; }

        /// <summary>
        /// Gets or sets payment ID
        /// </summary>
        public int PaymentID { get; set; }

        /// <summary>
        /// Gets or sets payment unit date
        /// </summary>
        public DateTime PaymentUnitDate { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        public string PayedBy { get; set; }

        /// <summary>
        /// Gets or sets note
        /// </summary>
        public string Note { get; set; }

    }
}
