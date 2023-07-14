using iDelivery.Domain.CommandAggregate.ValueObjects;
using MediatR;

namespace iDelivery.Domain.CommandAggregate.Events;

public sealed record CommandCreated(
    CommandId CommandId,
    DateTime Date
) : INotification;
