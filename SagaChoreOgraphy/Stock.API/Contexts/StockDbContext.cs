using Microsoft.EntityFrameworkCore;

namespace Stock.API.Contexts
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }
        public DbSet<Stock.API.Dtos.Stock> Stocks { get; set; }
    }
}
