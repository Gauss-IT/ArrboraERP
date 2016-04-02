/// <summary>
/// Copyright Arrbora DOO
/// </summary>

using System;
using System.Data;
using System.Data.OleDb;
using Arrbora.Data.SQLLite.Sql;
using Arrbora.Data.SQLLite.DataAccess.Interfaces;

namespace Arrbora.Data.SQLLite.DataAccess
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
        public DataTable SearchProductOverview(object brand, object model,
                    DateTime minDate, DateTime maxDate, decimal priceFrom, decimal priceTo)
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
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@MinDate", (minDate == null) ? DBNull.Value : (object)minDate.ToOADate());
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@MaxDate", (maxDate == null) ? DBNull.Value : (object)maxDate.ToOADate());
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@PriceFrom", (priceFrom == 0) ? DBNull.Value : (object)priceFrom);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@PriceTo", (priceTo == 0) ? DBNull.Value : (object)priceTo);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable; ;
        }
    }
}
