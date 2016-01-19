/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.Sql
{
    public static class GeneralScripts
    {
        /// <summary>
        /// Sql to get the Primary Key of the last inserted row
        /// </summary>
        public static readonly string sqlGetIdentityOfInsertedRow = "SELECT @@Identity";
    }
}
