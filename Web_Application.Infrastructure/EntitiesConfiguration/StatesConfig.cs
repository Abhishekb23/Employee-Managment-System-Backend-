using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Entities;

namespace Infrastructure.EntitiesConfiguration
{
    class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
