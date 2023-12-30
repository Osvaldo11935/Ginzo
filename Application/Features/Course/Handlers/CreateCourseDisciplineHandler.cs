using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Course.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Course.Handlers;

public class CreateCourseDisciplineHandler: HandlerBase, IRequestHandler<CreateCourseDisciplineCommand, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.DisciplineCourse> _disciplineCourseRepository;

    public CreateCourseDisciplineHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _disciplineCourseRepository = unitOfWork.AsyncRepository<Domain.Entities.DisciplineCourse>();
    }

    #endregion


    public async Task<bool> Handle(CreateCourseDisciplineCommand request, CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();
        
        List<Domain.Entities.DisciplineCourse> disciplineCourses = courseAggregate.AddCourseDiscipline(request.CourseId, request.Disciplines!);

        await _disciplineCourseRepository.InsertAsync(disciplineCourses);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return true;
    }
}