using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class EnrollmentCourseResponse
{
    public CourseResponse? Course { get; set; }
    public List<EnrollmentCourseDisciplineResponse>? CourseDiscipline { get; set; }
    
    public static List<EnrollmentCourseResponse> EnrollmentCourseToEnrollmentCourseResponse(List<EnrollmentCourse> enrollmentCourses)
        => enrollmentCourses.Select(e => new EnrollmentCourseResponse
        {
            Course = CourseResponse.CourseToCourseResponse(e.Course!),
            CourseDiscipline = EnrollmentCourseDisciplineResponse.EnrollmentCourseDisciplineToEnrollmentCourseDisciplineResponse(e.EnrollmentCourseDisciplines!.ToList())
            
        }).ToList();
}