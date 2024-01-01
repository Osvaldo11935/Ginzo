using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class StudentResponse : UserResponse
{
    public ClassResponse? Class { get; set; }

    public static List<StudentResponse> StudentToStudentResponse(List<Student> students)
        => students.Select(e => new StudentResponse()
        {
            Name = e.User!.Name,
            Email = e.User.Email,
            BirthDate = e.User.BirthDate,
            PhoneNumber = e.User.PhoneNumber,
            DocumentNumber = e.User.DocumentNumber,
            Class = new ClassResponse()
            {
                Name = e.Class!.Name,
                Course = new CourseResponse()
                {
                    Name = e.Class.Course!.Name
                }
            }
        }).ToList();
}