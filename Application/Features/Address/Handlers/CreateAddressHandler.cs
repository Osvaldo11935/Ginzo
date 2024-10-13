using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Address.Commands.Create;
using Application.Features.Common;
using Domain.Common.Aggregates;
using MediatR;

namespace Application.Features.Address.Handlers;

public class CreateAddressHandler : HandlerBase, IRequestHandler<CreateAddressCommand, string>
{
    #region Properties and builders

    private readonly IGenericRepository<Domain.Entities.Address> _addressRepository;

    public CreateAddressHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _addressRepository = unitOfWork.AsyncRepository<Domain.Entities.Address>();
    }

    #endregion


    public async Task<string> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();

        Domain.Entities.Address address = userAggregate.AddAddress(request.Country!, request.County!, request.Province,
            request.Number, request.Street, request.Complement, request.District, request.Neighborhood, request.UserId);

        await _addressRepository.InsertAsync(address);
        await UnitOfWork.SaveChangeAsync(cancellationToken);
        return address.Id!;
    }
}