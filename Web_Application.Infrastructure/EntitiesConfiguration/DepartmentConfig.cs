using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Entities;

namespace Infrastructure.EntitiesConfiguration
{
    class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name) .HasMaxLength(100).IsRequired().HasColumnName("Name");
        }
    }
}
