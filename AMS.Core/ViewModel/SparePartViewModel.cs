namespace AMS.Core.ViewModel
{
    public class SparePartViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double PricePerOne { get; set; }
        
        public double TotalPrice { get; set; }

        public string UnitType { get; set; }
        
    }
}