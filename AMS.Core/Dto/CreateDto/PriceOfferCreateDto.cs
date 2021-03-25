using System.Collections.Generic;

namespace AMS.Core.Dto.CreateDto
{
    public class PriceOfferCreateDto
    {
        public List<int> SparePartsId { get; set; }

        public string TotalPriceCurrency { get; set; }

        public int MaintenanceServiceId { get; set; }
    }
}