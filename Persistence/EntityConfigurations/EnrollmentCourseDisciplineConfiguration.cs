using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EnrollmentCourseDisciplineConfiguration: IEntityTypeConfiguration<EnrollmentCourseDiscipline>
{
    public void Configure(EntityTypeBuilder<EnrollmentCourseDiscipline> builder)
    {
        builder.HasKey(e => new { e.DisciplineId, e.EnrollmentCourseId });
        
        builder.HasOne(e => e.EnrollmentCourse)
            .WithMany(e => e.EnrollmentCourseDisciplines)
            .HasForeignKey(e => e.EnrollmentCourseId);
        
        builder.HasOne(e => e.Discipline)
            .WithMany(e => e.EnrollmentCourseDisciplines)
            .HasForeignKey(e => e.DisciplineId);
    }
}