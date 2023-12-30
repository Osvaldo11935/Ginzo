using MediatR;

namespace Application.Features.Schedule.Queries;

public class GetAllScheduleQuery: IRequest<Domain.Entities.Schedule>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
}