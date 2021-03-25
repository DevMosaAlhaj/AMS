using System;
using System.Collections.Generic;

namespace AMS.Core.ViewModel
{
    public class SparePartSoldViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public DateTime SaleAt { get; set; }

        public int ClientId { get; set; }

        public int MotorId { get; set; }

        public List<int> SpareParts { get; set; }

        public List<int> SalesStaff { get; set; }
    }
}