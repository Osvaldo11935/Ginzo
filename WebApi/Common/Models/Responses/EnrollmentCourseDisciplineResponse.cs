using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class EnrollmentCourseDisciplineResponse
{
    public double FinalAverage { get; set; }
    public DisciplineResponse? Discipline { get; set; }

    public static List<EnrollmentCourseDisciplineResponse>
        EnrollmentCourseDisciplineToEnrollmentCourseDisciplineResponse(
            List<EnrollmentCourseDiscipline> courseDisciplines)
        => courseDisciplines.Select(e => new EnrollmentCourseDisciplineResponse
        {
              FinalAverage = e.FinalAverage,
              Discipline = DisciplineResponse.DisciplineToDisciplineResponse(e.Discipline!)
        }).ToList();
}