namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOverview")]
    public partial class ProductOverview
    {
        [Key]
        public long SalesManagementID { get; set; }

        [StringLength(2147483647)]
        public string Brand { get; set; }

        [StringLength(2147483647)]
        public string Model { get; set; }

        public long? VIN { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public DateTime? DateOfSale { get; set; }

        public long? TotalPurchase { get; set; }

        public long? TotalSelling { get; set; }

        public long? PaymentTotal { get; set; }
    }
}
