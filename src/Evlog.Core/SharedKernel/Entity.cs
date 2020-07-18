using MediatR;
using System;
using System.Collections.Generic;

namespace Evlog.Core.SharedKernel
{
    // Adapted from: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces
    public abstract class Entity
    {
        private int? requestedHashCode;
        
        private int id;
        public virtual int Id
        {
            get => id;
            protected set => id = value;
        }
        public bool IsTransient => Id is default(int);

        private List<INotification>? domainEvents;
        public List<INotification>? DomainEvents => domainEvents;
        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents = domainEvents ?? new List<INotification>();
            domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (domainEvents is null) return;
            domainEvents.Remove(eventItem);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity)) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;

            Entity item = (Entity)obj;
            if (item.IsTransient || this.IsTransient) return false;
            else return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (IsTransient) return base.GetHashCode();
            
            if (!requestedHashCode.HasValue)
                requestedHashCode = this.Id.GetHashCode() ^ 31;
            // XOR for random distribution. See:
            // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
            return requestedHashCode.Value;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null)) return (Object.Equals(right, null));
            else return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}
