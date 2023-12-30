using Domain.Entities.Common;

namespace Domain.Entities;

public class SchoolYear: EntityBase
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public virtual IList<Class>? Classes { get; set; }
    public virtual IList<Schedule>? Schedules { get; set; }
    
    public virtual IList<EnrollmentParameter>? EnrollmentParameters { get; set; }
}