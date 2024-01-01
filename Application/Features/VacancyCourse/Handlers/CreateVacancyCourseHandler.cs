using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Application.Features.VacancyCourse.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;


namespace Application.Features.VacancyCourse.Handlers;

public class CreateVacancyCourseHandler : HandlerBase, 
    IRequestHandler<BaseCommand<List<CreateVacancyCourseCommand>, bool>, bool>
{
    #region Properties and builders
    private readonly IGenericRepository<Domain.Entities.VacancyCourse> _vacancyCourseRepository;
    
    public CreateVacancyCourseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _vacancyCourseRepository = unitOfWork.AsyncRepository<Domain.Entities.VacancyCourse>();
    }
    
    #endregion
   

    public async Task<bool> Handle(BaseCommand<List<CreateVacancyCourseCommand>, bool> requests, CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();
        
        List<Domain.Entities.VacancyCourse> vacancyCourses =
            requests.Request!.Select(request =>
                courseAggregate.AddVacancyCourse(request.CourseId, request.TotalVacancy, request.EnrollmentParameterId)).ToList();
        
        await _vacancyCourseRepository.InsertAsync(vacancyCourses);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}