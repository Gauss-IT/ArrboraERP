/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.SQLLite.DataModel;
using System.Data;

namespace Arrbora.Data.SQLLite.DataAccess.Interfaces
{
    /// <summary>
    /// Interface ISellingPriceAccess
    /// </summary>
    public interface ISellingPriceAccess
    {
        /// <summary>
        /// Method to get a selling price
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetSellingPriceById(int Id);

        /// <summary>
        /// Method to get all selling prices
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllSellingPrices();

        /// <summary>
        /// Method to create new selling price
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddSellingPrice(SellingPriceDataModel sellingPrice);

        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>SellingPriceID of the inserted row</returns>
        int AddEmptySellingPrice();

        /// <summary>
        /// Method to update selling price details
        /// </summary>
        /// <param name="sellingPrice">Selling Price</param>
        /// <returns></returns>
        bool UpdateSellingPrice(SellingPriceDataModel sellingPrice);

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="id">selling price id</param>
        /// <returns>true / false</returns>
        bool DeleteSellingPriceByID(int id);

        /// <summary>
        /// Converts a Data row from the database table to selling price model
        /// </summary>
        /// <param name="sellingPriceRow"></param>
        /// <returns></returns>
        SellingPriceDataModel ConvertToDataModel(DataRow sellingPriceRow);
    }
}
