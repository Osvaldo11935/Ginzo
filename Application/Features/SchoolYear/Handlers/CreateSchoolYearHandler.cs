using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Application.Features.SchoolYear.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.SchoolYear.Handlers;

public class CreateSchoolYearHandler: HandlerBase, 
    IRequestHandler<BaseCommand<List<CreateSchoolYearCommand>, bool>, bool>
{
    #region Properties and builders
    private readonly IGenericRepository<Domain.Entities.SchoolYear> _schoolRepository;
    
    public CreateSchoolYearHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _schoolRepository = unitOfWork.AsyncRepository<Domain.Entities.SchoolYear>();
    }
    
    #endregion
   

    public async Task<bool> Handle(BaseCommand<List<CreateSchoolYearCommand>, bool> requests, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();
        
        List<Domain.Entities.SchoolYear> schoolYears =
            requests.Request!.Select(request =>
        schoolYearAggregate.AddSchoolYear(request.StartYear, request.EndYear)).ToList();
        
        await _schoolRepository.InsertAsync(schoolYears);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}