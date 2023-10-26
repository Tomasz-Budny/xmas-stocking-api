using Microsoft.EntityFrameworkCore;
using xmas_stocking.DAL.Persistance.Configurations;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.DAL.Persistance
{
    internal class XmasStockingDbContext : DbContext
    {
        public XmasStockingDbContext(DbContextOptions<XmasStockingDbContext> options) : base(options) { }

        public DbSet<Draw> draws { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var drawConfiguration = new DrawConfiguration();
            modelBuilder.ApplyConfiguration(drawConfiguration);
        }
    }
}
