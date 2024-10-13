using Domain.Common.ValueObjects;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EnrollmentStatusConfiguration: IEntityTypeConfiguration<EnrollmentStatus>
{
    public void Configure(EntityTypeBuilder<EnrollmentStatus> builder)
    {
        builder.HasKey(e => new { e.Id });
        builder.HasData(EnrollmentStatusValueObject.AddEnrollmentStatus());
    }
}