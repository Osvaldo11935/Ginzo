using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.AcademicLevel.Commands.Create;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.AcademicLevel.Handlers;

public class CreateAcademicLevelHandler : HandlerBase,
    IRequestHandler<BaseCommand<List<CreateAcademicLevelCommand>, bool>, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.AcademicLevel> _academicLevelRepository;

    public CreateAcademicLevelHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _academicLevelRepository = unitOfWork.AsyncRepository<Domain.Entities.AcademicLevel>();
    }

    #endregion


    public async Task<bool> Handle(BaseCommand<List<CreateAcademicLevelCommand>, bool> request,
        CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();
        
        List<Domain.Entities.AcademicLevel> academicLevels =
            request.Request!.Select(e => schoolYearAggregate
                .AddAcademicLevel(e.Level)).ToList();


        await _academicLevelRepository.InsertAsync(academicLevels);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}