using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared;
using Stock.API.Contexts;

namespace Stock.API.Consumers
{
    public class PaymentFailedEventConsumer : IConsumer<PaymentFailedEvent>
    {
        private readonly StockDbContext _context;
        private ILogger<OrderCreatedEventConsumer> _logger;


        public PaymentFailedEventConsumer(StockDbContext context, ILogger<OrderCreatedEventConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            foreach (var item in context.Message.OrderItems)
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(x=>x.ProductId == item.ProductId);

                if (stock != null)
                {
                    stock.Count += item.Count;
                    await _context.SaveChangesAsync();
                }
            }

            _logger.LogInformation($"Stock was release for order id ({context.Message.OrderId})");
        }
    }
}
