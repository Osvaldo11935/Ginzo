using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class AcademicLevelResponse
{
    public string? Id { get; set; }
    public int Level { get; set; }
    
    public static List<AcademicLevelResponse> AcademicLevelToAcademicLevelResponse(List<AcademicLevel> academicLevels)
        => academicLevels.Select(e => new AcademicLevelResponse
        {
            Id = e.Id,
            Level = e.Level,

        }).ToList();

    public static AcademicLevelResponse AcademicLevelToAcademicLevelResponse(AcademicLevel academicLevel)
        => new AcademicLevelResponse
        {
            Id = academicLevel.Id,
            Level = academicLevel.Level
        };
}