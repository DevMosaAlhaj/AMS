using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class EmployeeViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int? IdentityNo { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string JobName { get; set; }

        public List<int> MaintenanceCycles { get; set; }

        public List<int> SparePartsSold { get; set; }

        public List<int> MaintenanceServices { get; set; }
        
        public List<int> CollectionCommissions { get; set; }
        
    }
}