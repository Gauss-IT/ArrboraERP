/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.SQLLite.Sql
{
    public static class PaymentScripts
    {
        /// <summary>
        /// Sql to get a payment by Id
        /// </summary>
        public static readonly string sqlGetPaymentById = "SELECT" +
            " PaymentID, PaymentTotal" +
            " FROM Payments WHERE PaymentID = @PaymentID";

        /// <summary>
        /// Sql command to get all payments
        /// </summary>
        public static readonly string sqlGetAllPayments = "SELECT" +
            " PaymentID, PaymentTotal" +
            " FROM Payments";

        /// <summary>
        /// Sql to insert a payment
        /// </summary>
        public static readonly string sqlInsertPayment = "INSERT INTO" +
            " Payments(PaymentTotal)" +
            " Values( @PaymentTotal)";

        /// <summary>
        /// sql to update a payment
        /// </summary>
        public static readonly string sqlUpdatePayment = "UPDATE Payments" +
            " Set [PaymentTotal] = @PaymentTotal" +
            " WHERE ([PaymentID] = @PaymentID)";

        /// <summary>
        /// sql to delete a payment
        /// </summary>
        public static readonly string sqlDeletePayment =
            "DELETE FROM Payments WHERE (PaymentID = @PaymentID)";
    }
}
