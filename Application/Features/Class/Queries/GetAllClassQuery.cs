namespace Application.Features.Class.Queries;

public class GetClassQuery: IRequest<List<Domain.Entities.Course>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    public GetAllCourseQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }
    public static implicit operator GetAllCourseQuery((int pageSize, int pageNumber, string? search) value)
        => new( value.pageSize, value.pageNumber, value.search);
}