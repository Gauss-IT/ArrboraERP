namespace ArrboraERP.ArrboraDatabaseEntities
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

        [Required]
        public virtual Payment Payment { get; set; }
        [Required]
        public virtual ProductDelivery ProductDelivery { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual PurchasePrice PurchasePrice { get; set; }
        [Required]
        public virtual SellingPrice SellingPrice { get; set; }
    }
}
