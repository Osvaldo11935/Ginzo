using MediatR;

namespace Application.Features.AcademicLevel.Queries;

public class GetAllAcademicLevelQuery: IRequest<List<Domain.Entities.AcademicLevel>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    
    public GetAllAcademicLevelQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }

    public static implicit operator GetAllAcademicLevelQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageNumber, value.pageSize, value.search);
}