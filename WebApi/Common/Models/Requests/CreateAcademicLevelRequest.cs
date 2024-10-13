using Application.Features.AcademicLevel.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateAcademicLevelRequest
{
    public int Level { get; set; }

    public static List<CreateAcademicLevelCommand> Parsing(List<CreateAcademicLevelRequest> requests)
        => requests.Select(e => (CreateAcademicLevelCommand)e.Level).ToList();
}