/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Arrbora.Data.DataModel;
using Arrbora.Data.Sql;

namespace Arrbora.Data.DataAccess
{
    /// <summary>
    /// Product Access class
    /// </summary>
    public class ProductAccess : ConnectionAccess,IProductAccess
    {
        /// <summary>
        /// Method to get all products
        /// </summary>
        public DataTable GetAllProducts()
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
                oleDbDataAdapter.SelectCommand.CommandText = ProductScripts.sqlGetAllProducts;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;               
        }
        
        /// <summary>
        /// Method to add a single product
        /// </summary>
        public bool AddProduct(ProductDataModel product)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductScripts.sqlInsertProduct;

                // Add the input parameters to the parameter collection
                //oleDbCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                oleDbCommand.Parameters.AddWithValue("@Brand", product.Brand);
                oleDbCommand.Parameters.AddWithValue("@Model", product.Model);
                oleDbCommand.Parameters.AddWithValue("@VIN", product.VIN);
                oleDbCommand.Parameters.AddWithValue("@EnteriourColour", product.EnteriourColour);
                oleDbCommand.Parameters.AddWithValue("@ExteriourColour", product.ExteriourColour);
                oleDbCommand.Parameters.AddWithValue("@ModelYear", product.ModelYear);
                oleDbCommand.Parameters.AddWithValue("@DLPNetto", product.DLPNetto);
                oleDbCommand.Parameters.AddWithValue("@DLPBrutto", product.DLPBrutto);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.Connection.Close();

                return rowsAffected > 0;
            }
            return true;
        }

        /// <summary>
        /// Method to delete a single product by ProductID
        /// </summary>
        public bool DeleteProductByID(int ProductID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get a product by ProductID
        /// </summary>
        public DataRow GetProductById(int ProductID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = ProductScripts.sqlGetProductById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ProductID", ProductID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;   
            }
            return dataRow;
        }

        /// <summary>
        /// Method to make a search in products
        /// </summary>
        public DataTable SearchProducts(object brand, object model)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = ProductScripts.sqlSearchProducts;

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Brand", brand == null ? DBNull.Value : brand);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Model", model == null ? DBNull.Value : model);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to update a product
        /// </summary>
        public bool UpdateProduct(ProductDataModel product)
        {
            throw new NotImplementedException();
        }
    }
}
