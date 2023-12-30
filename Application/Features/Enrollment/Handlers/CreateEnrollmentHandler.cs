using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Enrollment.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Enrollment.Handlers;

public class CreateEnrollmentHandler : HandlerBase, IRequestHandler<CreateEnrollmentCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Enrollment> _enrollmentRepository;
    private readonly IGenericRepository<Domain.Entities.EnrollmentParameter> _enrollmentSettingRepository;

    public CreateEnrollmentHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _enrollmentRepository = unitOfWork.AsyncRepository<Domain.Entities.Enrollment>();
        _enrollmentSettingRepository = unitOfWork.AsyncRepository<Domain.Entities.EnrollmentParameter>();
    }

    #endregion


    public async Task<string> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();
        
        Domain.Entities.EnrollmentParameter enrollmentParameter = await _enrollmentSettingRepository.SelectAsync(e =>
            e.IsActive);
        
        if (enrollmentParameter == null) throw new ApiException("Período das inscrições já terminou, tenta novamente quando reabrir");

        Domain.Entities.Enrollment enrollment =
            userAggregate.AddEnrollment(request.StudentId!, request.FinalAverage, enrollmentParameter.Id!, request.DataEnrolledCourses!);
        
        await _enrollmentRepository.InsertAsync(enrollment);
        
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return enrollment.Id!;
    }
}