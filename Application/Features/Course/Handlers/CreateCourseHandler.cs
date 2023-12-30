using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Course.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Course.Handlers;

public class CreateCourseHandler : HandlerBase, IRequestHandler<CreateCourseCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Course> _courseRepository;

    public CreateCourseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _courseRepository = unitOfWork.AsyncRepository<Domain.Entities.Course>();
    }

    #endregion


    public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();

        Domain.Entities.Course course = courseAggregate.AddCourse(request.Name!);

        await _courseRepository.InsertAsync(course);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return course.Id!;
    }
}