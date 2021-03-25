using System;

namespace AMS.Core.Dto.UpdateDto
{
    public class CollectionCommissionUpdateDto
    {
        
        public int Id { get; set; }
        
        public int? CommissionAmount { get; set; }

        public string CommissionCurrency { get; set; }

        public DateTime? CollectedAt { get; set; }

        public int? CollectedByEmpId { get; set; }
    }
}