using MediatR;

namespace Application.Features.Enrollment.Queries;

public class GetAllEnrollmentStatusQuery: IRequest<List<Domain.Entities.EnrollmentStatus>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }

    public GetAllEnrollmentStatusQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = search;
    }

    public static implicit operator GetAllEnrollmentStatusQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageSize, value.pageNumber, value.search);
}