using System;
using AMS.Core.Enum;
using AMS.Core.ViewModel;

namespace AMS.Core.Dto.UpdateDto
{
    public class MotorUpdateDto
    {
        
        public int Id { get; set; }
        
        public string Address { get; set; }

        public string MotorType { get; set; }
        
        public string MotorModel { get; set; }
        
        public string MotorNumber { get; set; }
        
        public int? MotorPower { get; set; }
        
        public string Charger { get; set; }

        public int OliCounter { get; set; }

        public string EngineType { get; set; }
        
        public string EngineModel { get; set; }
        
        public string EngineNumber { get; set; }
        
        public int? PreviousCounterReading { get; set; }
        
        public DateTime? PreviousCounterReadingAt { get; set; }
        
        public int? CurrentCounterReading { get; set; }
        
        public DateTime? CurrentCounterReadingAt { get; set; }

        public int? ClientId { get; set; }

        public MufflerType? MufflerType { get; set; }
    }
}