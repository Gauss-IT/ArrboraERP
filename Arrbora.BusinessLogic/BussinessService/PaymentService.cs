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
    /// Implementation of the payment service
    /// </summary>
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private IPaymentAccess paymentAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public PaymentService()
        {
            paymentAccess = new PaymentAccess();
        }

        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetPaymentById(int paymentID)
        {
            return paymentAccess.GetPaymentById(paymentID);
        }

        /// <summary>
        /// Method to get all payments
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllPayments()
        {
            return paymentAccess.GetAllPayments();
        }

        /// <summary>
        /// Method to get all payment units that belong to one payment
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllPaymentUnitsForPayment(int paymentID)
        {
            return paymentAccess.GetAllPaymentUnitsForPayment(paymentID);
        }

        /// <summary>
        /// Method to create new payment
        /// </summary>
        /// <param name="payment">payment data model</param>
        /// <returns>true or false</returns>
        public bool AddPayment(PaymentDataModel payment)
        {
            return paymentAccess.AddPayment(payment);
        }

        /// <summary>
        /// Method to update payment unit details
        /// </summary>
        /// <param name="payment">payment model</param>
        /// <returns></returns>
        public bool UpdatePayment(PaymentDataModel payment)
        {
            return paymentAccess.UpdatePayment(payment);
        }

        /// <summary>
        /// Method to delete a payment
        /// </summary>
        /// <param name="paymentID">payment id</param>
        /// <returns>true / false</returns>
        public bool DeletePaymentByID(int paymentID)
        {
            return paymentAccess.DeletePaymentByID(paymentID);
        }

        /// <summary>
        /// Converts a Data row from the database table to payment model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        public PaymentDataModel ConvertToDataModel(DataRow paymentUnitRow)
        {
            return paymentAccess.ConvertToDataModel(paymentUnitRow);
        }
    }
}
