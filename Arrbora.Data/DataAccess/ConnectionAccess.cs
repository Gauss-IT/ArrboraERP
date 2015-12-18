/// <summary>
/// Copyright Arrbora DOO
/// </summary>
/// 
using System.Data.OleDb;

namespace Arrbora.Data
{
    /// <summary>
    /// Connection Access class
    /// </summary>
    public abstract class ConnectionAccess
    {
        /// <summary>
        /// Gets connection string
        /// </summary>
        protected string ConnectionString
        {
            get
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
                builder.ConnectionString = "";

                // Call the Add method to explicitly add key/value
                // pairs to the internal collection.
                builder.Add("Data Source", "C:\\Temp\\ArrboraAccessDatabase.accdb");
                //var dir = AppDomain.CurrentDomain..GetData("DataDirectory");
                //builder.Add("Data Source", @"|DataDirectory|\Databases\ArrboraAccessDatabase.accdb");
                builder.Add("Provider", "Microsoft.ACE.OLEDB.12.0");
                builder.Add("Persist Security Info", false);

                return builder.ConnectionString;

                //return ConfigurationManager
                //    .ConnectionStrings["ArrboraAccessDatabaseConnectionString"]
                //    .ToString();
            }
        }
    }
}
