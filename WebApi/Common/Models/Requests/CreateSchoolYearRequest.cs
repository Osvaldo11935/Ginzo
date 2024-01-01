using Application.Features.SchoolYear.Commands.Create;

namespace WebApi.Common.Models.Requests;

public class CreateSchoolYearRequest
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    
    public static List<CreateSchoolYearCommand> Parsing(List<CreateSchoolYearRequest> requests)
        => requests.Select(request => (CreateSchoolYearCommand) (request.StartYear, request.EndYear )).ToList();
}