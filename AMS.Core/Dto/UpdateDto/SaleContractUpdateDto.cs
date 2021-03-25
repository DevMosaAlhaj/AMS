using System.Collections.Generic;

namespace AMS.Core.Dto.UpdateDto
{
    public class SaleContractUpdateDto
    {
        
        public int Id { get; set; }
        
        public int? Price { get; set; }

        public List<int> AccessorySpareParts { get; set; }

        public string AccessoryServices { get; set; }

        public int? ClientId { get; set; }

        public int? MotorId { get; set; }

        public int? TransactionId { get; set; }
    }
}