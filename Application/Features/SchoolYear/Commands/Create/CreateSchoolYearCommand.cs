using MediatR;

namespace Application.Features.SchoolYear.Commands.Create;

public class CreateSchoolYearCommand: IRequest<string>
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}