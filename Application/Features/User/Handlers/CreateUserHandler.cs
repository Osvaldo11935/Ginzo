using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Application.Features.Common;
using Application.Features.User.Commands.Create;
using Domain.Common.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.User.Handlers;

public class CreateUserHandler : HandlerBase, IRequestHandler<CreateUserCommand, string>
{
    #region Properties  and builders

    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _userRepository = unitOfWork.UserRepository();
    }

    #endregion

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        UserAggregate userAggregate = new UserAggregate();
        
        Domain.Entities.User user = userAggregate.AddUser(request.Email, request.Name, request.BirthDate,
            request.DocumentNumber, request.PhoneNumber, request.UserName);

        IdentityResult userResponse =  await _userRepository.SignUpAsync(user, request.Password!);

        if (!userResponse.Succeeded) throw new ApiException(userResponse.Errors.FirstOrDefault()!.Description);

        await _userRepository.AddRoleToUserAsync(user, request.RoleName!);

        return user.Id;
    }
}