using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class ChequeSearchDto
    {

        public DateTime? DueAt { get; set; }

        public string ByBank { get; set; }

        public int? Amount { get; set; }

        public string DebtorName { get; set; }

        public bool? IsPaid { get; set; }

    }
}
