
using Arrbora.Data.DataModel;
/// <summary>
/// Copyright Arrbora DOO
/// </summary>
using System.Data;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Interface for the payment unit table
    /// </summary>
    public interface IPaymentUnitAccess
    {
        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetPaymentUnitById(int PaymentUnitID);

        /// <summary>
        /// Method to get all payment units
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllPaymentUnits();

        /// <summary>
        /// Method to get all payment units that belong to one payment
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllPaymentUnitsForPayment(int paymentID);

        /// <summary>
        /// Method to create new payment unit
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        bool AddPaymentUnit(PaymentUnitDataModel paymentUnit);

        /// <summary>
        /// Method to updateproduct details
        /// </summary>
        /// <param name="product">club member</param>
        /// <returns></returns>
        bool UpdatePaymentUnit(PaymentUnitDataModel paymentUnit);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeletePaymentUnitByID(int paymentUnitID);
    }
}
