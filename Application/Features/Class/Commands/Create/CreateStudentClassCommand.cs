using MediatR;

namespace Application.Features.Class.Commands.Create;

public class CreateStudentClassCommand: IRequest<bool>
{
    public string? ClassId { get; set; }
    public List<string>? StudentIds { get; set; }

    public CreateStudentClassCommand(List<string>? studentIds, string? classId)
    {
        ClassId = classId;
        StudentIds = studentIds;
    }
    
    public static implicit operator CreateStudentClassCommand((string? classId, List<string>? studentIds) value)
        => new (value.studentIds, value.classId);
}