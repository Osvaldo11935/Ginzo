using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class EnrollmentResponse
{
    public double FinalAverage { get; set; }
    public UserResponse? User { get; set; }
    public EnrollmentStatusResponse? EnrollmentStatus { get; set; }
    public List<EnrollmentCourseResponse>? EnrollmentCourse { get; set; }

    public static List<EnrollmentResponse> EnrollmentToEnrollmentResponse(List<Enrollment> enrollments)
        => enrollments.Select(e => new EnrollmentResponse
        {
            FinalAverage = e.FinalAverage,
            User = UserResponse.UserToUserResponse(e.Student!),
            EnrollmentCourse =
                EnrollmentCourseResponse.EnrollmentCourseToEnrollmentCourseResponse(e.EnrollmentCourses!.ToList())
        }).ToList();
}