
using MediatR;

namespace Application.Features.Common.Commands;

public class BaseCommand<TRequest, TResponse> : IRequest<TResponse>
{
    public TRequest? Request { get; set; }
    
    public BaseCommand(TRequest? request)
    {
        Request = request;
    }
    

    public static implicit operator BaseCommand<TRequest, TResponse>(TRequest? request)
        => new BaseCommand<TRequest, TResponse>(request);
    
}