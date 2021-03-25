using System.Collections.Generic;
using System.Linq;

namespace AMS.Data.DbEntity
{
    public class PriceOfferDbEntity : BaseDbEntity
    {

        public PriceOfferDbEntity()
        {
            TotalPrice = (int)SpareParts.Sum(sp => sp.TotalPrice);
        }

        public List<SparePartDbEntity> SpareParts { get; set; }

        public int TotalPrice { get; }

        public string TotalPriceCurrency { get; set; }

        public int MaintenanceServiceId { get; set; }

        public MaintenanceServiceDbEntity MaintenanceService { get; set; }

        
    }
}