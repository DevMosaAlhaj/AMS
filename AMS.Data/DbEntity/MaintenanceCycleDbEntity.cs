using System;
using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class MaintenanceCycleDbEntity : BaseDbEntity
    {
        public DateTime VisitAt { get; set; }

        public List<EmployeeDbEntity> MaintenanceTeam { get; set; }

        public List<SparePartDbEntity> SpareParts { get; set; }

        public string Service { get; set; }

        public int MaintenanceContractId { get; set; }

        public MaintenanceContractDbEntity MaintenanceContract { get; set; }
        
    }
}