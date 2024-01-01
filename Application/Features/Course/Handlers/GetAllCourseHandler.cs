using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Course.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Course.Handlers;

public class GetAllCourseHandler: HandlerBase,
    IRequestHandler<GetAllCourseQuery, List<Domain.Entities.Course>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Course> _courseRepository;

    public GetAllCourseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _courseRepository = unitOfWork.AsyncRepository<Domain.Entities.Course>();
    }

    #endregion


    public async Task<List<Domain.Entities.Course>> Handle(GetAllCourseQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Course> queryable =
            _courseRepository.SelectAllAsync(request.PageNumber, request.PageSize);

        if (!string.IsNullOrEmpty(request.Search)) {
            queryable = queryable.Where(e => e.Name!.ToString() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}