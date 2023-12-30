using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PersonalDataConfiguration: IEntityTypeConfiguration<PersonalData>
{
    public void Configure(EntityTypeBuilder<PersonalData> builder)
    {
        builder.HasKey(e => new { e.Id });
        
        builder.HasOne(e => e.User)
            .WithOne(e => e.PersonalData)
            .HasForeignKey<PersonalData>(e => e.UserId);
        
    }
}