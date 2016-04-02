/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.SQLLite.DataModel;
using System.Data;

namespace Arrbora.Data.SQLLite.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for Product Delivery Access
    /// </summary>
    public interface IProductDeliveryAccess
    {
        /// <summary>
        /// Method to get a product Delivery
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetProductDeliveryById(int Id);

        /// <summary>
        /// Method to get all selling prices
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllProductDeliveries();

        /// <summary>
        /// Method to create new selling price
        /// </summary>
        /// <param name="productDelivery">club member model</param>
        /// <returns>true or false</returns>
        bool AddProductDelivery(ProductDeliveryDataModel productDelivery);

        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>productDeliveryID of the inserted row</returns>
        int AddEmptyProductDelivery();

        /// <summary>
        /// Method to update selling price details
        /// </summary>
        /// <param name="productDelivery">Selling Price</param>
        /// <returns></returns>
        bool UpdateProductDelivery(ProductDeliveryDataModel productDelivery);

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="productDeliveryID">selling price id</param>
        /// <returns>true / false</returns>
        bool DeleteProductDeliveryByID(int productDeliveryID);

        /// <summary>
        /// Converts a Data row from the database table to selling price model
        /// </summary>
        /// <param name="productDeliveryRow"></param>
        /// <returns></returns>
        ProductDeliveryDataModel ConvertToDataModel(DataRow productDeliveryRow);
    }
}
