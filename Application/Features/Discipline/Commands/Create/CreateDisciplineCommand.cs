using MediatR;

namespace Application.Features.Discipline.Commands.Create;

public class CreateDisciplineCommand: IRequest<string>
{
    public string? Name { get; set; }
}