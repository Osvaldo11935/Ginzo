using Application.Features.VacancyCourse.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateVacancyCourseRequest
{
    public int TotalVacancy { get; set; }
    public string? CourseId { get; set; }
    public static List<CreateVacancyCourseCommand> Parsing(List<CreateVacancyCourseRequest> requests, string enrollmentParameterId)
        => requests.Select(request => (CreateVacancyCourseCommand) (request.CourseId, request.TotalVacancy, enrollmentParameterId)).ToList();
}