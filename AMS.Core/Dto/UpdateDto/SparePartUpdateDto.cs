using AMS.Core.Enum;

namespace AMS.Core.Dto.UpdateDto
{
    public class SparePartUpdateDto
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int? Quantity { get; set; }

        public double? PricePerOne { get; set; }

        public UnitType? UnitType { get; set; }
    }
}