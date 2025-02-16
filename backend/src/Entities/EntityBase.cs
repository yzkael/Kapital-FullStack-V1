using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
        public DateTimeOffset LastUpdateAt { get; private set; } = DateTimeOffset.UtcNow;

        public void SetLastUpdatedAt()
        {
            LastUpdateAt = DateTimeOffset.UtcNow;
        }
    }
}