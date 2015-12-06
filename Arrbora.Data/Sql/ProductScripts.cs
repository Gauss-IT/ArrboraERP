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
            " DLPNetto, DLPBrutto, FileName, SoldNotSold, Seller,Buyer" +
            " FROM Products WHERE ProductID = @ProductID";

        /// <summary>
        /// Sql command to get all products
        /// </summary>
        public static readonly string sqlGetAllProducts = "SELECT" +
            " ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto, FileName, SoldNotSold, Seller,Buyer" +
            " FROM Products";

        /// <summary>
        /// sql to insert a product detail
        /// </summary>
        public static readonly string sqlInsertProduct = "INSERT INTO" +
            " Products(ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto, FileName, SoldNotSold, Seller,Buyer)" +
            " Values(@ProductID, @Brand, @Model, @VIN, @EnteriourColour,@ExteriourColour,@ModelYear," +
            " @DLPNetto, @DLPBrutto, @FileName, @SoldNotSold, @Seller,@Buyer)";

        /// <summary>
        /// sql to search for products
        /// </summary>
        public static readonly string sqlSearchProducts = "SELECT " +
            " Products(ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto, FileName, SoldNotSold, Seller,Buyer)" +
            " FROM Products WHERE (@Brand Is NULL OR @Brand = Brand) OR" +
            " (@Model Is NULL OR @Model = Model)";

        /// <summary>
        /// sql to update product details
        /// </summary>
        public static readonly string sqlUpdateProduct = "UPDATE ClubMembers " +
            " Set [Brand] = @Brand, [Model] = @Model, [VIN] = @VIN, [EnteriourColour] = @EnteriourColour, " +
            " [ExteriourColour] = @ExteriourColour, [ModelYear] = @ModelYear, [DLPNetto] = @DLPNetto "+
            " [DLPBrutto] = @DLPBrutto, [FileName] = @FileName, [SoldNotSold] = @SoldNotSold, [Seller] = @Seller, [Buyer] = @Buyer  " +
            " Where ([ProductID] = @ProductID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteClubMember = "Delete From ClubMember Where (Id = @Id)";
    }
}
