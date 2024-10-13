using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Schedule.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Schedule.Handlers;

public class GetAllScheduleHandler: HandlerBase,
    IRequestHandler<GetAllScheduleQuery, List<Domain.Entities.Schedule>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Schedule> _scheduleRepository;

    public GetAllScheduleHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _scheduleRepository = unitOfWork.AsyncRepository<Domain.Entities.Schedule>();
    }

    #endregion


    public async Task<List<Domain.Entities.Schedule>> Handle(GetAllScheduleQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Schedule> queryable =
            _scheduleRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (!string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.DayWeek!.ToLower() == request.Search && e.IsActive );
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}