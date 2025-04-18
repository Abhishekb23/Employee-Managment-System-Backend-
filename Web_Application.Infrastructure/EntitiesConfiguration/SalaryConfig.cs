using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Entities;

namespace Infrastructure.EntitiesConfiguration
{
    class SalaryConfig : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(e => e.Amount).HasColumnType("decimal(8,3)").IsRequired().HasDefaultValue(0);
            builder.Property(s => s.Year).IsRequired();
            builder.Property(s => s.Month).IsRequired();
            builder.Property(s => s.CreatedOn).HasColumnType("DATETIME").IsRequired();
            builder.HasOne<Employee>().WithMany().HasForeignKey(s => s.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

