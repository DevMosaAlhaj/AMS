using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class ExchangeBillSearchDto
    {

        public DateTime? WritingAt { get; set; }

        public DateTime? DueAt { get; set; }

        public int? Amount { get; set; }

        public string Currency { get; set; }

        public string DebtorName { get; set; }

        public bool? IsPaid { get; set; }

    }
}
