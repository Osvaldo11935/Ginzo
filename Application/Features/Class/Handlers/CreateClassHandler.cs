using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Commands.Create;
using Application.Features.Common;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Class.Handlers;

public class CreateClassHandler: HandlerBase, IRequestHandler<CreateClassCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Class> _classRepository;

    public CreateClassHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _classRepository = unitOfWork.AsyncRepository<Domain.Entities.Class>();
    }

    #endregion


    public async Task<string> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        Domain.Entities.Class @class = schoolYearAggregate.AddClass(request.Name!,  request.SchoolYearId!, request.AcademicLevelId, request.CourseId);

        await _classRepository.InsertAsync(@class);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return @class.Id!;
    }
}