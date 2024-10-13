using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class VacancyCourseResponse
{
    public string? Id { get; set; }
    public int TotalVacancy { get; set; }
    public virtual CourseResponse? Course { get; set; }
    
    public static List<VacancyCourseResponse> VacancyCourseToVacancyCourseResponse(List<VacancyCourse> vacancyCourses)
        => vacancyCourses.Select(e => new VacancyCourseResponse
        {
            Id = e.Id,
            TotalVacancy = e.TotalVacancy,
            Course = CourseResponse.CourseToCourseResponse(e.Course!)
        }).ToList();

}