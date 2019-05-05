using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Memo.Core
{

    public abstract class Entity
    {
        protected Entity()
        {
            _events = new List<IDomainEvent>();
        }

        int? _requestedHashCode;
        public Guid Id { get; set; }

        private readonly List<IDomainEvent> _events;
        public IReadOnlyCollection<IDomainEvent> Events => new ReadOnlyCollection<IDomainEvent>(_events);

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));
            _events.Add(domainEvent);
        }

        public void ClearDomianEvents()
        {
            _events.Clear();
        }

        public bool IsTransient()
        {
            return Id == default(Guid);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

    }
}
