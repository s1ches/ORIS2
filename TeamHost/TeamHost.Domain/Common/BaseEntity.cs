using TeamHost.Domain.Common.Interfaces;

namespace TeamHost.Domain.Common;

public abstract class BaseEntity : IEntity
{
    private readonly List<BaseEvent> _domainEvents = [];
    
    public int Id { get; set; }
    
    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear(); 
}