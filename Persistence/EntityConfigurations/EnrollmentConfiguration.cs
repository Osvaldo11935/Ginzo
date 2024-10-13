using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EnrollmentConfiguration: IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Student)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.StudentId);
        
        builder.HasOne(e => e.EnrollmentParameter)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.EnrollmentParameterId);
        
        builder.HasOne(e => e.EnrollmentStatus)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.EnrollmentStatusId);
    }
}