using Microsoft.EntityFrameworkCore;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.DAL.Persistance
{
    internal class XmasStockingDbContext : DbContext
    {
        public XmasStockingDbContext(DbContextOptions<XmasStockingDbContext> options) : base(options) { }

        public DbSet<Draw> draws { get; set; } = null;
    }
}
