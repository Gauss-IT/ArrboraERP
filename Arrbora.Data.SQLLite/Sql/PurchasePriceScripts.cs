/// <summary>
/// Copyright Arrbora DOO
/// </summary>


namespace Arrbora.Data.SQLLite.Sql
{
    /// <summary>
    /// A class that holds Sql scripts for the Purchase price table
    /// </summary>
    public static class PurchasePriceScripts
    {
        /// <summary>
        /// Sql to get a purchase price by Id
        /// </summary>
        public static readonly string sqlGetPurchasePricetById = "SELECT" +
            " PurchasePriceID,DistributorPrice, Transport, InternalTransport,KosovoCosts, Other1, Other2, TotalPurchase" +
            " FROM PurchasePrice WHERE PurchasePriceID = @PurchasePriceID";

        /// <summary>
        /// Sql command to get all purchase prices
        /// </summary>
        public static readonly string sqlGetAllPurchasePrices = "SELECT" +
            " PurchasePriceID, DistributorPrice, Transport, InternalTransport,KosovoCosts, Other1, Other2, TotalPurchase" +
            " FROM PurchasePrice";

        /// <summary>
        /// sql to insert a purchase price
        /// </summary>
        public static readonly string sqlInsertPurchasePrice = "INSERT INTO" +
            " PurchasePrice(DistributorPrice, Transport, InternalTransport,KosovoCosts, Other1, Other2, TotalPurchase)" +
            " Values(@DistributorPrice, @Transport, @InternalTransport, @KosovoCosts, @Other1, @Other2, @TotalPurchase)";

        /// <summary>
        /// sql to update a purchase price
        /// </summary>
        public static readonly string sqlUpdatePurchasePrice = "UPDATE PurchasePrice " +
            " Set [DistributorPrice] = @DistributorPrice, [Transport] = @Transport, [InternalTransport] = @InternalTransport," +
            " [KosovoCosts]= @KosovoCosts, [Other1] = @Other1, [Other2]= @Other2, [TotalPurchase] = @TotalPurchase" +
            " WHERE ([PurchasePriceID] = @PurchasePriceID)";

        /// <summary>
        /// sql to delete a purchase price
        /// </summary>
        public static readonly string sqlDeletePurchasePrice =
            "DELETE FROM PurchasePrice WHERE (PurchasePriceID = @PurchasePriceID)";
    }
}
