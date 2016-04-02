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
    public class SalesManagementAccess : ConnectionAccess,ISalesManagementAccess
    {
        /// <summary>
        /// Add a sales management row into the table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public int AddSalesManagement(SalesManagementDataModel salesManagement)
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = SalesManagementScripts.sqlInsertSalesManagement;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@ProductID", salesManagement.ProductID);
                oleDbCommand.Parameters.AddWithValue("@ProductDeliveryID", salesManagement.ProductDeliveryID);
                oleDbCommand.Parameters.AddWithValue("@SellingPriceID", salesManagement.SellingPriceID);
                oleDbCommand.Parameters.AddWithValue("@PaymentID", salesManagement.PaymentID);
                oleDbCommand.Parameters.AddWithValue("@PurchasePriceID", salesManagement.PurchasePriceID);

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
        /// Delete a sales management row by ID
        /// </summary>
        /// <param name="SalesManagementID"></param>
        /// <returns></returns>
        public bool DeleteSalesManagementByID(int salesManagementID)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = SalesManagementScripts.sqlDeleteSalesManagement;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@SalesManagementID", salesManagementID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Get the table of all Sales management
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSalesManagement()
        {
            DataTable dataTable = new DataTable();
            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(ConnectionString);
                var state = oleDbDataAdapter.SelectCommand.Connection.State;
                //oleDbDataAdapter.SelectCommand.Connection.Open();
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = SalesManagementScripts.sqlGetAllSalesManagement;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Get sales management by ID
        /// </summary>
        /// <param name="salesManagementID"></param>
        /// <returns></returns>
        public DataRow GetSalesManagementById(int salesManagementID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = SalesManagementScripts.sqlGetSalesManagementById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SalesManagementID", salesManagementID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            return dataRow;
            
        }

        /// <summary>
        /// A table which is a result of a search query
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productDeliveryID"></param>
        /// <param name="paymentID"></param>
        /// <param name="purchasePriceID"></param>
        /// <returns></returns>
        public DataTable SearchSalesManagement
                    (object productID, object productDeliveryID, object paymentID, object purchasePriceID)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = SalesManagementScripts.sqlSearchSalesManagement;

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue
                    ("@ProductID", productID == null ? DBNull.Value : productDeliveryID);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue
                    ("@ProductDeliveryID", productDeliveryID == null ? DBNull.Value : productDeliveryID);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue
                    ("@SellingPriceID", paymentID == null ? DBNull.Value : paymentID);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue
                    ("@PaymentID", paymentID == null ? DBNull.Value : paymentID);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue
                    ("@PurchasePriceID", purchasePriceID == null ? DBNull.Value : purchasePriceID);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
            
        }

        /// <summary>
        /// Update a row in the sales management table
        /// </summary>
        /// <param name="salesManagement"></param>
        /// <returns></returns>
        public bool UpdateSalesManagement(SalesManagementDataModel salesManagement)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = SalesManagementScripts.sqlUpdateSalesManagement;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@ProductID", salesManagement.PaymentID);
                oleDbCommand.Parameters.AddWithValue("@ProductDeliveryID", salesManagement.ProductDeliveryID);
                oleDbCommand.Parameters.AddWithValue("@SellingPriceID", salesManagement.SellingPriceID);
                oleDbCommand.Parameters.AddWithValue("@PaymentID", salesManagement.PaymentID);
                oleDbCommand.Parameters.AddWithValue("@PurchasePriceID", salesManagement.PurchasePriceID);
                oleDbCommand.Parameters.AddWithValue("@SalesManagementID", salesManagement.SalesManagementID);

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
        public SalesManagementDataModel ConvertToDataModel(DataRow salesManagementRow)
        {
            var result = new SalesManagementDataModel();

            result.SalesManagementID = salesManagementRow.Field<int>("SalesManagementID");
            result.ProductID = salesManagementRow.Field<int>("ProductID");
            result.ProductDeliveryID = salesManagementRow.Field<int>("ProductDeliveryID"); 
            result.SellingPriceID = salesManagementRow.Field<int>("SellingPriceID");
            result.PaymentID = salesManagementRow.Field<int>("PaymentID");
            result.PurchasePriceID = salesManagementRow.Field<int>("PurchasePriceID");

            return result;
        }
    }
}
