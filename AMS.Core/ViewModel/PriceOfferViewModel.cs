using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class PriceOfferViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public List<int> SpareParts { get; set; }

        public int TotalPrice { get; set; }

        public string TotalPriceCurrency { get; set; }

        public int MaintenanceServiceId { get; set; }
        
    }
}