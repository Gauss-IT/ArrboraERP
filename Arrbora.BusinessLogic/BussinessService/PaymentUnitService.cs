/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.BussinessService.Interfaces;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataAccess;

namespace Arrbora.BusinessLogic.BussinessService
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

        public int AddEmptyPaymentUnit(int paymentID)
        {
            return paymentUnitAccess.AddEmptyPaymentUnit(paymentID);
        }

        public bool AddPaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            return paymentUnitAccess.AddPaymentUnit(paymentUnit);
        }

        public bool DeletePaymentUnitByID(int paymentUnitID)
        {
            return paymentUnitAccess.DeletePaymentUnitByID(paymentUnitID);
        }

        public bool DeleteAllPaymentUnitsForPaymentID(int paymentID)
        {
            int paymentUnitID;
            var success = true;
            var paymentUnits = paymentUnitAccess.GetAllPaymentUnitsForPayment(paymentID);
            for (var i=0; i< paymentUnits.Rows.Count; i++)
            {
                paymentUnitID = paymentUnits.Rows[i].Field<int>("PaymentUnitID");
                success = success && paymentUnitAccess.DeletePaymentUnitByID(paymentUnitID);
            }

            return success;
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

        public bool UpdatePaymentUnitDataTable(DataTable paymentUnitTable)
        {
            bool value = true;
            foreach (DataRow row in paymentUnitTable.Rows)
            {
                if (row["PaymentUnitID"] == DBNull.Value)
                   value = AddPaymentUnit(ConvertToDataModel(row)) && value;
                else
                    value = UpdatePaymentUnit(ConvertToDataModel(row)) && value;
            }
            return value;
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
