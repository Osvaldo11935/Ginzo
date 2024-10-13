using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.SchoolYear.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SchoolYear.Handlers;

public class GetAllSchoolYearHandler: HandlerBase,
    IRequestHandler<GetAllSchoolYearQuery, List<Domain.Entities.SchoolYear>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.SchoolYear> _schoolYearRepository;

    public GetAllSchoolYearHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _schoolYearRepository = unitOfWork.AsyncRepository<Domain.Entities.SchoolYear>();
    }

    #endregion


    public async Task<List<Domain.Entities.SchoolYear>> Handle(GetAllSchoolYearQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.SchoolYear> queryable =
            _schoolYearRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (!string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.StartYear.ToString() == request.Search && e.IsActive );
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}