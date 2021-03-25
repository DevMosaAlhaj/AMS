using System.Collections.Generic;

namespace AMS.Core.Dto.UpdateDto
{
    public class PriceOfferUpdateDto
    {
        
        public int Id { get; set; }
        
        public List<int> SparePartsId { get; set; }

        public string TotalPriceCurrency { get; set; }

        public int? MaintenanceServiceId { get; set; }
    }
}