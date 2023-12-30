namespace Domain.Entities;

public class EnrollmentSettingTerm
{
    public string? EnrollmentTermId { get; set; }
    public string? EnrollmentSettingId { get; set; }
    
    public virtual EnrollmentTerm? EnrollmentTerm { get; set; }
    public virtual EnrollmentParameter? EnrollmentSetting { get; set; }
}