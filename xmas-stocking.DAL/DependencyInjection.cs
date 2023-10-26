using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xmas_stocking.DAL.Options;
using xmas_stocking.DAL.Persistance;
using xmas_stocking.DAL.Shared;

namespace xmas_stocking.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlOptions>(SqlOptions.SectionName);

            services.AddDbContext<XmasStockingDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
