/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.BusinessLogic.BussinessService.Interfaces;


namespace Arrbora.BusinessLogic.BussinessService
{
    /// <summary>
    /// Implementation of the selling price service
    /// </summary>
    public class SellingPriceService : ISellingPriceService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private ISellingPriceAccess sellingPriceAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public SellingPriceService()
        {
            sellingPriceAccess = new SellingPriceAccess();
        }

        /// <summary>
        /// Method to get a selling price
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetSellingPriceById(int Id)
        {
            return sellingPriceAccess.GetSellingPriceById(Id);
        }

        /// <summary>
        /// Method to get all selling prices
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllSellingPrices()
        {
            return sellingPriceAccess.GetAllSellingPrices();
        }

        /// <summary>
        /// Method to create new selling price
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        public bool AddSellingPrice(SellingPriceDataModel sellingPrice)
        {
            return sellingPriceAccess.AddSellingPrice(sellingPrice);
        }

        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>SellingPriceID of the inserted row</returns>
        public int AddEmptySellingPrice()
        {
            return sellingPriceAccess.AddEmptySellingPrice();
        }

        /// <summary>
        /// Method to update selling price details
        /// </summary>
        /// <param name="sellingPrice">Selling Price</param>
        /// <returns></returns>
        public bool UpdateSellingPrice(SellingPriceDataModel sellingPrice)
        {
            return sellingPriceAccess.UpdateSellingPrice(sellingPrice);
        }

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="id">selling price id</param>
        /// <returns>true / false</returns>
        public bool DeleteSellingPriceByID(int id)
        {
            return sellingPriceAccess.DeleteSellingPriceByID(id);
        }

        /// <summary>
        /// Converts a Data row from the database table to selling price model
        /// </summary>
        /// <param name="sellingPriceRow"></param>
        /// <returns></returns>
        public SellingPriceDataModel ConvertToDataModel(DataRow sellingPriceRow)
        {
            return sellingPriceAccess.ConvertToDataModel(sellingPriceRow);
        }
    }
}
