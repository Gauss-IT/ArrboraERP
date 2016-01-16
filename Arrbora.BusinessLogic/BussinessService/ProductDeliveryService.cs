/// <summary>
/// Copyright Arrbora DOO
/// </summary>


using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.BusinessLogic.BussinessService
{
    /// <summary>
    /// Implementation for Product Delivery Service
    /// </summary>
    public class ProductDeliveryService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private IProductDeliveryAccess productDeliveryAccess;
        
        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public ProductDeliveryService()
        {
            productDeliveryAccess = new ProductDeliveryAccess();
        }

        /// <summary>
        /// Method to get a product Delivery
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetProductDeliveryById(int Id)
        {
            return productDeliveryAccess.GetProductDeliveryById(Id);
        }

        /// <summary>
        /// Method to get all selling prices
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllProductDeliveries()
        {
            return productDeliveryAccess.GetAllProductDeliveries();
        }

        /// <summary>
        /// Method to create new selling price
        /// </summary>
        /// <param name="productDelivery">club member model</param>
        /// <returns>true or false</returns>
        bool AddProductDelivery(ProductDeliveryDataModel productDelivery)
        {
            return productDeliveryAccess.AddProductDelivery(productDelivery);
        }

        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>productDeliveryID of the inserted row</returns>
        int AddEmptyProductDelivery()
        {
            return productDeliveryAccess.AddEmptyProductDelivery();
        }

        /// <summary>
        /// Method to update selling price details
        /// </summary>
        /// <param name="productDelivery">Selling Price</param>
        /// <returns></returns>
        bool UpdateProductDelivery(ProductDeliveryDataModel productDelivery)
        {
            return productDeliveryAccess.UpdateProductDelivery(productDelivery);
        }

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="productDeliveryID">selling price id</param>
        /// <returns>true / false</returns>
        bool DeleteProductDeliveryByID(int productDeliveryID)
        {
            return productDeliveryAccess.DeleteProductDeliveryByID(productDeliveryID);
        }

        /// <summary>
        /// Converts a Data row from the database table to selling price model
        /// </summary>
        /// <param name="productDeliveryRow"></param>
        /// <returns></returns>
        ProductDeliveryDataModel ConvertToDataModel(DataRow productDeliveryRow)
        {
            return productDeliveryAccess.ConvertToDataModel(productDeliveryRow);
        }
    }
}
