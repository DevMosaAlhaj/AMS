using System;

namespace AMS.Core.ViewModel
{
    public class MaintenanceServiceViewModel : IBaseViewModel
    {
        public int Id { get; set; }
        
        public DateTime EntryAt { get; set; }

        public DateTime? ExitAt { get; set; }

        public string TransportDescription { get; set; }

        public string ExitNotes { get; set; }
        
        public int WorkshopOfficialId { get; set; }
        
        public int PriceOfferId { get; set; }

        public int ClientId { get; set; }
        
        public int MotorId { get; set; }
        
    }
}