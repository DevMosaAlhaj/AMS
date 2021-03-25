using System;

namespace AMS.Core.Dto.CreateDto
{
    public class CollectionCommissionCreateDto
    {
        public int CommissionAmount { get; set; }

        public string CommissionCurrency { get; set; }

        public DateTime CollectedAt { get; set; }

        public int CollectedByEmpId { get; set; }
    }
}