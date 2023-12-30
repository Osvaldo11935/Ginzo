using MediatR;

namespace Application.Features.Discipline.Commands.Create;

public class CreateDisciplineCommand: IRequest<string>
{
    public string? Name { get; set; }
    
    public CreateDisciplineCommand(string? name)
    {
        Name = name;
    }
    public static implicit operator CreateDisciplineCommand(string name)
        => new(name);
}