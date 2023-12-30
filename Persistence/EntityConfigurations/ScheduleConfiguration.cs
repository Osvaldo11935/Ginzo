using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ScheduleConfiguration: IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(e => new { e.Id });
        
        builder.HasOne(e => e.SchoolYear)
            .WithMany(e => e.Schedules)
            .HasForeignKey(e => e.SchoolYearId);
        
    }
}