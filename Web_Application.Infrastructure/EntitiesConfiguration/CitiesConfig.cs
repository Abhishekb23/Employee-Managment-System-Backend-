using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Entities;

namespace Infrastructure.EntitiesConfiguration
{
    class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasOne<State>().WithMany().HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
