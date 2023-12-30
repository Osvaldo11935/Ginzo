namespace WebApi.Common.Models.Requests;

public class CreateEnrollmentParameterRequest
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public string? SchoolYearId { get; set; }
}