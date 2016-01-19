/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.Sql
{
    /// <summary>
    /// A class that holds Sql scripts for the product delivery table
    /// </summary>
    public static class ProductDeliveryScripts
    {
        /// <summary>
        /// Sql to get a products detail by Id
        /// </summary>
        public static readonly string sqlGetProductDeliveryById = "SELECT" +
            " ProductDeliveryID,DateOfPurchase, LandOfOrigin, CurrentLocation, DateOfSale, LandOfDestination, ProductStatus, Seller," +
            " Buyer, ProductWebsite, ProductAttachment" +
            " FROM ProductDelivery WHERE ProductDeliveryID = @ProductDeliveryID";

        /// <summary>
        /// Sql command to get all products
        /// </summary>
        public static readonly string sqlGetAllProductDeliveries = "SELECT" +
            " DateOfPurchase, LandOfOrigin, CurrentLocation, DateOfSale, LandOfDestination, ProductStatus, Seller," +
            " Buyer, ProductWebsite, ProductAttachment" +
            " FROM ProductDelivery";

        /// <summary>
        /// sql to insert a product detail
        /// </summary>
        public static readonly string sqlInsertProductDelivery = "INSERT INTO" +
            " ProductDelivery(DateOfPurchase, LandOfOrigin, CurrentLocation, DateOfSale, LandOfDestination, ProductStatus, Seller," +
            " Buyer, ProductWebsite, ProductAttachment)" +
            " Values(@DateOfPurchase, @LandOfOrigin, @CurrentLocation, @DateOfSale,@LandOfDestination,@ProductStatus,@Seller," +
            " @Buyer, @ProductWebsite, @ProductAttachment)";

        /// <summary>
        /// sql to update product details
        /// </summary>
        public static readonly string sqlUpdateProductDelivery = "UPDATE ProductDelivery " +
            " Set [DateOfPurchase] = @DateOfPurchase, [LandOfOrigin] = @LandOfOrigin, [CurrentLocation] = @CurrentLocation,"+
            " [DateOfSale] = @DateOfSale, [LandOfDestination] = @LandOfDestination, [ProductStatus] = @ProductStatus" +
            " [Seller] = @Seller, [Buyer] = @Buyer, [ProductWebsite] = @ProductWebsite, [ProductAttachment] = @ProductAttachment" +
            " WHERE ([ProductDeliveryID] = @ProductDeliveryID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteProductDelivery = 
            "DELETE FROM ProductDelivery WHERE (ProductDeliveryID = @ProductDeliveryID)";
    }
}
