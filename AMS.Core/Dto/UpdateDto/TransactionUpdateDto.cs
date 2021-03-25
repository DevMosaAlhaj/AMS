using System.Collections.Generic;

namespace AMS.Core.Dto.UpdateDto
{
    public class TransactionUpdateDto
    {
        
        public int Id { get; set; }
        
        public int? TotalPrice { get; set; }

        public int? CashAmount { get; set; }

        public string CashCurrency { get; set; }

        public List<int> Cheques { get; set; }

        public List<int> ExchangeBills { get; set; }

        public List<int> AccessoryFiles { get; set; }

        public int? SaleContract { get; set; }
    }
}