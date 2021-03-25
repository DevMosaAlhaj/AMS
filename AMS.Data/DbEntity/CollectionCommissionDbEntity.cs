using System;

namespace AMS.Data.DbEntity
{
    public class CollectionCommissionDbEntity : BaseDbEntity
    {
        public int CommissionAmount { get; set; }

        public string CommissionCurrency { get; set; }

        public DateTime CollectedAt { get; set; }

        public int CollectedByEmpId { get; set; }

        public EmployeeDbEntity CollectedByEmp { get; set; }

        
        
    }
}