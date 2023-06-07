using iDelivery.Domain.PlanAggregate.ValueObjects;
using iDelivery.Domain.SubscriptionAggregate.Enums;
using iDelivery.Domain.SubscriptionAggregate.ValueObjects;

namespace iDelivery.Domain.SubscriptionAggregate;
public sealed class Subscription : AggregateRoot<SubscriptionId>
{
    public PlanId PlanId{ get; set; }
    public DateTime ValidTo { get; }
    public bool IsValid { get; }
    public DateTime CreatedDate { get; }
    public SubscriptionType Type { get; }
    public PaymentMode PaymentMode { get; }
    private Subscription(
        SubscriptionId id,
        DateTime validTo,
        bool isValid,
        DateTime createdDate,
        SubscriptionType type,
        PaymentMode paymentMode,
        PlanId planId) : base(id)
    {
        ValidTo= validTo ;
        IsValid = isValid;
        CreatedDate = createdDate;
        Type = type;
        PaymentMode = paymentMode;
        PlanId = planId;
    }
    public static Subscription Create(
        DateTime validTo,
        bool isValid,
        DateTime createdDate,
        SubscriptionType type,
        PaymentMode paymentMode,
        PlanId planId)
        {
            return new(
                SubscriptionId.CreateUnique(),
                validTo,
                isValid,
                createdDate,
                type,
                paymentMode,
                planId
            );
        }
}
