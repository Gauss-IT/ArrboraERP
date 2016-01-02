/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using System.Data.OleDb;
using Arrbora.Data.DataModel;
using Arrbora.Data.Sql;
using Arrbora.Data.DataAccess.Interfaces;

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
        }

        /// <summary>
        /// Method to create new empty product
        /// </summary>
        /// <returns>ProductID of the inserted row</returns>
        public int AddEmptyProduct()
        {
            var result = -1;
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductScripts.sqlInsertProduct;

                // Add the input parameters to the parameter collection                
                oleDbCommand.Parameters.AddWithValue("@Brand", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@Model", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@VIN", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@EnteriourColour", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ExteriourColour", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@ModelYear", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@DLPNetto", DBNull.Value);
                oleDbCommand.Parameters.AddWithValue("@DLPBrutto", DBNull.Value);

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
        /// Method to delete a single product by ProductID
        /// </summary>
        public bool DeleteProductByID(int ProductID)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = ProductScripts.sqlDeleteProduct;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@ProductID", ProductID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
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
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = ProductScripts.sqlUpdateProduct;

                // Add the input parameters to the parameter collection
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
        }

        /// <summary>
        /// Converts a Data row from the database table to sales management model
        /// </summary>
        /// <param name="productRow"></param>
        /// <returns></returns>
        public ProductDataModel ConvertToDataModel(DataRow productRow)
        {
            var result = new ProductDataModel();

            result.ProductID = productRow.Field<int>("ProductID");
            result.Brand = productRow.Field<string>("Brand");
            result.Model = productRow.Field<string>("Model");
            result.VIN = productRow.Field<decimal>("VIN");
            result.EnteriourColour = productRow.Field<string>("EnteriourColour");
            result.ExteriourColour = productRow.Field<string>("ExteriourColour");
            result.ModelYear = productRow.Field<int>("ModelYear");
            result.DLPNetto = productRow.Field<decimal>("DLPNetto");
            result.DLPBrutto = productRow.Field<decimal>("DLPBrutto");

            return result;
        }
    }
}
