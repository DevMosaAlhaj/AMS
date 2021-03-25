using System;
using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class MaintenanceContractViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public DateTime ContractDate { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public int CyclePerMonth { get; set; }

        public int MotorId { get; set; }

        public int ClientId { get; set; }

        public int ContractDuration { get; set; }
        
        public List<int> MaintenanceCycles { get; set; }
        
    }
}