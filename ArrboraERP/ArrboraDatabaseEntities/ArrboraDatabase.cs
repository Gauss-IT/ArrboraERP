namespace ArrboraERP.ArrboraDatabaseEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArrboraDatabase : DbContext
    {
        public ArrboraDatabase()
            : base("name=ArrboraDatabase")
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentUnit> PaymentUnits { get; set; }
        public virtual DbSet<ProductDelivery> ProductDeliveries { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchasePrice> PurchasePrices { get; set; }
        public virtual DbSet<SalesManagement> SalesManagements { get; set; }
        public virtual DbSet<SellingPrice> SellingPrices { get; set; }
        public virtual DbSet<ProductOverview> ProductOverviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PaymentUnit>()
            //    .Property(e => e.Note)
            //    .IsUnicode(false);
        }
    }
}
