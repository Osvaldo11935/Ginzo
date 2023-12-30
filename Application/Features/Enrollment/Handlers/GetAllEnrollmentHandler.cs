using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Enrollment.Handlers;

public class GetAllEnrollmentHandler: HandlerBase, IRequestHandler<GetAllEnrollmentQuery, List<Domain.Entities.Enrollment>>
{
    #region Propertie and builders

    private readonly IGenericRepository<Domain.Entities.Enrollment> _enrollmentRepository;
    
    public GetAllEnrollmentHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentRepository = unitOfWork.AsyncRepository<Domain.Entities.Enrollment>();
    }
    
    #endregion
   
    public async Task<List<Domain.Entities.Enrollment>> Handle(GetAllEnrollmentQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Enrollment> queryable =
            _enrollmentRepository.SelectAllAsync(request.PageNumber, request.PageSize)
                .Include(e => e.Student)
                .Include(e => e.EnrollmentStatus)
                .Include(e => e.EnrollmentCourses)!
                .ThenInclude(e => e.Course)
                .Include(e => e.EnrollmentCourses)!
                .ThenInclude(e => e.EnrollmentCourseDisciplines)!
                .ThenInclude(e => e.Discipline);

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(e =>
                e.Student!.Name!.ToLower() == request.Search || e.Student.Email!.ToLower() == request.Search ||
                e.Student.DocumentNumber!.ToLower() == request.Search || e.Student!.Name!.ToLower() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}