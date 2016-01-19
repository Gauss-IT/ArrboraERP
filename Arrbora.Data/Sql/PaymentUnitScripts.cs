/// <summary>
/// Copyright Arrbora DOO
/// </summary>

namespace Arrbora.Data.Sql
{
    public static class PaymentUnitScripts
    {
        /// <summary>
        /// Sql to get a payment unit by Id
        /// </summary>
        public static readonly string sqlGetPaymentUnitById = "SELECT" +
            " PaymentUnitID, PaymentID, PaymentUnitDate, Amount, PaymentType,PayedBy, Note" +
            " FROM PaymentUnits WHERE PaymentUnitID = @PaymentUnitID";

        /// <summary>
        /// Sql command to get all payment units
        /// </summary>
        public static readonly string sqlGetAllPaymentUnits = "SELECT" +
            " PaymentUnitID, PaymentID, PaymentUnitDate, Amount, PaymentType,PayedBy, Note" +
            " FROM PaymentUnits";

        /// <summary>
        /// sql to insert a payment unit
        /// </summary>
        public static readonly string sqlInsertPaymentUnit = "INSERT INTO" +
            " PaymentUnits(PaymentID, PaymentUnitDate, Amount, PaymentType,PayedBy, Note)" +
            " Values( @PaymentID, @PaymentUnitDate, @Amount, @PayedBy, @PaymentType, @Note)";

        /// <summary>
        /// sql to search for payment units
        /// </summary>
        public static readonly string sqlGetAllPaymentUnitsForPayment = "SELECT " +
            " PaymentUnitID, PaymentID, PaymentUnitDate, Amount, PaymentType,PayedBy, Note" +
            " FROM PaymentUnits WHERE PaymentID = @PaymentID";

        /// <summary>
        /// sql to update a payment unit
        /// </summary>
        public static readonly string sqlUpdatePaymentUnit = "UPDATE PaymentUnits " +
            " Set [PaymentID] = @PaymentID, [PaymentUnitDate] = @PaymentUnitDate, [Amount] = @Amount," +
            " [PaymentType]= @PaymentType, [PayedBy] = @PayedBy, [Note] = @Note" +
            " WHERE ([PaymentUnitID] = @PaymentUnitID)";

        /// <summary>
        /// sql to delete a payment unit
        /// </summary>
        public static readonly string sqlDeletePaymentUnit = 
            "DELETE FROM PaymentUnits WHERE (PaymentUnitID = @PaymentUnitID)";

    }
}
