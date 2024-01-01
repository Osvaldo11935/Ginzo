namespace WebApi.Common.Models.Requests;

public class CreateEnrollmentParameterRequest
{
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
    public double FinalAverage { get; set; }
    public int MinPriorityAge { get; set; }
    public int MaxPriorityAge { get; set; }
}