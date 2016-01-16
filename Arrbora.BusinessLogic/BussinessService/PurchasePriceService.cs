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
    /// Implementation of the purchase price service
    /// </summary>
    public class PurchasePriceService : IPurchasePriceService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private IPurchasePriceAccess purchasePriceAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public PurchasePriceService()
        {
            purchasePriceAccess = new PurchasePriceAccess();
        }

        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetPurchasePriceById(int purchasePriceID)
        {
            return purchasePriceAccess.GetPurchasePriceById(purchasePriceID);
        }

        /// <summary>
        /// Method to get all payment units
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllPurchasePrices()
        {
            return purchasePriceAccess.GetAllPurchasePrices();
        }

        /// <summary>
        /// Method to create new payment unit
        /// </summary>
        /// <param name="purchasePrice">payment unit model</param>
        /// <returns>true or false</returns>
        public bool AddPurchasePrice(PurchasePriceDataModel purchasePrice)
        {
            return purchasePriceAccess.AddPurchasePrice(purchasePrice);
        }

        /// <summary>
        /// Method to update payment unit details
        /// </summary>
        /// <param name="purchasePrice">payment unit model</param>
        /// <returns></returns>
        public bool UpdatePurchasePrice(PurchasePriceDataModel purchasePrice)
        {
            return purchasePriceAccess.UpdatePurchasePrice(purchasePrice);
        }

        /// <summary>
        /// Method to delete a payment unit
        /// </summary>
        /// <param name="purchasePriceID">member id</param>
        /// <returns>true / false</returns>
        public bool DeletePurchasePriceByID(int purchasePriceID)
        {
            return purchasePriceAccess.DeletePurchasePriceByID(purchasePriceID);
        }


        /// <summary>
        /// Converts a Data row from the database table to payment unit model
        /// </summary>
        /// <param name="purchasePriceRow"></param>
        /// <returns></returns>
        public PurchasePriceDataModel ConvertToDataModel(DataRow purchasePriceRow)
        {
            return purchasePriceAccess.ConvertToDataModel(purchasePriceRow);
        }

    }
}
