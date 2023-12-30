using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.AcademicLevel.Commands.Create;
using Application.Features.Common;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.AcademicLevel.Handlers;

public class CreateAcademicLevelHandler: HandlerBase, IRequestHandler<CreateAcademicLevelCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.AcademicLevel> _academicLevelRepository;

    public CreateAcademicLevelHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _academicLevelRepository = unitOfWork.AsyncRepository<Domain.Entities.AcademicLevel>();
    }

    #endregion


    public async Task<string> Handle(CreateAcademicLevelCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        Domain.Entities.AcademicLevel academicLevel = schoolYearAggregate.AddAcademicLevel(request.Level);

        await _academicLevelRepository.InsertAsync(academicLevel);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return academicLevel.Id!;
    }
}