namespace EventBus.Messages.Events
{
    public sealed class OrderIsReadyEvent : IntegrationBaseEvent
    {
        public long OrderId { get; }
        public string PhoneNumber { get; }
        public string ShipAddress { get; }

        public OrderIsReadyEvent(long orderId, string phoneNumber, string shipAddress)
        {
            OrderId = orderId;
            PhoneNumber = phoneNumber;
            ShipAddress = shipAddress;
        }
    }
}
