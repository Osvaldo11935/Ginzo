using Domain.Entities;

namespace Domain.Common.Aggregates;

public class CourseAggregate
{
    #region Write

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Course AddCourse(string name)
        => new Course {
            Name = name
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Discipline AddDiscipline(string? name)
        => new Discipline {
            Name = name
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="disciplineId"></param>
    /// <param name="isKey"></param>
    /// <returns></returns>
    public DisciplineCourse AddCourseDiscipline(string? courseId, string disciplineId, bool isKey)
        => new DisciplineCourse {
            IsKey = isKey,
            CourseId = courseId,
            DisciplineId = disciplineId
        };

    #endregion
}