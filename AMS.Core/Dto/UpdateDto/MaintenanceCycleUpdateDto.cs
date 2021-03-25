using System;
using System.Collections.Generic;

namespace AMS.Core.Dto.UpdateDto
{
    public class MaintenanceCycleUpdateDto
    {
        
        public int Id { get; set; }
        
        public DateTime? VisitAt { get; set; }

        public List<int> MaintenanceTeamId { get; set; }

        public List<int> SparePartsId { get; set; }
        
        public string Service { get; set; }

        public int? MaintenanceContractId { get; set; }
    }
}