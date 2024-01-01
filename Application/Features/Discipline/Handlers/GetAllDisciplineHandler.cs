using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Discipline.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Discipline.Handlers;

public class GetAllDisciplineHandler: HandlerBase,
    IRequestHandler<GetAllDisciplineQuery, List<Domain.Entities.Discipline>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Discipline> _disciplineRepository;

    public GetAllDisciplineHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _disciplineRepository = unitOfWork.AsyncRepository<Domain.Entities.Discipline>();
    }

    #endregion


    public async Task<List<Domain.Entities.Discipline>> Handle(GetAllDisciplineQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Discipline> queryable =
            _disciplineRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (!string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.Name!.ToString() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}