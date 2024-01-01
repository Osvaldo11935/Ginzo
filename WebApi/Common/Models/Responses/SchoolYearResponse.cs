using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class SchoolYearResponse
{
    public string? Id { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public static List<SchoolYearResponse> SchoolYearToSchoolYearResponse(List<SchoolYear> schoolYears)
        => schoolYears.Select(e => new SchoolYearResponse
        {
            Id = e.Id,
            EndYear = e.EndYear,
            StartYear = e.StartYear
        }).ToList();
    
    public static SchoolYearResponse SchoolYearToSchoolYearResponse(SchoolYear schoolYear)
        => new SchoolYearResponse
        {
            Id = schoolYear.Id,
            EndYear = schoolYear.EndYear,
            StartYear = schoolYear.StartYear
        };
}