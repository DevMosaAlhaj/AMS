using AMS.Core.Enum;

namespace AMS.Data.DbEntity
{
    public class SparePartDbEntity : BaseDbEntity
    {

        public SparePartDbEntity()
        {
            TotalPrice = Quantity * PricePerOne;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double PricePerOne { get; set; }
        
        public double TotalPrice { get; }

        public UnitType UnitType { get; set; }
    }
}