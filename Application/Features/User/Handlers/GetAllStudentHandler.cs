using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.User.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Handlers;

public class GetAllStudentHandler : HandlerBase,
    IRequestHandler<GetAllStudentQuery, List<Domain.Entities.Student>>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Student> _studentRepository;

    public GetAllStudentHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _studentRepository = unitOfWork.AsyncRepository<Domain.Entities.Student>();
    }

    #endregion


    public async Task<List<Domain.Entities.Student>> Handle(GetAllStudentQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Student> queryable =
            _studentRepository.SelectAllAsync(request.PageNumber, request.PageSize)
                .Include(e => e.Class)
                .ThenInclude(e => e!.Course)
                .Include(e => e.User);

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(e =>
                e.User!.Name!.ToLower() == request.Search || e.User.Email!.ToLower() == request.Search ||
                e.User.DocumentNumber!.ToLower() == request.Search || e.Class!.Name!.ToLower() == request.Search ||
                e.Class.Course!.Name!.ToLower() == request.Search);
        }

        return await queryable.ToListAsync(cancellationToken);
    }
}