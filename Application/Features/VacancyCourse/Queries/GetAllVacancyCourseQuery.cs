using MediatR;

namespace Application.Features.User.Queries;

public class GetAllVacancyCourseQuery : IRequest<List<Domain.Entities.Student>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }

    public GetAllVacancyCourseQuery(int pageSize, int pageNumber, string? search)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Search = string.IsNullOrEmpty(search) ? search : search!.ToLower();
    }

    public static implicit operator GetAllStudentQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageNumber, value.pageSize, value.search);
}