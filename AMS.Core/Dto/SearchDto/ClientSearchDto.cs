using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class ClientSearchDto
    {

        public string Name { get; set; }

        public string Mediator { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int? IdentityNo { get; set; }

    }
}
