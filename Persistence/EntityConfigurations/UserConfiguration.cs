using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration: IEntityTypeConfiguration< User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => new { e.Id });
        
    }
}