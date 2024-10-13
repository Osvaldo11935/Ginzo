using MediatR;

namespace Application.Features.Class.Commands.Create;

public class CreateClassScheduleCommand: IRequest<bool>
{
    public string? ClassId { get; set; }
    public List<string>? ScheduleIds { get; set; }

    public CreateClassScheduleCommand(string? classId, List<string>? scheduleIds)
    {
        ClassId = classId;
        ScheduleIds = scheduleIds;
    }

    public static implicit operator CreateClassScheduleCommand((string? classId, List<string>? scheduleIds) value)
      => new (value.classId, value.scheduleIds);
}