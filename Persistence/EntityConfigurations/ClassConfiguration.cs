using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassConfiguration: IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.AcademicLevel)
            .WithMany(e => e.Classes)
            .HasForeignKey(e => e.AcademicLevelId);
        
        builder.HasOne(e => e.Course)
            .WithMany(e => e.Classes)
            .HasForeignKey(e => e.CourseId);
        
        builder.HasOne(e => e.SchoolYear)
            .WithMany(e => e.Classes)
            .HasForeignKey(e => e.SchoolYearId);
    }
}