using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Commands.Create;
using Application.Features.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Class.Handlers;

public class CreateClassScheduleScheduleHandler : HandlerBase, IRequestHandler<CreateClassScheduleCommand, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Class> _classRepository;
    private readonly IGenericRepository<Domain.Entities.Schedule> _scheduleRepository;
    public CreateClassScheduleScheduleHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _classRepository = unitOfWork.AsyncRepository<Domain.Entities.Class>();
        _scheduleRepository = unitOfWork.AsyncRepository<Domain.Entities.Schedule>();
    }

    #endregion


    public async Task<bool> Handle(CreateClassScheduleCommand request, CancellationToken cancellationToken)
    {

        Domain.Entities.Class @class = await _classRepository.SelectAsync(e => e.Id == request.ClassId);
        
        List<Domain.Entities.Schedule> schedules = await _scheduleRepository
            .SelectAllAsync(e => request.ScheduleIds!.Contains(e.Id!))
            .ToListAsync(cancellationToken);
        
        schedules.ForEach(e => @class.Schedules?.Add(e));
        
        await _classRepository.InsertAsync(@class);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return true;
    }
}