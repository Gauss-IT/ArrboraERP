/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess;

namespace Arrbora.Data.BussinessService
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private IProductAccess productAccess;
        
        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public ProductService()
        {
            productAccess = new ProductAccess();
        }
        /// <summary>
        /// Method to get a single product
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetProductById(int Id)
        {
            return productAccess.GetProductById(Id);
        }

        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllProducts()
        {
            return productAccess.GetAllProducts();
        }

        /// <summary>
        /// Method to search club products by parameters
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable SearchProducts()
        {
            return productAccess.SearchProducts();
        }

        /// <summary>
        /// Method to create new product
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        public bool AddProduct(ProductDataModel product)
        {
            return productAccess.AddProduct(product);
        }

        /// <summary>
        /// Method to updateproduct details
        /// </summary>
        /// <param name="product">club member</param>
        /// <returns></returns>
        public bool UpdateProduct(ProductDataModel product)
        {
            return productAccess.UpdateProduct(product);
        }

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        public bool DeleteProductByID(int id)
        {
            return productAccess.DeleteProductByID(id);
        }
    }
}
