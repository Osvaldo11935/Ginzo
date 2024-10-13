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
        => new Course
        {
            Name = name
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Discipline AddDiscipline(string? name)
        => new Discipline
        {
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
        => new DisciplineCourse
        {
            IsKey = isKey,
            CourseId = courseId,
            DisciplineId = disciplineId
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="totalVacancy"></param>
    /// <param name="enrollmentParameterId"></param>
    /// <returns></returns>
    public VacancyCourse AddVacancyCourse(string? courseId, int totalVacancy, string enrollmentParameterId)
        => new VacancyCourse
        {
           CourseId = courseId,
           TotalVacancy = totalVacancy,
           EnrollmentParameterId = enrollmentParameterId
        };
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseId"></param>
    /// <param name="disciplines"></param>
    /// <returns></returns>
    public List<DisciplineCourse> AddCourseDiscipline(string? courseId, Dictionary<string, bool> disciplines)
        => disciplines.Select(e => new DisciplineCourse
        {
            IsKey = e.Value,
            CourseId = courseId,
            DisciplineId = e.Key
        }).ToList();

    #endregion
}