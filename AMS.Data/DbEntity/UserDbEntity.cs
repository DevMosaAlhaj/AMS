using System;
using AMS.Core.Enum;
using Microsoft.AspNetCore.Identity;

namespace AMS.Data.DbEntity
{
    public class UserDbEntity : IdentityUser
    {

        public UserDbEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        
        public DateTime? LastSeen { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public int ForEmpId { get; set; }

        public EmployeeDbEntity ForEmp { get; set; }

        public UserType UserType { get; set; }

        public string FcmToken { get; set; }

        public string RefreshToken { get; set; }

    }
}