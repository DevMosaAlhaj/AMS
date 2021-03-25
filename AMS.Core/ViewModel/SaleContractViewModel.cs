using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class SaleContractViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public List<int> AccessorySpareParts { get; set; }

        public string AccessoryServices { get; set; }

        public int ClientId { get; set; } 

        public int MotorId { get; set; }

        public int TransactionId { get; set; }
    }
}