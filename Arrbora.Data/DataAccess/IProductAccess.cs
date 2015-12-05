/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Data;
using Arrbora.Data.DataModel;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Interface IClubMemberAccess
    /// </summary>
    public interface IProductAccess
    {
        /// <summary>
        /// Method to get a single product
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetProductById(int Id);

        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllProducts();

        /// <summary>
        /// Method to search club products by parameters
        /// </summary>
        /// <returns>Data table</returns>
        DataTable SearchProducts();

        /// <summary>
        /// Method to create new product
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddProduct(ProductDataModel product);

        /// <summary>
        /// Method to updateproduct details
        /// </summary>
        /// <param name="product">club member</param>
        /// <returns></returns>
        bool UpdateProduct(ProductDataModel product);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeleteProductByID(int id);
    }
}
