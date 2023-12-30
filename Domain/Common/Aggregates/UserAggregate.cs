using Domain.Common.ValueObjects;
using Domain.Entities;

namespace Domain.Common.Aggregates;

public class UserAggregate
{
    #region Write
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="name"></param>
    /// <param name="birthDate"></param>
    /// <param name="documentNumber"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    public User AddUser(string? email, string? name, DateTime birthDate,
        string? documentNumber, string? phoneNumber, string? userName)
    {
        return new User {
            Name = name,
            Email = email,
            UserName = userName,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            DocumentNumber = documentNumber
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="studentId"></param>
    /// <param name="finalAverage"></param>
    /// <param name="enrollmentParameterId"></param>
    /// <param name="dataEnrolledCourses"></param>
    /// <returns></returns>
    public Enrollment AddEnrollment(string studentId, double finalAverage, string enrollmentParameterId,
        Dictionary<string, Dictionary<string, double>> dataEnrolledCourses)
        => new Enrollment {
            StudentId = studentId,
            FinalAverage = finalAverage,
            EnrollmentParameterId = enrollmentParameterId,
            EnrollmentCourses = SetCoursesEnrolled(dataEnrolledCourses),
            EnrollmentStatusId = EnrollmentStatusValueObject.UnderAnalysisId
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endDate"></param>
    /// <param name="startDate"></param>
    /// <param name="schoolYearId"></param>
    /// <returns></returns>
    public EnrollmentParameter AddEnrollmentParameter(DateTime? endDate, DateTime? startDate, string? schoolYearId)
        => new EnrollmentParameter {
            EndDate = endDate,
            StartDate = startDate,
            SchoolYearId = schoolYearId
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public EnrollmentStatus AddEnrollmentStatus(string? status, string? description)
        => new EnrollmentStatus {
            Status = status,
            Description = description
        };
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="country"></param>
    /// <param name="county"></param>
    /// <param name="province"></param>
    /// <param name="number"></param>
    /// <param name="street"></param>
    /// <param name="complement"></param>
    /// <param name="district"></param>
    /// <param name="neighborhood"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Address AddAddress(string? country, string? county, string? province, string? number, string? street,
        string? complement, string? district, string? neighborhood, string? userId)
        => new Address {
            Country = country,
            Province = province,
            County = county,
            District = district,
            Neighborhood = neighborhood,
            Street = street,
            Number = number,
            Complement = complement,
            UserId = userId
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="placeIssuanceDocument"></param>
    /// <param name="userId"></param>
    /// <param name="mother"></param>
    /// <param name="father"></param>
    /// <param name="natural"></param>
    /// <param name="documentIssuanceDate"></param>
    /// <param name="documentExpirationDate"></param>
    /// <returns></returns>
    public PersonalData AddPersonalData(string? mother, string? father, string? natural, DateTime? documentIssuanceDate,
        DateTime? documentExpirationDate, string? placeIssuanceDocument, string? userId)
        => new PersonalData {
           Mother = mother,
           Father = father,
           Natural = natural,
           DocumentIssuanceDate = documentIssuanceDate,
           DocumentExpirationDate = documentExpirationDate,
           PlaceIssuanceDocument = placeIssuanceDocument,
            UserId = userId
        };
    
    #endregion

    #region Aux

    private List<EnrollmentCourse> SetCoursesEnrolled(Dictionary<string, Dictionary<string, double>> coursesEnrolled)
    {
        return coursesEnrolled.Select(e => new EnrollmentCourse
        {
            CourseId = e.Key,
            EnrollmentCourseDisciplines = SetKySubjectGrade(e.Value)
        }).ToList();
    }
    private List<EnrollmentCourseDiscipline> SetKySubjectGrade(Dictionary<string, double> keySubjectGrade)
    {
       return keySubjectGrade.Select(e => new EnrollmentCourseDiscipline
        {
            DisciplineId = e.Key,
            FinalAverage = e.Value,
        }).ToList();
    }
    #endregion
}