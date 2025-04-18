using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Entities;

namespace Web_Application.Infrastructure.EntitiesConfiguration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(120).HasColumnName("Name").IsRequired();
            builder.Property(e => e.DOB).HasColumnType("DATE").IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(256).HasColumnType("varchar(256)").HasConversion(email => email.ToLower(), email => email);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Address).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Zip).IsRequired().HasMaxLength(6).HasColumnType("int");
            builder.Property(e => e.DOJ).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.DOL).HasColumnType("DATETIME");
            builder.Property(e => e.CreatedOn).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.UpdatedOn).HasColumnType("DATETIME").IsRequired();
            builder.HasOne<Department>().WithMany().HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<City>().WithMany().HasForeignKey(e => e.CityId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}