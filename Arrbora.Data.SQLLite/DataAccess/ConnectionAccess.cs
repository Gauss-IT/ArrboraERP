/// <summary>
/// Copyright Arrbora DOO
/// </summary>
/// 

namespace Arrbora.Data.SQLLite
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
                string connect = "Data Source=" + DatabaseController.DatabaseFilename + ";Version=3;";

                return connect;
            }
        }
    }
}
