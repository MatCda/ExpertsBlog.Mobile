using System;

namespace ExpertsBlog.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}