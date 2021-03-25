using System;
using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class MaintenanceCycleViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public DateTime VisitAt { get; set; }

        public List<int> MaintenanceTeam { get; set; }

        public List<int> SpareParts { get; set; }

        public string Service { get; set; }

        public int MaintenanceContractId { get; set; }

    }
}