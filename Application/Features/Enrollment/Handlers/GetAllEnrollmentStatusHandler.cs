using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Enrollment.Handlers;

public class GetAllEnrollmentStatusHandler: HandlerBase, IRequestHandler<GetAllEnrollmentStatusQuery, List<Domain.Entities.EnrollmentStatus>>
{
    #region Propertie and builders

    private readonly IGenericRepository<Domain.Entities.EnrollmentStatus> _enrollmentStatusRepository;
    
    public GetAllEnrollmentStatusHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentStatusRepository = unitOfWork.AsyncRepository<Domain.Entities.EnrollmentStatus>();
    }
    
    #endregion
   
    public async Task<List<Domain.Entities.EnrollmentStatus>> Handle(GetAllEnrollmentStatusQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.EnrollmentStatus> queryable =
            _enrollmentStatusRepository.SelectAllAsync(request.PageNumber, request.PageSize);
        
        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(e =>
                e.Status!.ToLower() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}