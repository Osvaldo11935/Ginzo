using MediatR;

namespace Application.Features.Course.Commands.Create;

public class CreateCourseCommand: IRequest<string>
{
    public string? Name { get; set; }
}