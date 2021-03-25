using System;

namespace AMS.Core.Dto.CreateDto
{
    public class MaintenanceContractCreateDto
    {
        public DateTime ContractDate { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public int CyclePerMonth { get; set; }

        public int MotorId { get; set; }

        public int ClientId { get; set; }

        public int ContractDuration { get; set; }
    }
}