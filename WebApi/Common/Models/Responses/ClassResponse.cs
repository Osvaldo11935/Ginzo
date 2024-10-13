using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class ClassResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public CourseResponse? Course { get; set; }
    
    
    public static List<ClassResponse>ClassToClassResponse(List<Class> classes)
        => classes.Select(e => new ClassResponse
        {
            Id = e.Id,
            Name = e.Name,
            Course = CourseResponse.CourseToCourseResponse(e.Course!)
            
        }).ToList();

    public static ClassResponse ScheduleToScheduleResponse(Class @class)
        => new ClassResponse
        {
            Id = @class.Id,
            Name = @class.Name,
            Course = CourseResponse.CourseToCourseResponse(@class.Course!)

        };
}