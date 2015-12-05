using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrbora.Data.Scripts
{
    public static class Scripts
    {
        /// <summary>
        /// Sql command to get all products
        /// </summary>
        public static readonly string SqlGetAllProducts = "SELECT" +
            " ProductID, Brand, Model, VIN, EnteriourColour,ExteriourColour,ModelYear," +
            " DLPNetto, DLPBrutto, FileName, SoldNotSold, Seller,Buyer" +
            " FROM Products";       
    }
}
