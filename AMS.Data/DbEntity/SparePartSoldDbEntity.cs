using System;
using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class SparePartSoldDbEntity : BaseDbEntity
    {
        public DateTime SaleAt { get; set; }

        public int ClientId { get; set; }

        public ClientDbEntity Client { get; set; }

        public int MotorId { get; set; }

        public MotorDbEntity Motor { get; set; }

        public List<SparePartDbEntity> SpareParts { get; set; }

        public List<EmployeeDbEntity> SalesStaff { get; set; }
        
    }
}