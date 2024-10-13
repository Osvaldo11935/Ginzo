using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class CourseResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    
    public static List<CourseResponse> CourseToCourseResponse(List<Course> courses)
        => courses.Select(e => new CourseResponse
        {
            Id = e.Id,
            Name = e.Name
        }).ToList();
    
    public static CourseResponse CourseToCourseResponse(Course course)
        => new CourseResponse
        {
            Id = course.Id,
            Name = course.Name
        };
}