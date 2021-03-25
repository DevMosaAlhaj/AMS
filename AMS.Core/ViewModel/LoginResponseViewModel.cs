using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.ViewModel
{
    public class LoginResponseViewModel
    {

        public string UserId { get; set; }

        public string RefreshToken { get; set; }

        public TokenViewModel TokenViewModel { get; set; }

    }
}
