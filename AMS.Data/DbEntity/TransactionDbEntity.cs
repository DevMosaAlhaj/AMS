using System.Collections.Generic;
using System.Linq;

namespace AMS.Data.DbEntity
{
    public class TransactionDbEntity : BaseDbEntity
    {

        public TransactionDbEntity()
        {

            int cheques = 0 , exchangeBills = 0;

            if (Cheques != null)
                cheques = Cheques.Where(x => x.IsPaid).Sum(x => x.Amount);
            if (ExchangeBills != null)
                exchangeBills = ExchangeBills.Where(x => x.IsPaid).Sum(x => x.Amount);


            RemainingAmount = TotalPrice - (cheques + exchangeBills);
        }

        public int TotalPrice { get; set; }

        public int CashAmount { get; set; }

        public string CashCurrency { get; set; }

        public List<ChequeDbEntity> Cheques { get; set; }

        public List<ExchangeBillDbEntity> ExchangeBills { get; set; }

        public List<FileDbEntity> AccessoryFiles { get; set; }

        public int SaleContractId { get; set; }

        public SaleContractDbEntity SaleContract { get; set; }

        public int RemainingAmount { get; }
    }
}