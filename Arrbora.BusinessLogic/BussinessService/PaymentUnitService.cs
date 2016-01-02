/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.BussinessService.Interfaces;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataAccess;

namespace Arrbora.Data.BussinessService
{
    public class PaymentUnitService : IPaymentUnitService
    {
        /// <summary>
        /// Interface of Product Access
        /// </summary>
        private IPaymentUnitAccess paymentUnitAccess;

        /// <summary>
        /// Instantiate an instance of the class
        /// </summary>
        public PaymentUnitService()
        {
            paymentUnitAccess = new PaymentUnitAccess();
        }

        public bool AddPaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            return paymentUnitAccess.AddPaymentUnit(paymentUnit);
        }

        public bool DeletePaymentUnitByID(int paymentUnitID)
        {
            return paymentUnitAccess.DeletePaymentUnitByID(paymentUnitID);
        }

        public DataTable GetAllPaymentUnits()
        {
            return paymentUnitAccess.GetAllPaymentUnits();
        }

        public DataTable GetAllPaymentUnitsForPayment(int paymentID)
        {
            return paymentUnitAccess.GetAllPaymentUnitsForPayment(paymentID);
        }

        public DataRow GetPaymentUnitById(int paymentUnitID)
        {
            return paymentUnitAccess.GetPaymentUnitById(paymentUnitID);
        }

        public bool UpdatePaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            return paymentUnitAccess.UpdatePaymentUnit(paymentUnit);
        }

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        public PaymentUnitDataModel ConvertToDataModel(DataRow paymentUnitRow)
        {
            return paymentUnitAccess.ConvertToDataModel(paymentUnitRow);
        }
    }
}
