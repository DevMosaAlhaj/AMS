using System;

namespace AMS.Data.DbEntity
{
    public class ExchangeBillDbEntity : BaseDbEntity
    {
        public DateTime WritingAt { get; set; }

        public DateTime DueAt { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string DebtorName { get; set; }

        public int TransactionId { get; set; }

        public TransactionDbEntity Transaction { get; set; }

        public bool IsPaid { get; set; }
        
    }
}