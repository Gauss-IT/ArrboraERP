/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.SQLLite.Sql
{
    public static class SalesManagementScripts
    {
        /// <summary>
        /// Sql to get a product management by Id
        /// </summary>
        public static readonly string sqlGetSalesManagementById = "SELECT" +
            " SalesManagementID, ProductID, ProductDeliveryID, SellingPriceID, PaymentID, PurchasePriceID" +
            " FROM SalesManagement WHERE SalesManagementID = @SalesManagementID";

        /// <summary>
        /// Sql command to get all product management entries
        /// </summary>
        public static readonly string sqlGetAllSalesManagement = "SELECT" +
            " SalesManagementID, ProductID, ProductDeliveryID, SellingPriceID, PaymentID, PurchasePriceID" +
            " FROM SalesManagement";

        /// <summary>
        /// sql to search in product management table
        /// </summary>
        public static readonly string sqlSearchSalesManagement = "SELECT " +
            " SalesManagementID, ProductID, ProductDeliveryID, SellingPriceID, PaymentID, PurchasePriceID" +
            " FROM SalesManagement WHERE (@ProductID Is NULL OR @ProductID = ProductID) OR" +
            " (@ProductDeliveryID Is NULL OR @ProductDeliveryID = ProductDeliveryID)" +
            " OR (@SellingPriceID Is NULL OR @SellingPriceID = SellingPriceID)" +
            " OR (@PaymentID Is NULL OR @PaymentID = PaymentID)" +            
            " OR (@PurchasePriceID Is NULL OR @PurchasePriceID = PurchasePriceID)";

        /// <summary>
        /// sql to insert a product management row
        /// </summary>
        public static readonly string sqlInsertSalesManagement = "INSERT INTO" +
            " SalesManagement(ProductID, ProductDeliveryID, SellingPriceID, PaymentID, PurchasePriceID)" +
            " Values(@ProductID, @ProductDeliveryID, @SellingPriceID, @PaymentID, @PurchasePriceID)";
        /// <summary>
        /// sql to update product details
        /// </summary>
        public static readonly string sqlUpdateSalesManagement = "UPDATE SalesManagement " +
            " Set [ProductID] = @ProductID, [ProductDeliveryID] = @ProductDeliveryID,"+
            " [SellingPriceID] = @SellingPriceID, [PaymentID] = @PaymentID, [PurchasePriceID] = @PurchasePriceID " +
            " WHERE ([SalesManagementID] = @SalesManagementID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteSalesManagement = 
                    "DELETE FROM SalesManagement WHERE (SalesManagementID = @SalesManagementID)";
    }
}
