using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class EnrollmentParameterResponse
{
    public string? Id { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public double FinalAverage { get; set; }
    public int MinPriorityAge { get; set; }
    public int MaxPriorityAge { get; set; }
    
    public static List<EnrollmentParameterResponse>EnrollmentParameterToEnrollmentParameterResponse(List<EnrollmentParameter> enrollmentParameters)
        => enrollmentParameters.Select(e => new EnrollmentParameterResponse
        {
            Id = e.Id,
            EndDate = e.EndDate,
            StartDate = e.StartDate,
            FinalAverage = e.FinalAverage,
            MinPriorityAge = e.MinPriorityAge,
            MaxPriorityAge = e.MaxPriorityAge
            
        }).ToList();
    
    public static EnrollmentParameterResponse EnrollmentParameterToEnrollmentParameterResponse(EnrollmentParameter enrollmentParameter)
        => new EnrollmentParameterResponse
        {
            Id = enrollmentParameter.Id,
            EndDate = enrollmentParameter.EndDate,
            StartDate = enrollmentParameter.StartDate,
            FinalAverage = enrollmentParameter.FinalAverage,
            MinPriorityAge = enrollmentParameter.MinPriorityAge,
            MaxPriorityAge = enrollmentParameter.MaxPriorityAge
        };
}