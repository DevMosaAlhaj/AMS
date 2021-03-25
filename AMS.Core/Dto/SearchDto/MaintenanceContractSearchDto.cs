using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class MaintenanceContractSearchDto
    {

        public DateTime? ContractDate { get; set; }

        public DateTime? ContractStartDate { get; set; }

        public DateTime? ContractEndDate { get; set; }

        public int? CyclePerMonth { get; set; }

    }
}
