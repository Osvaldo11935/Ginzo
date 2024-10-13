using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Common.Commands;
using Application.Features.Discipline.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Discipline.Handlers;

public class CreateDisciplineHandler : HandlerBase,
    IRequestHandler<BaseCommand<List<CreateDisciplineCommand>, bool>, bool>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Discipline> _disciplineRepository;

    public CreateDisciplineHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _disciplineRepository = unitOfWork.AsyncRepository<Domain.Entities.Discipline>();
    }

    #endregion


    public async Task<bool> Handle(BaseCommand<List<CreateDisciplineCommand>, bool> requests,
        CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();

        List<Domain.Entities.Discipline> disciplines =
            requests.Request!.Select(request => courseAggregate.AddDiscipline(request.Name)).ToList();

        await _disciplineRepository.InsertAsync(disciplines);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        
        return true;
    }
}