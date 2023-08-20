using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetPcRekrutacjaBackend.Domain.Employee;

namespace NetPcRekrutacjaBackend.Infrastructure
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Employee_ID")
                .IsRequired();

            builder.OwnsOne(e => e.Details, employeeDetails =>
            {
                employeeDetails.Property(d => d.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255);

                employeeDetails.Property(d => d.Surname)
                    .HasColumnName("Surname")
                    .IsRequired()
                    .HasMaxLength(255);

                employeeDetails.Property(d => d.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(255);

                employeeDetails.Property(d => d.Password)
                    .HasColumnName("Password")
                    .IsRequired()
                    .HasMaxLength(255);
                employeeDetails.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(255);
                employeeDetails.Property(e => e.Birthdate)
                    .HasColumnName("Birthdate")
                    .IsRequired();

            });
            builder.OwnsOne(e => e.Contact, contact =>
            {
                contact.Property(c => c.Category)
                    .HasColumnName("Category")
                    .HasMaxLength(255)
                    .HasConversion<string>();

                contact.Property(c => c.Subcategory)
                    .HasColumnName("Subcategory")
                    .HasMaxLength(255);
            });
        }
    }
}

