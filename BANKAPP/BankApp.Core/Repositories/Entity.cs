using System;

namespace BankApp.Core.Repositories
{
    public abstract class Entity<TId>
    {
        public required TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedDate { get; set; }

        protected Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
} 