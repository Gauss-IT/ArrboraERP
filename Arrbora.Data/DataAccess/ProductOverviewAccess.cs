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
        /// Method to search products overview by parameters
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable SearchProductOverview(object brand, object model)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = ProductOverviewScripts.sqlSearchProductOverview;

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Brand", (brand == null || (string)brand == "") ? DBNull.Value : brand);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Model", (model == null || (string)model == "") ? DBNull.Value : model);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable; ;
        }
    }
}
