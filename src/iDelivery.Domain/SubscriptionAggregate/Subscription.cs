using iDelivery.Domain.SubscriptionAggregate.Enums;
using iDelivery.Domain.SubscriptionAggregate.ValueObjects;

namespace iDelivery.Domain.SubscriptionAggregate;
public sealed class Subscription : AggregateRoot<SubscriptionId>
{
    public DateTime ValidTo {get; private set;} // permet de modifier les propriété de la classe uniquement à l'interieur
    public bool IsValid {get; private set;}
    public DateTime CreatedDate {get; private set;}
    public SubscriptionType Type {get; private set;}
    public PaymentMode PaymentMode {get; private set;}
    private Subscription(
        SubscriptionId id,
        DateTime validTo,
        bool isValid,
        DateTime createdDate,
        SubscriptionType type,
        PaymentMode paymentMode) : base(id) 
    {
        ValidTo= validTo ;
        IsValid = IsValid;
        this.CreatedDate = createdDate;
        Type = type;
        PaymentMode = paymentMode;
    }
    public static Subscription Create(
        DateTime validTo,
        bool isValid,
        DateTime createdDate,
        SubscriptionType type,
        PaymentMode paymentMode)
        {
            return new(
                SubscriptionId.CreateUnique(),
                validTo,
                isValid,
                createdDate,
                type,
                paymentMode
            );
        } 

}

