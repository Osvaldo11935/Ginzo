using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.AcademicLevel.Queries;
using Application.Features.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AcademicLevel.Handlers;

public class GetAllAcademicLevelHandler : HandlerBase,
    IRequestHandler<GetAllAcademicLevelQuery, List<Domain.Entities.AcademicLevel>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.AcademicLevel> _academicLevelRepository;

    public GetAllAcademicLevelHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _academicLevelRepository = unitOfWork.AsyncRepository<Domain.Entities.AcademicLevel>();
    }

    #endregion


    public async Task<List<Domain.Entities.AcademicLevel>> Handle(GetAllAcademicLevelQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.AcademicLevel> queryable =
            _academicLevelRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.Level.ToString() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}