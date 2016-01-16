/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.DataModel;
using System.Data;

namespace Arrbora.BusinessLogic.BussinessService.Interfaces
{
    /// <summary>
    /// Interface for the payment service
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        DataRow GetPaymentById(int paymentID);

        /// <summary>
        /// Method to get all payments
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllPayments();

        /// <summary>
        /// Method to get all payment units that belong to one payment
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllPaymentUnitsForPayment(int paymentID);

        /// <summary>
        /// Method to create new payment
        /// </summary>
        /// <param name="payment">payment data model</param>
        /// <returns>true or false</returns>
        bool AddPayment(PaymentDataModel payment);

        /// <summary>
        /// Method to update payment unit details
        /// </summary>
        /// <param name="payment">payment model</param>
        /// <returns></returns>
        bool UpdatePayment(PaymentDataModel payment);

        /// <summary>
        /// Method to delete a payment
        /// </summary>
        /// <param name="paymentID">payment id</param>
        /// <returns>true / false</returns>
        bool DeletePaymentByID(int paymentID);

        /// <summary>
        /// Converts a Data row from the database table to payment model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        PaymentDataModel ConvertToDataModel(DataRow paymentUnitRow);
    }
}
