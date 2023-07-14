using iDelivery.Domain.CommandAggregate.Entities;
using MediatR;

namespace iDelivery.Domain.CommandAggregate.Events;

public sealed record CommandStatusUpdated(
    DeliveryStatus DeliveryStatus
) : INotification;
