/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.BusinessLogic.BussinessService.Interfaces
{
    /// <summary>
    /// Interface for the purchase price service
    /// </summary>
    public interface IPurchasePriceService
    {
        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetPurchasePriceById(int purchasePriceID);

        /// <summary>
        /// Method to get all payment units
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllPurchasePrices();

        /// <summary>
        /// Method to create new payment unit
        /// </summary>
        /// <param name="purchasePrice">payment unit model</param>
        /// <returns>true or false</returns>
        int AddEmptyPurchasePrice();

        /// <summary>
        /// Method to create new payment unit
        /// </summary>
        /// <param name="purchasePrice">payment unit model</param>
        /// <returns>true or false</returns>
        bool AddPurchasePrice(PurchasePriceDataModel purchasePrice);

        /// <summary>
        /// Method to update payment unit details
        /// </summary>
        /// <param name="purchasePrice">payment unit model</param>
        /// <returns></returns>
        bool UpdatePurchasePrice(PurchasePriceDataModel purchasePrice);

        /// <summary>
        /// Method to delete a payment unit
        /// </summary>
        /// <param name="purchasePriceID">member id</param>
        /// <returns>true / false</returns>
        bool DeletePurchasePriceByID(int purchasePriceID);


        /// <summary>
        /// Converts a Data row from the database table to payment unit model
        /// </summary>
        /// <param name="purchasePriceRow"></param>
        /// <returns></returns>
        PurchasePriceDataModel ConvertToDataModel(DataRow purchasePriceRow);
    }
}
