using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(e => new { e.Id });
        
        builder.HasOne(e => e.User)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.UserId);
        
        builder.HasOne(e => e.Class)
            .WithMany(e => e.Students)
            .HasForeignKey(e => e.ClassId);
    }
}