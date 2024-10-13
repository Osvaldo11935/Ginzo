using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Queries;
using Application.Features.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Class.Handlers;

public class GetAllClassHandler: HandlerBase,
    IRequestHandler<GetAllClassQuery, List<Domain.Entities.Class>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Class> _classRepository;

    public GetAllClassHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _classRepository = unitOfWork.AsyncRepository<Domain.Entities.Class>();
    }

    #endregion


    public async Task<List<Domain.Entities.Class>> Handle(GetAllClassQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Class> queryable =
            _classRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (!string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.Name!.ToString() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}