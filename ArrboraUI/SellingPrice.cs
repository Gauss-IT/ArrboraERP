namespace Arrbora.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SellingPrice")]
    public partial class SellingPrice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SellingPrice()
        {
            SalesManagements = new HashSet<SalesManagement>();
        }

        public long SellingPriceID { get; set; }

        public long? Price { get; set; }

        public long? Transport { get; set; }

        public long? Other1 { get; set; }

        public long? Other2 { get; set; }

        public long? TotalSelling { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }
    }
}
