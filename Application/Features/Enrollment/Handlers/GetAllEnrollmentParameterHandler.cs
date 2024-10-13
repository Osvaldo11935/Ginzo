using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Enrollment.Handlers;

public class GetAllEnrollmentParameterHandler: HandlerBase, IRequestHandler<GetAllEnrollmentParameterQuery, List<Domain.Entities.EnrollmentParameter>>
{
    #region Propertie and builders

    private readonly IGenericRepository<Domain.Entities.EnrollmentParameter> _enrollmentParameterRepository;
    
    public GetAllEnrollmentParameterHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentParameterRepository = unitOfWork.AsyncRepository<Domain.Entities.EnrollmentParameter>();
    }
    
    #endregion
   
    public async Task<List<Domain.Entities.EnrollmentParameter>> Handle(GetAllEnrollmentParameterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.EnrollmentParameter> queryable =
            _enrollmentParameterRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        return await queryable.ToListAsync(cancellationToken);
    }
}