using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EnrollmentParameterConfiguration: IEntityTypeConfiguration<EnrollmentParameter>
{
    public void Configure(EntityTypeBuilder<EnrollmentParameter> builder)
    {
        builder.HasKey(e => new { e.Id });
        
        builder.HasOne(e => e.SchoolYear)
            .WithMany(e => e.EnrollmentParameters)
            .HasForeignKey(e => e.SchoolYearId);
        
    }
}