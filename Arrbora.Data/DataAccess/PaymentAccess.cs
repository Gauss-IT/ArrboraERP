/// <summary>
/// Copyright Arrbora DOO
/// </summary>
/// 

using System.Data;
using System.Data.OleDb;
using Arrbora.Data.Sql;
using Arrbora.Data.DataAccess.Interfaces;
using Arrbora.Data.DataModel;
using System;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Class for the payment table
    /// </summary>
    public class PaymentAccess : ConnectionAccess, IPaymentAccess
    {
        public int AddEmptyPayment()
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentScripts.sqlInsertPayment;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentTotal", DBNull.Value);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();

                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                if (rowsAffected == 0) result = -1;
                else
                {
                    oleDbCommand.CommandText = GeneralScripts.sqlGetIdentityOfInsertedRow;
                    result = (int)oleDbCommand.ExecuteScalar();
                }
                oleDbCommand.Connection.Close();

                return result;
            }
        }

        public bool AddPayment(PaymentDataModel payment)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentScripts.sqlInsertPayment;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentTotal", payment.PaymentTotal);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        public PaymentDataModel ConvertToDataModel(DataRow paymentRow)
        {
            var result = new PaymentDataModel();
            result.PaymentID = paymentRow.Field<int>("PaymentID");
            result.PaymentTotal = paymentRow.Field<decimal>("PaymentTotal");
            return result;
        }

        public bool DeletePaymentByID(int paymentID)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentScripts.sqlDeletePayment;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentID", paymentID);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        public DataTable GetAllPayments()
        {
            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(ConnectionString);
                var state = oleDbDataAdapter.SelectCommand.Connection.State;
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = PaymentScripts.sqlGetAllPayments;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetAllPaymentUnitsForPayment(int paymentID)
        {
            var paymentUnitAccess = new PaymentUnitAccess();
            return paymentUnitAccess.GetAllPaymentUnitsForPayment(paymentID);
        }

        public DataRow GetPaymentById(int paymentID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = PaymentScripts.sqlGetPaymentById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PaymentID", paymentID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            return dataRow;
        }

        public bool UpdatePayment(PaymentDataModel payment)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentScripts.sqlUpdatePayment;

                // Add the input parameters to the parameter collection                               
                oleDbCommand.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                oleDbCommand.Parameters.AddWithValue("@PaymentTotal", payment.PaymentTotal);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
