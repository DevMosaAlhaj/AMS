using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class SaleContractDbEntity : BaseDbEntity
    {

        public int Price { get; set; }
        
        // Sale Contract Accessories 

        public List<SparePartDbEntity> AccessorySpareParts { get; set; }

        public string AccessoryServices { get; set; }

        public int ClientId { get; set; }

        public ClientDbEntity Client { get; set; }

        public int MotorId { get; set; }

        public MotorDbEntity Motor { get; set; }

        public int TransactionId { get; set; }

        public TransactionDbEntity Transaction { get; set; }

       
        
    }
}