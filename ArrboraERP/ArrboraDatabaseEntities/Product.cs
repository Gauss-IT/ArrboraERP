namespace ArrboraERP.ArrboraDatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            SalesManagements = new HashSet<SalesManagement>();
        }
        //[ForeignKey("SalesManagement")]
        public long ProductID { get; set; }

        [StringLength(2147483647)]
        public string Brand { get; set; }

        [StringLength(2147483647)]
        public string Model { get; set; }

        public long? VIN { get; set; }

        [StringLength(2147483647)]
        public string EnteriorColour { get; set; }

        [StringLength(2147483647)]
        public string ExteriorColour { get; set; }

        public long? ModelYear { get; set; }

        public long? DLPNetto { get; set; }

        public long? DLPBrutto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }
    }
}
