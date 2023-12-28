using Application.Common.Interfaces.IUnitOfWorks;

namespace Application.Features.Common;

public class HandlerBase
{
    protected readonly IUnitOfWork UnitOfWork;
    public HandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}