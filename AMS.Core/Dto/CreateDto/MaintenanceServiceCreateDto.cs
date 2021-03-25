using System;

namespace AMS.Core.Dto.CreateDto
{
    public class MaintenanceServiceCreateDto
    {
        
        public DateTime EntryAt { get; set; }

        public string TransportDescription { get; set; }

        public int WorkshopOfficialId { get; set; }
        
        public int PriceOfferId { get; set; }

        public int ClientId { get; set; }
        
        public int MotorId { get; set; }
    }
}