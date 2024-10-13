using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Enrollment.Handlers;

public class CreateEnrollmentStatusHandler: HandlerBase, IRequestHandler<CreateEnrollmentStatusCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.EnrollmentStatus> _enrollmentStatusRepository;

    public CreateEnrollmentStatusHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentStatusRepository = unitOfWork.AsyncRepository<Domain.Entities.EnrollmentStatus>();
    }

    #endregion


    public async Task<string> Handle(CreateEnrollmentStatusCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();
        
        Domain.Entities.EnrollmentStatus enrollmentStatus =
            userAggregate.AddEnrollmentStatus(request.Status!, request.Description);
        
        await _enrollmentStatusRepository.InsertAsync(enrollmentStatus);
        
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return enrollmentStatus.Id!;
    }
}