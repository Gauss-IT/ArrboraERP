namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesManagement")]
    public partial class SalesManagement
    {
        public long SalesManagementID { get; set; }

        public long? ProductID { get; set; }

        public long? ProductDeliveryID { get; set; }

        public long? SellingPriceID { get; set; }

        public long? PaymentID { get; set; }

        public long? PurchasePriceID { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual ProductDelivery ProductDelivery { get; set; }

        public virtual Product Product { get; set; }

        public virtual PurchasePrice PurchasePrice { get; set; }

        public virtual SellingPrice SellingPrice { get; set; }
    }
}
