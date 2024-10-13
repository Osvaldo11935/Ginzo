using MediatR;

namespace Application.Features.Class.Queries;

public class GetAllClassQuery: IRequest<List<Domain.Entities.Class>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    public GetAllClassQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }
    public static implicit operator GetAllClassQuery((int pageSize, int pageNumber, string? search) value)
        => new( value.pageSize, value.pageNumber, value.search);
}