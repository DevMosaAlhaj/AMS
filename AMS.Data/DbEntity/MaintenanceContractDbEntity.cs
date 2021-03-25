using System;
using System.Collections.Generic;

namespace AMS.Data.DbEntity
{
    public class MaintenanceContractDbEntity : BaseDbEntity
    {


        public MaintenanceContractDbEntity()
        {
            var years = ContractEndDate.Year - ContractStartDate.Year;
            var months = ContractEndDate.Month - ContractStartDate.Month;
            var days = ContractEndDate.Day - ContractStartDate.Day;

            var duration = (years * 365) + (months * 30) + days;
            ContractDuration = (int)Math.Ceiling(duration / 30.0);
        }

        public DateTime ContractDate { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public int CyclePerMonth { get; set; }

        public int MotorId { get; set; }

        public MotorDbEntity Motor { get; set; }

        public int ClientId { get; set; }

        public ClientDbEntity Client { get; set; }

        public int ContractDuration { get; }

        public List<MaintenanceCycleDbEntity> MaintenanceCycles { get; set; }

    }
}