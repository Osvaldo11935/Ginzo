using MediatR;

namespace Application.Features.SchoolYear.Queries;

public class GetAllSchoolYearQuery: IRequest<List<Domain.Entities.SchoolYear>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    public GetAllSchoolYearQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = string.IsNullOrEmpty(search) ? search : search!.ToLower();
    }
    public static implicit operator GetAllSchoolYearQuery((int pageSize, int pageNumber, string? search) value)
        => new( value.pageSize, value.pageNumber, value.search);
}
