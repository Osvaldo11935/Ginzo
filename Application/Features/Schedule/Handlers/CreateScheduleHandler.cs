using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Application.Features.Schedule.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Schedule.Handlers;

public class CreateScheduleHandler : HandlerBase, 
    IRequestHandler<BaseCommand<List<CreateScheduleCommand>, bool>, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Schedule> _scheduleRepository;

    public CreateScheduleHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _scheduleRepository = unitOfWork.AsyncRepository<Domain.Entities.Schedule>();
    }

    #endregion


    public async Task<bool> Handle(BaseCommand<List<CreateScheduleCommand>, bool> requests, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();
        
        List<Domain.Entities.Schedule> schedules =
            requests.Request!.Select(request => schoolYearAggregate
                .AddSchedule(request.DayWeek, request.EntryDate, request.ExitDate, request.SchoolYearId)).ToList();
        
        
        await _scheduleRepository.InsertAsync(schedules);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}