using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.VacancyCourse.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.VacancyCourse.Handlers;

public class GetAllVacancyCourseHandler : HandlerBase,
    IRequestHandler<GetAllVacancyCourseQuery, List<Domain.Entities.VacancyCourse>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.VacancyCourse> _vacancyCourseRepository;

    public GetAllVacancyCourseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _vacancyCourseRepository = unitOfWork.AsyncRepository<Domain.Entities.VacancyCourse>();
    }

    #endregion


    public async Task<List<Domain.Entities.VacancyCourse>> Handle(GetAllVacancyCourseQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.VacancyCourse> queryable =
            _vacancyCourseRepository.SelectAllAsync(request.PageNumber, request.PageSize)
                .Include(e => e.Course);

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(e =>
                e.Course!.Name!.ToLower() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}