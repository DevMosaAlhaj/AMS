using System;

namespace AMS.Data.DbEntity
{
    public class MaintenanceServiceDbEntity : BaseDbEntity
    {
        public DateTime EntryAt { get; set; }

        public DateTime? ExitAt { get; set; }

        public string TransportDescription { get; set; }

        public string ExitNotes { get; set; }

        public int WorkshopOfficialId { get; set; }
        public EmployeeDbEntity WorkshopOfficial { get; set; }

        public int PriceOfferId { get; set; }

        public PriceOfferDbEntity PriceOffer { get; set; }

        public int ClientId { get; set; }

        public ClientDbEntity Client { get; set; }

        public int MotorId { get; set; }
        public MotorDbEntity Motor { get; set; }
    }
}