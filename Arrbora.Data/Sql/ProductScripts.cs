using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrbora.Data.Sql
{
    public static class ProductScripts
    {
        
        /// <summary>
        /// Sql to get a products detail by Id
        /// </summary>
        public static readonly string sqlGetProductById = "SELECT" +
            " ProductID, Brand, Model, VIN, EnteriourColour, ExteriourColour, ModelYear," +
            " DLPNetto, DLPBrutto" +
            " FROM Products WHERE ProductID = @ProductID";

        /// <summary>
        /// Sql command to get all products
        /// </summary>
        public static readonly string sqlGetAllProducts = "SELECT" +
            " ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto" +
            " FROM Products";

        /// <summary>
        /// sql to insert a product detail
        /// </summary>
        public static readonly string sqlInsertProduct = "INSERT INTO" +
            " Products(Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto)" +
            " Values(@Brand, @Model, @VIN, @EnteriourColour,@ExteriourColour,@ModelYear," +
            " @DLPNetto, @DLPBrutto)";

        /// <summary>
        /// sql to search for products
        /// </summary>
        public static readonly string sqlSearchProducts = "SELECT " +
            " Products(ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto)" +
            " FROM Products WHERE (@Brand Is NULL OR @Brand = Brand) OR" +
            " (@Model Is NULL OR @Model = Model)";

        /// <summary>
        /// sql to update product details
        /// </summary>
        public static readonly string sqlUpdateProduct = "UPDATE Products " +
            " Set [Brand] = @Brand, [Model] = @Model, [VIN] = @VIN, [EnteriourColour] = @EnteriourColour, " +
            " [ExteriourColour] = @ExteriourColour, [ModelYear] = @ModelYear, [DLPNetto] = @DLPNetto "+
            " [DLPBrutto] = @DLPBrutto  " +
            " WHERE ([ProductID] = @ProductID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteProduct = "Delete From Products Where (ProductID = @ProductID)";
    }
}
