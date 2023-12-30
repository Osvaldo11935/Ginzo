using Domain.Entities;

namespace Domain.Common.Aggregates;

public class SchoolYearAggregate
{
    #region Write
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startYear"></param>
    /// <param name="endYear"></param>
    /// <returns></returns>
    public SchoolYear AddSchoolYear(int startYear, int endYear)
        => new SchoolYear {
            StartYear = startYear,
            EndYear = endYear,
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public AcademicLevel AddAcademicLevel(int level)
        => new AcademicLevel {
            Level = level
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="schoolYearId"></param>
    /// <param name="academicLevelId"></param>
    /// <param name="courseId"></param>
    /// <returns></returns>
    public Class AddClass(string? name, string schoolYearId, string? academicLevelId, string? courseId)
        => new Class {
           Name = name,
           CourseId = courseId,
           SchoolYearId = schoolYearId,
           AcademicLevelId = academicLevelId
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="scheduleIds"></param>
    /// <returns></returns>
    public List<ScheduleClass> AddClassSchedule(string? classId, List<string> scheduleIds)
        => scheduleIds.Select(e => new ScheduleClass {
            ClassId = classId,
            ScheduleId = e
        }).ToList();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="studentIds"></param>
    /// <returns></returns>
    public List<Student> AddStudentClass(string? classId, List<string> studentIds)
        => studentIds.Select(e => new Student {
            ClassId = classId,
            UserId = e
        }).ToList();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="scheduleId"></param>
    /// <returns></returns>
    public ScheduleClass AddScheduleClass(string? classId, string scheduleId)
        => new ScheduleClass {
            ClassId = classId,
            ScheduleId = scheduleId
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dayWeek"></param>
    /// <param name="entryDate"></param>
    /// <param name="exitDate"></param>
    /// <param name="schoolYearId"></param>
    /// <returns></returns>
    public Schedule AddSchedule(string?  dayWeek, DateTime entryDate, DateTime exitDate, string? schoolYearId)
        => new Schedule {
            DayWeek = dayWeek,
            EntryDate = entryDate,
            ExitDate = exitDate,
            SchoolYearId = schoolYearId
        };
     
    #endregion
}