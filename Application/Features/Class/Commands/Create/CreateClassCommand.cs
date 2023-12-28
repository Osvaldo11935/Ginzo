using MediatR;

namespace Application.Features.Class.Commands.Create;

public class CreateClassCommand: IRequest<string>
{
    public string? Name { get; set; }
    
}