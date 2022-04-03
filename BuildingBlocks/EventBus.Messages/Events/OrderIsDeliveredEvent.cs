namespace EventBus.Messages.Events
{
    public sealed class OrderIsDeliveredEvent : IntegrationBaseEvent
    {
        public long OrderId { get; }

        public OrderIsDeliveredEvent(long orderId)
        {
            OrderId = orderId;
        }
    }
}
