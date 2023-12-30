using Domain.Entities.Common;

namespace Domain.Entities;

public class AcademicLevel: EntityBase
{
    public int Level { get; set; }
    public virtual IList<Class>? Classes { get; set; }
}