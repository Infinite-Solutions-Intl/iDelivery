namespace iDelivery.Contracts.Commands;
public record AddCourierRequest(
    Guid CommandId,
    Guid CourierId
);