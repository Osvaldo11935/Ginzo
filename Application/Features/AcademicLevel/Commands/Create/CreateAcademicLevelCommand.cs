using Application.Features.Class.Commands.Create;
using MediatR;

namespace Application.Features.AcademicLevel.Commands.Create;

public class CreateAcademicLevelCommand
{
    public int Level { get; set; }

    public CreateAcademicLevelCommand(int level)
    {
        Level = level;
    }
    public static implicit operator CreateAcademicLevelCommand(int level)
        => new(level);
}