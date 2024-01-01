using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class EnrollmentStatusResponse
{
    public string? Id { get; set; }
    public string? Status { get; set; }
    public string? Description { get; set; }
    public static List<EnrollmentStatusResponse> EnrollmentStatusToEnrollmentStatusResponse(List<EnrollmentStatus> enrollmentStatus)
        => enrollmentStatus.Select(e => new EnrollmentStatusResponse
        {
            Id = e.Id,
            Status = e.Status,
            Description = e.Description
        }).ToList();
    
    public static EnrollmentStatusResponse EnrollmentStatusToEnrollmentStatusResponse(EnrollmentStatus enrollmentStatus)
        => new EnrollmentStatusResponse
        {
            Id = enrollmentStatus.Id,
            Status = enrollmentStatus.Status,
            Description = enrollmentStatus.Description
        };
}