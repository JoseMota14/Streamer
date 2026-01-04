using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain
{
    public abstract class Entity
    {
        private readonly List<DomainEvent> _domainEvents = new();

        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(DomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);

        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
