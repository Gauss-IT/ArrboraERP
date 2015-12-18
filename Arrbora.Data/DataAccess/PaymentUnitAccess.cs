/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;

namespace Arrbora.Data.DataAccess
{
    public class PaymentUnitAccess : ConnectionAccess, IPaymentUnitAccess
    {
        public bool AddPaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            throw new NotImplementedException();
        }

        public bool DeletePaymentUnitByID(int paymentUnitID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllPaymentUnits()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllPaymentUnitsForPayment(int paymentID)
        {
            throw new NotImplementedException();
        }

        public DataRow GetPaymentUnitById(int PaymentUnitID)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            throw new NotImplementedException();
        }
    }
}
