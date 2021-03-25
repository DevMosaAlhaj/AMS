using System;
using System.Collections.Generic;

namespace AMS.Core.Dto.UpdateDto
{
    public class SparePartSoldUpdateDto
    {
        
        public int Id { get; set; }
        
        public DateTime? SaleAt { get; set; }

        public int? ClientId { get; set; }

        public int? MotorId { get; set; }

        public List<int> SparePartsId { get; set; }

        public List<int> SalesStaffId { get; set; }
    }
}