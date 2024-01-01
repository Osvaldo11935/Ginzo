using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Application.Features.Course.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Course.Handlers;

public class CreateCourseHandler : HandlerBase,
    IRequestHandler<BaseCommand<List<CreateCourseCommand>, bool>, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Course> _courseRepository;

    public CreateCourseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _courseRepository = unitOfWork.AsyncRepository<Domain.Entities.Course>();
    }

    #endregion


    public async Task<bool> Handle(BaseCommand<List<CreateCourseCommand>, bool> requests, CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();
        
        List<Domain.Entities.Course> courses =
            requests.Request!.Select(request => courseAggregate.AddCourse(request.Name!)).ToList();
        
        await _courseRepository.InsertAsync(courses);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}