using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.PlanAggregate.ValueObjects;

namespace iDelivery.Domain.PlanAggregate;
public sealed class Plan : AggregateRoot<PlanId>
{
    private readonly List<Subscription> _subscriptions = new();
    public string Name { get; private set; }
    public TimeSpan Duration { get; private set; }
    public decimal Price { get; private set; }
    public string Currency { get; private set; }
    public IReadOnlyList<Subscription> Subscriptions => _subscriptions.AsReadOnly();

    private Plan (
        PlanId id,
        string name,
        TimeSpan duration,
        decimal price,
        string currency): base(id)
    {
        Name = name;
        Duration = duration;
        Price = price;
        Currency = currency;
    }

    #pragma warning disable CS8618
    private Plan()
    {
        
    }
    #pragma warning restore CS8618
    public static Plan Create(
        string name,
        TimeSpan duration,
        decimal price,
        string currency)
    {
        return new(
            PlanId.CreateUnique(),
            name,
            duration,
            price,
            currency
        );
    }
}
