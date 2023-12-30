using MediatR;

namespace Application.Features.SchoolYear.Queries;

public class GetAllSchoolYearQuery: IRequest<Domain.Entities.SchoolYear>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
}