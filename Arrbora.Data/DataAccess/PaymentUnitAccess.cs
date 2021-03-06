﻿/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.Sql;
using System.Data.OleDb;
using Arrbora.Data.DataAccess.Interfaces;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Class for the payment unit table
    /// </summary>
    public class PaymentUnitAccess : ConnectionAccess, IPaymentUnitAccess
    {
        /// <summary>
        /// Add a payment unit to the table
        /// </summary>
        /// <param name="paymentUnit"></param>
        /// <returns></returns>
        public int AddEmptyPaymentUnit(int paymentID)
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentUnitScripts.sqlInsertPaymentUnit;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentID", paymentID);
                oleDbCommand.Parameters.AddWithValue("@PaymentUnitDate", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Amount", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentType", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PayedBy", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Note", DBNull.Value);

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
        /// <summary>
        /// Add a payment unit to the table
        /// </summary>
        /// <param name="paymentUnit"></param>
        /// <returns></returns>
        public bool AddPaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentUnitScripts.sqlInsertPaymentUnit;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentID", paymentUnit.PaymentID ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentUnitDate", paymentUnit.PaymentUnitDate ==null ? 
                    (object)DBNull.Value: paymentUnit.PaymentUnitDate.Value.ToOADate());
                oleDbCommand.Parameters.AddWithValue("@Amount", paymentUnit.Amount ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentType", paymentUnit.PaymentType ?? (object)DBNull.Value); 
                oleDbCommand.Parameters.AddWithValue("@PayedBy", paymentUnit.PayedBy ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Note", paymentUnit.Note ?? (object)DBNull.Value);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Delete a payment unit by ID
        /// </summary>
        /// <param name="paymentUnitID"></param>
        /// <returns></returns>
        public bool DeletePaymentUnitByID(int paymentUnitID)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentUnitScripts.sqlDeletePaymentUnit;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@PaymentUnitID", paymentUnitID);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Get the table of all payment units
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPaymentUnits()
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
                oleDbDataAdapter.SelectCommand.CommandText = PaymentUnitScripts.sqlGetAllPaymentUnits;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Gets a table with all the payment units for a given payment
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public DataTable GetAllPaymentUnitsForPayment(int paymentID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = PaymentUnitScripts.sqlGetAllPaymentUnitsForPayment;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PaymentID", paymentID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);               
            }
            return dataTable;
        }

        /// <summary>
        /// Gets a 
        /// </summary>
        /// <param name="PaymentUnitID"></param>
        /// <returns></returns>
        public DataRow GetPaymentUnitById(int paymentUnitID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = PaymentUnitScripts.sqlGetPaymentUnitById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PaymentUnitID", paymentUnitID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            return dataRow;
        }

        /// <summary>
        /// Update a payment unit
        /// </summary>
        /// <param name="paymentUnit"></param>
        /// <returns></returns>
        public bool UpdatePaymentUnit(PaymentUnitDataModel paymentUnit)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PaymentUnitScripts.sqlUpdatePaymentUnit;

                // Add the input parameters to the parameter collection                   
                oleDbCommand.Parameters.AddWithValue("@PaymentID", paymentUnit.PaymentID ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentUnitDate", paymentUnit.PaymentUnitDate ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Amount", paymentUnit.Amount ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentType", paymentUnit.PaymentType ?? (object)DBNull.Value); 
                oleDbCommand.Parameters.AddWithValue("@PayedBy", paymentUnit.PayedBy ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Note", paymentUnit.Note ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PaymentUnitID", paymentUnit.PaymentUnitID ?? (object)DBNull.Value);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }


        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="salesManagementRow"></param>
        /// <returns></returns>
        public PaymentUnitDataModel ConvertToDataModel(DataRow paymentUnitRow)
        {
            var result = new PaymentUnitDataModel();
            result.PaymentUnitID = paymentUnitRow.Field<int?>("PaymentUnitID");
            result.PaymentID= paymentUnitRow.Field<int?>("PaymentID");
            result.PaymentUnitDate = paymentUnitRow.Field<DateTime?>("PaymentUnitDate");
            result.Amount = paymentUnitRow.Field<decimal?>("Amount");
            result.PaymentType = paymentUnitRow.Field<string>("PaymentType");
            result.PayedBy = paymentUnitRow.Field<string>("PayedBy");
            result.Note = paymentUnitRow.Field<string>("Note");
            return result;
        }
    }
}
