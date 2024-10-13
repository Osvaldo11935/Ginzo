using MediatR;

namespace Application.Features.SchoolYear.Commands.Create;

public class CreateSchoolYearCommand: IRequest<string>
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    
    public CreateSchoolYearCommand(int startYear, int endYear)
    {
        StartYear = startYear;
        EndYear = endYear;
    }

    public static implicit operator CreateSchoolYearCommand(
        (int startYear, int endYear) value)
        => new(value.startYear, value.endYear);
}