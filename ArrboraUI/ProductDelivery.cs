namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDelivery")]
    public partial class ProductDelivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDelivery()
        {
            SalesManagements = new HashSet<SalesManagement>();
        }

        public long ProductDeliveryID { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        [StringLength(2147483647)]
        public string LandOfOrigin { get; set; }

        [StringLength(2147483647)]
        public string CurrentLocation { get; set; }

        public DateTime? DateOfSale { get; set; }

        [StringLength(2147483647)]
        public string LandOfDestination { get; set; }

        public bool? ProductStatus { get; set; }

        [StringLength(2147483647)]
        public string Seller { get; set; }

        [StringLength(2147483647)]
        public string Buyer { get; set; }

        [StringLength(2147483647)]
        public string ProductWebsite { get; set; }

        [MaxLength(2147483647)]
        public byte[] ProductAttachment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }
    }
}
