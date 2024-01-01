// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Persistence.EntityConfigurations;
//
// public class ScheduleClassConfiguration: IEntityTypeConfiguration<ScheduleClass>
// {
//     public void Configure(EntityTypeBuilder<ScheduleClass> builder)
//     {
//         builder.HasKey(e => new { e.ClassId, e.ScheduleId });
//         
//         builder.HasOne(e => e.Class)
//             .WithMany(e => e.ScheduleClasses)
//             .HasForeignKey(e => e.ClassId);
//         
//         builder.HasOne(e => e.Schedule)
//             .WithMany(e => e.ScheduleClasses)
//             .HasForeignKey(e => e.ScheduleId);
//         
//     }
// }