namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchasePrice")]
    public partial class PurchasePrice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchasePrice()
        {
            SalesManagements = new HashSet<SalesManagement>();
        }

        public long PurchasePriceID { get; set; }

        public long? DistributorPrice { get; set; }

        public long? Transport { get; set; }

        public long? InternalTransport { get; set; }

        public long? KosovoCosts { get; set; }

        public long? Other1 { get; set; }

        public long? Other2 { get; set; }

        public long? TotalPurchase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }
    }
}
