﻿/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Data;
using Arrbora.Data.SQLLite.DataModel;

namespace Arrbora.Data.SQLLite.DataAccess.Interfaces
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
        DataTable SearchProducts(object brand, object model);

        /// <summary>
        /// Method to create new product
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddProduct(ProductDataModel product);

        /// <summary>
        /// Method to create new empty product
        /// </summary>
        /// <returns>ProductID of the inserted row</returns>
        int AddEmptyProduct();

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

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="paymentUnitRow"></param>
        /// <returns></returns>
        ProductDataModel ConvertToDataModel(DataRow productRow);
    }
}
