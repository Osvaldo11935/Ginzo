using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisciplineCourseConfiguration: IEntityTypeConfiguration<DisciplineCourse>
{
    public void Configure(EntityTypeBuilder<DisciplineCourse> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Course)
            .WithMany(e => e.DisciplineCourses)
            .HasForeignKey(e => e.CourseId);
        
        builder.HasOne(e => e.Discipline)
            .WithMany(e => e.DisciplineCourses)
            .HasForeignKey(e => e.DisciplineId);
    }
}