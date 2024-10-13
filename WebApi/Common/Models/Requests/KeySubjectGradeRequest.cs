namespace WebApi.Common.Models.Requests;

public class KeySubjectGradeRequest
{
    public string? DisciplineId { get; set; }
    public double FinalAverage { get; set; }
}