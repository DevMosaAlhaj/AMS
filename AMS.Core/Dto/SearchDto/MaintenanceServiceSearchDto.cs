using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class MaintenanceServiceSearchDto
    {

        public DateTime? EntryAt { get; set; }

        public DateTime? ExitAt { get; set; }

        public string TransportDescription { get; set; }

        public string ExitNotes { get; set; }


    }
}
