/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.Sql
{
    /// <summary>
    /// A class that holds Sql scripts for the Selling price table
    /// </summary>
    public class SellingPriceScripts
    {
        /// <summary>
        /// Sql to get a selling price by Id
        /// </summary>
        public static readonly string sqlGetSellingPricetById = "SELECT" +
            " Price, Transport, Other1, Other2, TotalSelling" +
            " FROM SellingPrice WHERE SellingPriceID = @SellingPriceID";

        /// <summary>
        /// Sql command to get all selling prices
        /// </summary>
        public static readonly string sqlGetAllSellingPrices = "SELECT" +
            " Price, Transport, Other1, Other2, TotalSelling" +
            " FROM SellingPrice";

        /// <summary>
        /// sql to insert a selling price
        /// </summary>
        public static readonly string sqlInsertSellingPrice = "INSERT INTO" +
            " SellingPrice(Price, Transport, Other1, Other2, TotalSelling)" +
            " Values(@Price, @Transport, @Other1, @Other2, @TotalSelling)";

        /// <summary>
        /// sql to update a selling price
        /// </summary>
        public static readonly string sqlUpdateSellingPrice = "UPDATE SellingPrice " +
            " Set [Price] = @Price, [Transport] = @Transport, [Other1] = @Other1," +
            " [Other2]= @Other2, [TotalSelling] = @TotalSelling" +
            " WHERE ([SellingPriceID] = @SellingPriceID)";

        /// <summary>
        /// sql to delete a selling price
        /// </summary>
        public static readonly string sqlDeleteSellingPrice =
            "DELETE FROM SellingPrice WHERE (SellingPriceID = @SellingPriceID)";
    }
}
