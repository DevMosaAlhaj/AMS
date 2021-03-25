using System;
using AMS.Core.Enum;

namespace AMS.Core.ViewModel
{
    public class UserViewModel : IBaseViewModel
    {

        public string Id { get; set; }
        
        public DateTime? LastSeen { get; set; }
        
        public string Name { get; set; }

        public int ForEmpId { get; set; }

        public string UserType { get; set; }
    }
}