/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.SQLLite.DataAccess.Interfaces;
using Arrbora.Data.SQLLite.DataModel;
using System.Data.OleDb;
using Arrbora.Data.SQLLite.Sql;

namespace Arrbora.Data.SQLLite.DataAccess
{
    /// <summary>
    /// Class for the payment unit table
    /// </summary>
    public class PurchasePriceAccess : ConnectionAccess, IPurchasePriceAccess
    {
        /// <summary>
        /// Method to create new payment unit
        /// </summary>
        /// <param name="purchasePrice">Purchase Price model</param>
        /// <returns>true or false</returns>
        public int AddEmptyPurchasePrice()
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PurchasePriceScripts.sqlInsertPurchasePrice;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@DistributorPrice", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@InternalTransport", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@KosovoCosts", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalPurchase", DBNull.Value);

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
        /// Method to create new payment unit
        /// </summary>
        /// <param name="purchasePrice">Purchase Price model</param>
        /// <returns>true or false</returns>
        public bool AddPurchasePrice(PurchasePriceDataModel purchasePrice)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PurchasePriceScripts.sqlInsertPurchasePrice;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@DistributorPrice", purchasePrice.DistributorPrice ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", purchasePrice.Transport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@InternalTransport", purchasePrice.InternalTransport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@KosovoCosts", purchasePrice.KosovoCosts ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", purchasePrice.Other1 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", purchasePrice.Other2 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalPurchase", purchasePrice.TotalPurchase ?? (object)DBNull.Value);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Converts a Data row from the database table to payment unit model
        /// </summary>
        /// <param name="purchasePriceRow"></param>
        /// <returns></returns>
        public PurchasePriceDataModel ConvertToDataModel(DataRow purchasePriceRow)
        {
            var result = new PurchasePriceDataModel();

            result.PurchasePriceID = purchasePriceRow.Field<int>("PurchasePriceID");
            result.DistributorPrice = purchasePriceRow.Field<decimal?>("DistributorPrice");
            result.Transport = purchasePriceRow.Field<decimal?>("Transport");
            result.InternalTransport = purchasePriceRow.Field<decimal?>("InternalTransport");
            result.KosovoCosts = purchasePriceRow.Field<decimal?>("KosovoCosts");
            result.Other1 = purchasePriceRow.Field<decimal?>("Other1");
            result.Other2 = purchasePriceRow.Field<decimal?>("Other2");
            result.TotalPurchase = purchasePriceRow.Field<decimal?>("TotalPurchase");

            return result;
        }

        /// <summary>
        /// Method to delete a payment unit
        /// </summary>
        /// <param name="paymentUnitID">member id</param>
        /// <returns>true / false</returns>
        public bool DeletePurchasePriceByID(int purchasePriceID)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = PurchasePriceScripts.sqlDeletePurchasePrice;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@PurchasePriceID", purchasePriceID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to get all payment units
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllPurchasePrices()
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
                oleDbDataAdapter.SelectCommand.CommandText = PurchasePriceScripts.sqlGetAllPurchasePrices;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to get a single payment unit
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetPurchasePriceById(int purchasePriceID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = PurchasePriceScripts.sqlGetPurchasePricetById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PurchasePriceID", purchasePriceID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            return dataRow;
        }

        /// <summary>
        /// Method to update payment unit details
        /// </summary>
        /// <param name="purchasePrice">Purchase Price model</param>
        /// <returns></returns>
        public bool UpdatePurchasePrice(PurchasePriceDataModel purchasePrice)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = PurchasePriceScripts.sqlUpdatePurchasePrice;

                // Add the input parameters to the parameter collection
                oleDbCommand.Parameters.AddWithValue("@DistributorPrice", purchasePrice.DistributorPrice ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", purchasePrice.Transport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@InternalTransport", purchasePrice.InternalTransport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@KosovoCosts", purchasePrice.KosovoCosts ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", purchasePrice.Other1 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", purchasePrice.Other2 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalPurchase", purchasePrice.TotalPurchase ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@PurchasePriceID", purchasePrice.PurchasePriceID);
                
                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
