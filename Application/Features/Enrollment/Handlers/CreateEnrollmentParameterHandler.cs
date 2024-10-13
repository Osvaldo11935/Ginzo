using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Enrollment.Handlers;

public class CreateEnrollmentParameterHandler: HandlerBase, IRequestHandler<CreateEnrollmentParameterCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.EnrollmentParameter> _enrollmentRepository;

    public CreateEnrollmentParameterHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentRepository = unitOfWork.AsyncRepository<Domain.Entities.EnrollmentParameter>();
    }

    #endregion


    public async Task<string> Handle(CreateEnrollmentParameterCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();
        
        Domain.Entities.EnrollmentParameter enrollmentParameter =
            userAggregate.AddEnrollmentParameter(request.EndDate!, request.StartDate, request.SchoolYearId);
        
        await _enrollmentRepository.InsertAsync(enrollmentParameter);
        
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return enrollmentParameter.Id!;
    }
}