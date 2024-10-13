using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Address.Queries;
using Application.Features.Common;
using Application.Features.PersonalData.Queries;
using MediatR;

namespace Application.Features.PersonalData.Handlers;

public class GetPersonalDataByUserHandler: HandlerBase,
    IRequestHandler< GetPersonalDataByUserQuery, Domain.Entities.PersonalData>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.PersonalData> _personalDataRepository;

    public GetPersonalDataByUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _personalDataRepository = unitOfWork.AsyncRepository<Domain.Entities.PersonalData>();
    }

    #endregion


    public async Task<Domain.Entities.PersonalData> Handle(GetPersonalDataByUserQuery request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.PersonalData? personalData = 
            await _personalDataRepository.SelectAsync(e => e.UserId == request.UserId);

        if (personalData == null) throw new KeyNotFoundException("Não foi possivel buscar os dados pessoal deste usuario");

        return personalData;
    }
}