using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Core.Constant
{
    public static class UserRole
    {

        public const string Accountant = "Accountant";
        public const string MaintenanceWorker = "MaintenanceWorker";
        public const string RegistryOfficer = "RegistryOfficer";
        public const string SuperAdmin = "SuperAdmin";
        public const string SuperAdminOrRegistryOfficer = SuperAdmin + "," + RegistryOfficer;
        public const string All = SuperAdmin + "," + RegistryOfficer + "," + MaintenanceWorker + "," + Accountant;
        public const string AllWithoutAccountant = SuperAdmin + "," + RegistryOfficer + "," + MaintenanceWorker;
        public const string AllWithoutMaintenanceWorker = SuperAdmin + "," + RegistryOfficer + "," +  Accountant;

    }
}
