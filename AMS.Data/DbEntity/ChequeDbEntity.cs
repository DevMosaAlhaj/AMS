using System;

namespace AMS.Data.DbEntity
{
    public class ChequeDbEntity : BaseDbEntity
    {

        public DateTime DueAt { get; set; }

        public string ByBank { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string DebtorName { get; set; }

        public int TransactionId { get; set; }

        public TransactionDbEntity Transaction { get; set; }

        public bool IsPaid { get; set; }

    }
}