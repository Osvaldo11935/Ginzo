using Application.Features.AcademicLevel.Commands.Create;
using Application.Features.Discipline.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateDisciplineRequest
{
    public string? Name { get; set; }
    public static List<CreateDisciplineCommand> Parsing(List<CreateDisciplineRequest> requests)
        => requests.Select(request => (CreateDisciplineCommand) request.Name!).ToList();
    
}