using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class EmployeeDbEntity : BaseDbEntity
    {
        public string Name { get; set; }

        public int? IdentityNo { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string JobName { get; set; }

        public List<MaintenanceCycleDbEntity> MaintenanceCycles { get; set; }

        public List<SparePartSoldDbEntity> SparePartsSold { get; set; }

        public List<MaintenanceServiceDbEntity> MaintenanceServices { get; set; }
        
        public List<CollectionCommissionDbEntity> CollectionCommissions { get; set; }

    }
}