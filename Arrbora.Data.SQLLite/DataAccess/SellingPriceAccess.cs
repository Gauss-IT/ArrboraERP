/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using Arrbora.Data.SQLLite.DataModel;
using System.Data;
using System;
using Arrbora.Data.SQLLite.DataAccess.Interfaces;
using System.Data.OleDb;
using Arrbora.Data.SQLLite.Sql;

namespace Arrbora.Data.SQLLite.DataAccess
{
    /// <summary>
    /// Selling Price Access class
    /// </summary>
    public class SellingPriceAccess : ConnectionAccess, ISellingPriceAccess
    {
        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>SellingPriceID of the inserted row</returns>
        public int AddEmptySellingPrice()
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = SellingPriceScripts.sqlInsertSellingPrice;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@Price", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalSelling", DBNull.Value);

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
        /// Method to create new selling price
        /// </summary>
        /// <param name="sellingPrice">Selling Price model</param>
        /// <returns>true or false</returns>
        public bool AddSellingPrice(SellingPriceDataModel sellingPrice)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = SellingPriceScripts.sqlInsertSellingPrice;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@Price", sellingPrice.Price ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", sellingPrice.Transport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", sellingPrice.Other1 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", sellingPrice.Other2 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalSelling", sellingPrice.TotalSelling ?? (object)DBNull.Value);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Converts a Data row from the database table to selling price model
        /// </summary>
        /// <param name="sellingPriceRow"></param>
        /// <returns></returns>
        public SellingPriceDataModel ConvertToDataModel(DataRow sellingPriceRow)
        {
            var result = new SellingPriceDataModel();

            result.SellingPriceID = sellingPriceRow.Field<int>("SellingPriceID");
            result.Price = sellingPriceRow.Field<decimal?>("Price");
            result.Transport = sellingPriceRow.Field<decimal?>("Transport");
            result.Other1 = sellingPriceRow.Field<decimal?>("Other1");
            result.Other2 = sellingPriceRow.Field<decimal?>("Other2");
            result.TotalSelling = sellingPriceRow.Field<decimal?>("TotalSelling");          

            return result;
        }

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="sellingPriceID">selling price id</param>
        /// <returns>true / false</returns>
        public bool DeleteSellingPriceByID(int sellingPriceID)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = SellingPriceScripts.sqlDeleteSellingPrice;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@SellingPriceID", sellingPriceID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to get all selling prices
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllSellingPrices()
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
                oleDbDataAdapter.SelectCommand.CommandText = SellingPriceScripts.sqlGetAllSellingPrices;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
        
        /// <summary>
        /// Method to get a selling price
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetSellingPriceById(int sellingPriceID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = SellingPriceScripts.sqlGetSellingPricetById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SellingPriceID", sellingPriceID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            return dataRow;
        }

        /// <summary>
        /// Method to update selling price details
        /// </summary>
        /// <param name="sellingPrice">Selling Price</param>
        /// <returns></returns>
        public bool UpdateSellingPrice(SellingPriceDataModel sellingPrice)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = SellingPriceScripts.sqlUpdateSellingPrice;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@Price", sellingPrice.Price ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Transport", sellingPrice.Transport ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other1", sellingPrice.Other1 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Other2", sellingPrice.Other2 ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@TotalSelling", sellingPrice.TotalSelling ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@SellingPriceID", sellingPrice.SellingPriceID);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
