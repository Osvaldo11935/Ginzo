using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class Role: IdentityRole<string>
{
    public virtual IList<UserRole>? UserRoles { get; set; }
}