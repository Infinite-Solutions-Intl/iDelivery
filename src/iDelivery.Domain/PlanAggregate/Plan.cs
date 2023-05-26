using iDelivery.Domain.PlanAggregate.ValueObjects;
using iDelivery.Domain.SubscriptionAggregate.ValueObjects;

namespace iDelivery.Domain.PlanAggregate;
public sealed class Plan : AggregateRoot<PlanId>
{
    private readonly List<SubscriptionId> _subscriptionIds = new();
    public IReadOnlyList<SubscriptionId> SubscriptionIds => _subscriptionIds.AsReadOnly();
    public string Name {get; set;}
    public TimeSpan Duration {get; private set;}
    public Decimal Price {get; private set;}
    public string Currency {get;  set;}

    private Plan (
        PlanId id,
        string name,
        TimeSpan duration,
        Decimal price,
        string currency): base(id)
        {
            Name=name;
            Duration=duration;
            Price=price;
            Currency=currency;
        }
        public static Plan Create(
        string name,
        TimeSpan duration,
        Decimal price,
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