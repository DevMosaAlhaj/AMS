using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class ClientDbEntity : BaseDbEntity
    {

        public string Name { get; set; }

        public string Mediator { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int IdentityNo { get; set; }

        public List<MotorDbEntity> Motors { get; set; }

        public List<SparePartSoldDbEntity> SparePartsSold { get; set; }

        public List<MaintenanceContractDbEntity> MaintenanceContracts { get; set; }

        public List<SaleContractDbEntity> SaleContracts { get; set; }

        public List<MaintenanceServiceDbEntity> MaintenanceServices { get; set; }

    }
}