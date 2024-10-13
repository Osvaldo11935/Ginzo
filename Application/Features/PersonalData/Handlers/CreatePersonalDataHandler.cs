using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.PersonalData.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.PersonalData.Handlers;

public class CreatePersonalDataHandler : HandlerBase, IRequestHandler<CreatePersonalDataCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.PersonalData> _personalDataRepository;

    public CreatePersonalDataHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _personalDataRepository = unitOfWork.AsyncRepository<Domain.Entities.PersonalData>();
    }

    #endregion


    public async Task<string> Handle(CreatePersonalDataCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();

        Domain.Entities.PersonalData personalData = userAggregate.AddPersonalData(request.Mother!, request.Father!,
            request.Natural, request.DocumentIssuanceDate, request.DocumentExpirationDate,
            request.PlaceIssuanceDocument, request.UserId);

        await _personalDataRepository.InsertAsync(personalData);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return personalData.Id!;
    }
}