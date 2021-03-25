using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class TransactionViewModel : IBaseViewModel
    {

        public int Id { get; set; }
        
        public int TotalPrice { get; set; }

        public int CashAmount { get; set; }

        public string CashCurrency { get; set; }

        public List<int> Cheques { get; set; }

        public List<int> ExchangeBills { get; set; }

        public List<int> AccessoryFiles { get; set; }

        public int SaleContractId { get; set; }

        public int RemainingAmount { get; set; }
        
    }
}