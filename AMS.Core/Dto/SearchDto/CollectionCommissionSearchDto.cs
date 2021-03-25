using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class CollectionCommissionSearchDto
    {

        public int? CommissionAmount { get; set; }

        public string CommissionCurrency { get; set; }

        public DateTime? CollectedAt { get; set; }

    }
}
