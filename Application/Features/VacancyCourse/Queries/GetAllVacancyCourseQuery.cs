using Application.Features.User.Queries;
using MediatR;

namespace Application.Features.VacancyCourse.Queries;

public class GetAllVacancyCourseQuery : IRequest<List<Domain.Entities.VacancyCourse>>
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

    public static implicit operator GetAllVacancyCourseQuery((int pageSize, int pageNumber, string? search) value)
        => new(value.pageNumber, value.pageSize, value.search);
}