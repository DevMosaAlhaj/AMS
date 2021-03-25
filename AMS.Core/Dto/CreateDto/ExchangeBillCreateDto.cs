using System;

namespace AMS.Core.Dto.CreateDto
{
    public class ExchangeBillCreateDto
    {
        public DateTime WritingAt { get; set; }

        public DateTime DueAt { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string DebtorName { get; set; }

        public int TransactionId { get; set; }

        public bool IsPaid { get; set; }
    }
}