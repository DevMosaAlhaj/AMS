using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class ClientViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Mediator { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int IdentityNo { get; set; }

        public List<int> Motors { get; set; }

        public List<int> SparePartsSold { get; set; }

        public List<int> MaintenanceContracts { get; set; }

        public List<int> SaleContracts { get; set; }

        public List<int> MaintenanceServices { get; set; }
        
        
    }
}