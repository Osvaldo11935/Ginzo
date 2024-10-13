using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VacancyCourseConfiguration: IEntityTypeConfiguration<VacancyCourse>
{
    public void Configure(EntityTypeBuilder<VacancyCourse> builder)
    {
        builder.HasKey(e => new { e.Id });
        
        builder.HasOne(e => e.EnrollmentParameter)
            .WithMany(e => e.VacancyCourses)
            .HasForeignKey(e => e.EnrollmentParameterId);
        
        builder.HasOne(e => e.Course)
            .WithOne(e => e.VacancyCourse)
            .HasForeignKey<VacancyCourse>(e => e.CourseId);

    }
}