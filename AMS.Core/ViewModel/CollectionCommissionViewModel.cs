using System;

namespace AMS.Core.ViewModel
{
    public class CollectionCommissionViewModel : IBaseViewModel
    {

        public int Id { get; set; }
        
        public int CommissionAmount { get; set; }

        public string CommissionCurrency { get; set; }

        public DateTime CollectedAt { get; set; }

        public int CollectedByEmpId { get; set; }
        
    }
}