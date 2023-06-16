using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.Common.Enums;
using iDelivery.Domain.PlanAggregate.ValueObjects;
using iDelivery.Domain.PlanAggregate;

namespace iDelivery.Domain.AccountAggregate.Entities;
public sealed class Subscription : AggregateRoot<SubscriptionId>
{
    public AccountId AccountId { get; private set; }
    public PlanId PlanId{ get; private set; }
    public Plan Plan { get; private set; } = null!;
    public Account Account { get; private set; } = null!;
    public DateTime ValidTo { get; private set; }
    public bool IsValid { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public SubscriptionType Type { get; private set; }
    public PaymentMode PaymentMode { get; private set; }
    private Subscription(
        AccountId accountId,
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
        AccountId = accountId;
    }

    #pragma warning disable CS8618
    private Subscription()
    {

    }
    #pragma warning restore CS8618
    public static Subscription Create(
        AccountId accountId,
        PlanId planId,
        DateTime validTo,
        bool isValid,
        DateTime createdDate,
        SubscriptionType type,
        PaymentMode paymentMode)
    {
        return new(
            accountId,
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
