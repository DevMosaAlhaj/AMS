using AMS.Core.Enum;

namespace AMS.Core.Dto.CreateDto
{
    public class SparePartCreateDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double PricePerOne { get; set; }

        public UnitType UnitType { get; set; }
    }
}