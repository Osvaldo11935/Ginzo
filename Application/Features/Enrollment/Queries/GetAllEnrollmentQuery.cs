using MediatR;

namespace Application.Features.Enrollment.Queries;

public class GetAllEnrollmentQuery : IRequest<List<Domain.Entities.Enrollment>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }

    public GetAllEnrollmentQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }

    public static implicit operator GetAllEnrollmentQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageSize, value.pageNumber, value.search);
}