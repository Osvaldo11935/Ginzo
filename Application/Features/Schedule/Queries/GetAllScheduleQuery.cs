using MediatR;

namespace Application.Features.Schedule.Queries;

public class GetAllScheduleQuery: IRequest<List<Domain.Entities.Schedule>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    public GetAllScheduleQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = string.IsNullOrEmpty(search) ? search : search!.ToLower();
    }
    public static implicit operator GetAllScheduleQuery((int pageSize, int pageNumber, string? search) value)
        => new( value.pageSize, value.pageNumber, value.search);
}