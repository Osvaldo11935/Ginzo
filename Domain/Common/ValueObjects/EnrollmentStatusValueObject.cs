using Domain.Entities;

namespace Domain.Common.ValueObjects;

public static class EnrollmentStatusValueObject
{
    public static string ApprovedName = "Aprovado";
    public static string DisapprovedName = "Reprovado";
    public static string VoidedName = "Anulado";
    public static string UnderAnalysisName = "Em analise";
    
    public static string ApprovedId = "30963a2f-adbd-41e4-ae25-c3e9c5774c3d";
    public static string DisapprovedId = "47ecebc6-5682-45c1-8ec4-b5b8cc1da0e1";
    public static string VoidedId = "7395136a-692d-4d60-a2b3-80c1967ba6f7";
    public static string UnderAnalysisId = "fbe16f4c-bd17-4889-b027-a70a2dcdae42";

    public static List<EnrollmentStatus> AddEnrollmentStatus()
    {
        return new List<EnrollmentStatus>()
        {
            new EnrollmentStatus()
            {
                Id = ApprovedId,
                Status = ApprovedName,
                Description = ApprovedName
            },
            new EnrollmentStatus()
            {
                Id = DisapprovedId,
                Status = DisapprovedName,
                Description = DisapprovedName
            },
            new EnrollmentStatus()
            {
                Id = VoidedId,
                Status = VoidedName,
                Description = VoidedName
            },
            new EnrollmentStatus()
            {
                Id = UnderAnalysisId,
                Status = UnderAnalysisName,
                Description = UnderAnalysisName
            }
        };
    }
}