using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.SchoolYear.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.SchoolYear.Handlers;

public class CreateSchoolYearHandler: HandlerBase, IRequestHandler<CreateSchoolYearCommand, string>
{
    #region Properties and builders
    private readonly IGenericRepository<Domain.Entities.SchoolYear> _schoolRepository;
    
    public CreateSchoolYearHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _schoolRepository = unitOfWork.AsyncRepository<Domain.Entities.SchoolYear>();
    }
    
    #endregion
   

    public async Task<string> Handle(CreateSchoolYearCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        Domain.Entities.SchoolYear schoolYear = schoolYearAggregate.AddSchoolYear(request.StartYear, request.EndYear);
        
        await _schoolRepository.InsertAsync(schoolYear);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return schoolYear.Id!;
    }
}