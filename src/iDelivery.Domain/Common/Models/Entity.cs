using MediatR;

namespace iDelivery.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
	where TId : notnull
{
    private readonly List<INotification> _domainEvents = new();
    public IReadOnlyList<INotification> DomainEvents => _domainEvents.AsReadOnly();
    public TId Id { get; protected set; }

	protected Entity(TId id)
	{
		Id = id;
	}

    #pragma warning disable CS8618
    protected Entity()
    {
        
    }
    #pragma warning restore CS8618

	public override bool Equals(object? obj)
	{
		return obj is Entity<TId> other && Id.Equals(other.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void RaiseDomainEvent(INotification @event)
    {
        _domainEvents.Add(@event);
    }
}
