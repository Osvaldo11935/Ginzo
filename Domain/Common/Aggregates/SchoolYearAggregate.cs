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
    /// <param name="name"></param>
    /// <param name="schoolYearId"></param>
    /// <returns></returns>
    public Class AddClass(string? name, string schoolYearId)
        => new Class {
           Name = name,
           SchoolYearId = schoolYearId
        };
    
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