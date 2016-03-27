/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using Arrbora.Data.DataAccess.Interfaces;
using System.Data.OleDb;
using Arrbora.Data.Sql;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Class to access Product Delivery table
    /// </summary>
    public class ProductDeliveryAccess : ConnectionAccess,IProductDeliveryAccess 
    {
        /// <summary>
        /// Method to create new empty selling price
        /// </summary>
        /// <returns>productDeliveryID of the inserted row</returns>
        public int AddEmptyProductDelivery()
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductDeliveryScripts.sqlInsertProductDelivery;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@DateOfPurchase", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@LandOfOrigin", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@CurrentLocation", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@DateOfSale", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@LandOfDestination", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductStatus", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Seller", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Buyer", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductWebsite", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductAttachment", DBNull.Value);

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
        /// <param name="productDelivery">club member model</param>
        /// <returns>true or false</returns>
        public bool AddProductDelivery(ProductDeliveryDataModel productDelivery)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductDeliveryScripts.sqlInsertProductDelivery;
               
                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@DateOfPurchase", productDelivery.DateOfPurchase == null ? (object)DBNull.Value :
                    productDelivery.DateOfPurchase.Value.ToOADate());                
                oleDbCommand.Parameters.AddWithValue("@LandOfOrigin", productDelivery.LandOfOrigin ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@CurrentLocation", productDelivery.CurrentLocation ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@DateOfSale", productDelivery.DateOfSale == null ? (object)DBNull.Value :
                    productDelivery.DateOfSale.Value.ToOADate());
                oleDbCommand.Parameters.AddWithValue("@LandOfDestination", productDelivery.LandOfDestination ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductStatus", productDelivery.ProductStatus ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Seller", productDelivery.Seller ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Buyer", productDelivery.Buyer ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductWebsite", productDelivery.ProductWebsite ?? (object)DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ProductAttachment", productDelivery.ProductAttachment ?? (object)DBNull.Value);

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
        /// <param name="productDeliveryRow"></param>
        /// <returns></returns>
        public ProductDeliveryDataModel ConvertToDataModel(DataRow productDeliveryRow)
        {
            var result = new ProductDeliveryDataModel();

            result.ProductDeliveryID = productDeliveryRow.Field<int>("ProductDeliveryID");
            result.DateOfPurchase = productDeliveryRow.Field<DateTime?>("DateOfPurchase");
            result.LandOfOrigin = productDeliveryRow.Field<string>("LandOfOrigin");
            result.CurrentLocation = productDeliveryRow.Field<string>("CurrentLocation");
            result.DateOfSale = productDeliveryRow.Field<DateTime?>("DateOfSale");
            result.LandOfDestination = productDeliveryRow.Field<string>("LandOfDestination");
            result.ProductStatus = productDeliveryRow.Field<bool?>("ProductStatus");
            result.Seller = productDeliveryRow.Field<string>("Seller");
            result.Buyer = productDeliveryRow.Field<string>("Buyer");
            result.ProductWebsite = productDeliveryRow.Field<string>("ProductWebsite");
            result.ProductAttachment = productDeliveryRow.Field<string>("ProductAttachment");

            return result;
        }

        /// <summary>
        /// Method to delete a selling price
        /// </summary>
        /// <param name="productDeliveryID">selling price id</param>
        /// <returns>true / false</returns>
        public bool DeleteProductDeliveryByID(int productDeliveryID)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = ProductDeliveryScripts.sqlDeleteProductDelivery;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@ProductDeliveryID", productDeliveryID);

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
        public DataTable GetAllProductDeliveries()
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
                oleDbDataAdapter.SelectCommand.CommandText = ProductDeliveryScripts.sqlGetAllProductDeliveries;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to get a product Delivery
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetProductDeliveryById(int productDeliveryId)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = ProductDeliveryScripts.sqlGetProductDeliveryById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ProductDeliveryId", productDeliveryId);

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
        /// <param name="productDelivery">Selling Price</param>
        /// <returns></returns>
        public bool UpdateProductDelivery(ProductDeliveryDataModel productDelivery)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductDeliveryScripts.sqlUpdateProductDelivery;

                // Add the input parameters to the parameter collection
               
                oleDbCommand.Parameters.Add(new OleDbParameter("@DateOfPurchase", productDelivery.DateOfPurchase == null ? (object)DBNull.Value :
                    productDelivery.DateOfPurchase.Value.ToOADate()));
                oleDbCommand.Parameters.Add(new OleDbParameter("@LandOfOrigin", productDelivery.LandOfOrigin ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@CurrentLocation", productDelivery.CurrentLocation ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@DateOfSale", productDelivery.DateOfSale == null ? (object)DBNull.Value :
                    productDelivery.DateOfSale.Value.ToOADate()));
                oleDbCommand.Parameters.Add(new OleDbParameter("@LandOfDestination", productDelivery.LandOfDestination ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductStatus", productDelivery.ProductStatus ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@Seller", productDelivery.Seller ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@Buyer", productDelivery.Buyer ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductWebsite", productDelivery.ProductWebsite ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductAttachment", productDelivery.ProductAttachment ?? (object)DBNull.Value));
                oleDbCommand.Parameters.Add(new OleDbParameter("@ProductDeliveryID", productDelivery.ProductDeliveryID));

                
                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
