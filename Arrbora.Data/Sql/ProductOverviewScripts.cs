/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.Sql
{
    public static class ProductOverviewScripts
    {
        /// <summary>
        /// Sql to get a products overview by Id
        /// </summary>
        public static readonly string sqlGetProductOverviewById = "SELECT" +
            " SalesManagementID, Brand, Model, VIN, DateOfPurchase, DateOfSale, TotalPurchase, TotalSelling, PaymentTotal" +           
            " FROM ProductOverview WHERE SalesManagementID = @SalesManagementID";

        /// <summary>
        /// Sql command to get all product overviews
        /// </summary>
        public static readonly string sqlGetAllProductOverview = "SELECT" +
            " SalesManagementID, Brand, Model, VIN, DateOfPurchase, DateOfSale, TotalPurchase, TotalSelling, PaymentTotal" +
            " FROM ProductOverview";

        /// <summary>
        /// sql to search in a product overview products
        /// </summary>
        public static readonly string sqlSearchProductOverview = "SELECT " +
            " SalesManagementID, Brand, Model, VIN, DateOfPurchase, DateOfSale, TotalPurchase, TotalSelling, PaymentTotal" +
            " FROM ProductOverview WHERE (@Brand Is NULL OR @Brand = Brand) AND (@Model Is NULL OR @Model = Model)";
    }
}
