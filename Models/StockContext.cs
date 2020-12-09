using Microsoft.EntityFrameworkCore;

namespace Stock.Models
{
    public class StockContext: DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            :base(options)
        {}
        public DbSet<Stock> Stocks { get; set; }
    }
}