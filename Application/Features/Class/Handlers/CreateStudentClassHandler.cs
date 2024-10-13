using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Class.Commands.Create;
using Application.Features.Common;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Class.Handlers;

public class CreateStudentClassHandler: HandlerBase, IRequestHandler<CreateStudentClassCommand, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Student> _studentClassRepository;

    public CreateStudentClassHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _studentClassRepository = unitOfWork.AsyncRepository<Domain.Entities.Student>();
    }

    #endregion


    public async Task<bool> Handle(CreateStudentClassCommand request, CancellationToken cancellationToken)
    {
        SchoolYearAggregate schoolYearAggregate = new SchoolYearAggregate();

        List<Domain.Entities.Student> studentClass =
            schoolYearAggregate.AddStudentClass(request.ClassId!, request.StudentIds!);

        await _studentClassRepository.InsertAsync(studentClass);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return true;
    }
}