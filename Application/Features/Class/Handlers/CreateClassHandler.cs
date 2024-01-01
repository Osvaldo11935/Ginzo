using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Commands.Create;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Class.Handlers;

public class CreateClassHandler : HandlerBase,
    IRequestHandler<BaseCommand<List<CreateClassCommand>, bool>, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Class> _classRepository;

    public CreateClassHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _classRepository = unitOfWork.AsyncRepository<Domain.Entities.Class>();
    }

    #endregion


    public async Task<bool> Handle(BaseCommand<List<CreateClassCommand>, bool> requests,
        CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        List<Domain.Entities.Class> classes =
            requests.Request!.Select(request => schoolYearAggregate
                .AddClass(request.Name!, request.SchoolYearId!, request.AcademicLevelId, request.CourseId)).ToList();

        await _classRepository.InsertAsync(classes);
        await UnitOfWork.SaveChangeAsync(cancellationToken);

        return true;
    }
}