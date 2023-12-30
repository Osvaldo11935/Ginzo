using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Address.Queries;
using Application.Features.Common;
using MediatR;

namespace Application.Features.Address.Handlers;

public class GetAddressByUserHandler : HandlerBase,
    IRequestHandler<GetAddressByUserQuery, Domain.Entities.Address>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Address> _addressRepository;

    public GetAddressByUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _addressRepository = unitOfWork.AsyncRepository<Domain.Entities.Address>();
    }

    #endregion


    public async Task<Domain.Entities.Address> Handle(GetAddressByUserQuery request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Address? address =
            await _addressRepository.SelectAsync(e => e.UserId == request.UserId);

        if (address == null) throw new KeyNotFoundException("Não foi possivel buscar o endereço deste usuario");

        return address;
    }
}