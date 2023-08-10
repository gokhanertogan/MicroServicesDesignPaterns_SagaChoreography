using SagaStateMachineWorkerService.Interfaces;
using Shared;

namespace SagaStateMachineWorkerService.Events
{
    public class OrderCreatedRequestEvent : IOrderCreatedRequestEvent
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
        public PaymentMessage Payment { get; set; }
    }
}
