using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.Discipline.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Discipline.Handlers;

public class CreateDisciplineHandler: HandlerBase, IRequestHandler<CreateDisciplineCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Discipline> _disciplineRepository;

    public CreateDisciplineHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _disciplineRepository = unitOfWork.AsyncRepository<Domain.Entities.Discipline>();
    }

    #endregion


    public async Task<string> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
    {
        CourseAggregate courseAggregate = new CourseAggregate();

        Domain.Entities.Discipline discipline = courseAggregate.AddDiscipline(request.Name);
        
        await _disciplineRepository.InsertAsync(discipline);

        return discipline.Id!;
    }
}