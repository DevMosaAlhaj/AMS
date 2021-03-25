using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.CreateDto
{
    public class MessageCreateDto
    {

        public string Title { get; set; }

        public string Body { get; set; }

        public string Action { get; set; }

        public int ActionId { get; set; }

    }
}
