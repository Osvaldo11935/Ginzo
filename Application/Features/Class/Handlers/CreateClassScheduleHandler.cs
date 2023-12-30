using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Commands.Create;
using Application.Features.Common;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Class.Handlers;

public class CreateClassScheduleScheduleHandler : HandlerBase, IRequestHandler<CreateClassScheduleCommand, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.ScheduleClass> _classScheduleRepository;

    public CreateClassScheduleScheduleHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _classScheduleRepository = unitOfWork.AsyncRepository<Domain.Entities.ScheduleClass>();
    }

    #endregion


    public async Task<bool> Handle(CreateClassScheduleCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        List<Domain.Entities.ScheduleClass> classSchedule =
            schoolYearAggregate.AddClassSchedule(request.ClassId!, request.ScheduleIds!);

        await _classScheduleRepository.InsertAsync(classSchedule);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return true;
    }
}