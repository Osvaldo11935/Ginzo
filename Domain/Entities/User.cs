using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User: IdentityUser
{
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? DocumentNumber { get; set; }
    
    public virtual Address? Address { get; set; }
    public virtual PersonalData? PersonalData { get; set; }
    public virtual IList<Student>? Students { get; set; }
    public virtual IList<Enrollment>? Enrollments { get; set; }
    public virtual IList<UserRole>? UserRoles { get; set; }
}