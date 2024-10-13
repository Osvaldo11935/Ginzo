using MediatR;

namespace Application.Features.Discipline.Queries;

public class GetAllDisciplineQuery: IRequest<List<Domain.Entities.Discipline>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
    
    public GetAllDisciplineQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }

    public static implicit operator GetAllDisciplineQuery((int pageSize, int pageNumber, string? search) value)
        => new( value.pageSize, value.pageNumber, value.search);
}