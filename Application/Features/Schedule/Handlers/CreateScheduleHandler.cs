using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Schedule.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Schedule.Handlers;

public class CreateScheduleHandler : HandlerBase, IRequestHandler<CreateScheduleCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Schedule> _scheduleRepository;

    public CreateScheduleHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _scheduleRepository = unitOfWork.AsyncRepository<Domain.Entities.Schedule>();
    }

    #endregion


    public async Task<string> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        Domain.Entities.Schedule schedule = schoolYearAggregate.AddSchedule(request.DayWeek, request.EntryDate,
            request.ExitDate, request.SchoolYearId);
        
        await _scheduleRepository.InsertAsync(schedule);

        return schedule.Id!;
    }
}