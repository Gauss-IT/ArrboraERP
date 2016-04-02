namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentUnit")]
    public partial class PaymentUnit
    {
        public long PaymentUnitID { get; set; }

        [StringLength(2147483647)]
        public string PaymentID { get; set; }

        public DateTime? PaymentUnitDate { get; set; }

        public long? Amount { get; set; }

        [StringLength(2147483647)]
        public string PaymentType { get; set; }

        [StringLength(2147483647)]
        public string PayedBy { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
