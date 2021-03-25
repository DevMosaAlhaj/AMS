using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Dto.SearchDto
{
    public class MotorSearchDto
    {

        public string Address { get; set; }

        public string MotorType { get; set; }

        public string MotorModel { get; set; }

        public string MotorNumber { get; set; }

        public int? MotorPower { get; set; }

        public string Charger { get; set; }

        public int? OliCounter { get; set; }

        public string EngineType { get; set; }

        public string EngineModel { get; set; }

        public string EngineNumber { get; set; }


    }
}
