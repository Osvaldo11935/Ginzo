using MediatR;

namespace Application.Features.Enrollment.Queries;

public class GetAllEnrollmentParameterQuery: IRequest<List<Domain.Entities.EnrollmentParameter>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }

    public GetAllEnrollmentParameterQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }

    public static implicit operator GetAllEnrollmentParameterQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageSize, value.pageNumber, value.search);
}