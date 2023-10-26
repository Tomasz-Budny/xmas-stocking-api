using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.DAL.Persistance.Configurations
{
    internal class DrawConfiguration : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            builder.ToTable("draws");
            builder.HasKey(x => x.Id);
            builder.OwnsMany(x => x.Attendees, ab =>
            {
                ab.ToTable("attendees");
                ab.HasKey(x => x.Id);
                ab.WithOwner().HasForeignKey("drawId");
            });
        }
    }
}
