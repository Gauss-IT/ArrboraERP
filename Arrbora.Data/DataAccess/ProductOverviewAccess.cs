/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using Arrbora.Data.DataModel;
using System.Data.OleDb;
using Arrbora.Data.Sql;
using Arrbora.Data.DataAccess.Interfaces;

namespace Arrbora.Data.DataAccess
{
    public class ProductOverviewAccess : ConnectionAccess, IProductOverviewAccess
    {
        /// <summary>
        /// Method to create new product overview
        /// </summary>
        /// <param name="product">club member model</param>
        /// <returns>true or false</returns>
        public bool AddProductOverview(ProductOverviewDataModel productOverview)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to delete a product overview by ID
        /// </summary>
        /// <param name="SalesManagementID">Product ManagementID</param>
        /// <returns>true / false</returns>
        public bool DeleteProductOverviewByID(int SalesManagementID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get all products overview
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllProductOverview()
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
                oleDbDataAdapter.SelectCommand.CommandText = ProductOverviewScripts.sqlGetAllProductOverview;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to get a single product overview
        /// </summary>
        /// <returns>Data row</returns>
        public DataRow GetProductOverviewById(int SalesManagementID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to search products overview by parameters
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable SearchProductOverview(object SalesManagementID, object brand, object model)
        {
            throw new NotImplementedException();
        }
    }
}
