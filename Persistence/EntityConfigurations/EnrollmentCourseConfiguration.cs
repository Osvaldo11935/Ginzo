using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EnrollmentCourseConfiguration: IEntityTypeConfiguration<EnrollmentCourse>
{
    public void Configure(EntityTypeBuilder<EnrollmentCourse> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Enrollment)
            .WithMany(e => e.EnrollmentCourses)
            .HasForeignKey(e => e.EnrollmentId);
        
        builder.HasOne(e => e.Course)
            .WithMany(e => e.EnrollmentCourses)
            .HasForeignKey(e => e.CourseId);
    }
}