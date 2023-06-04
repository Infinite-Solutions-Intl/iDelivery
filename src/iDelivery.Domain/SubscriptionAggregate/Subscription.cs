using iDelivery.Domain.PlanAggregate.ValueObjects;
using iDelivery.Domain.SubscriptionAggregate.Enums;
using iDelivery.Domain.SubscriptionAggregate.ValueObjects;

namespace iDelivery.Domain.SubscriptionAggregate;
public sealed class Subscription : AggregateRoot<SubscriptionId>
{
    public PlanId PlanId{ get; set; }
    public DateTime ValidTo { get; private set; }
    public bool IsValid { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public SubscriptionType Type { get; private set; }
    public PaymentMode PaymentMode { get; private set; }
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
        IsValid = IsValid;
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

