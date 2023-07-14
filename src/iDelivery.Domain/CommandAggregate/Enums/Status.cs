namespace iDelivery.Domain.CommandAggregate.Enums;

public enum Status
{
    Pending,
    Processing,
    Transit,
    Delivering,
    Delivered,
    Gathering,
    Returning,
    Returned
}
