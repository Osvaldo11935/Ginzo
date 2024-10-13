using MediatR;

namespace Application.Features.Course.Commands.Create;

public class CreateCourseCommand: IRequest<string>
{
    public string? Name { get; set; }

    public CreateCourseCommand(string? name)
    {
        Name = name;
    }

    public static implicit operator CreateCourseCommand(string name)
        => new(name);
}