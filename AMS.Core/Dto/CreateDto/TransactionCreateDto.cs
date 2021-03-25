using System.Collections.Generic;

namespace AMS.Core.Dto.CreateDto
{
    public class TransactionCreateDto
    {
        public int TotalPrice { get; set; }

        public int CashAmount { get; set; }

        public string CashCurrency { get; set; }

        public List<int> Cheques { get; set; }

        public List<int> ExchangeBills { get; set; }

        public List<int> AccessoryFiles { get; set; }

        public int SaleContractId { get; set; }
    }
}