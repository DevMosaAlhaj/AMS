using System;

namespace AMS.Data.DbEntity
{
    public class BaseDbEntity
    {

        public BaseDbEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
        
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string UpdatedBy { get; set; }

        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
    }
}