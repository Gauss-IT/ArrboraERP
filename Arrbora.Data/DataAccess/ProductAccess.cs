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
using Arrbora.Data.Scripts;

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
                oleDbDataAdapter.SelectCommand.CommandText = Scripts.Scripts.SqlGetAllProducts;

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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to delete a single product by ID
        /// </summary>
        public bool DeleteProductByID(int id)
        {
            throw new NotImplementedException();
        }        

        /// <summary>
        /// Method to get a product by ID
        /// </summary>
        public DataRow GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to make a search in products
        /// </summary>
        public DataTable SearchProducts()
        {
            throw new NotImplementedException();
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
