namespace WebApi.Common.Models.Requests;

public class CreateEnrollmentRequest
{
    public double FinalAverage { get; set; }
    public List<DataEnrolledCourseRequest>? DataEnrolledCourses { get; set; }

    #region Aux
    public Dictionary<string, Dictionary<string, double>> SetDataEnrolledCourses()
    {
        var dic = new Dictionary<string, Dictionary<string, double>>();
        DataEnrolledCourses!.ForEach(e =>
       {
           dic.Add(e.CourseId!, GetKeySubjectGrade(e.KeySubjectGrade));
       });

       return dic;
    }

    private Dictionary<string, double> GetKeySubjectGrade(List<KeySubjectGradeRequest>? keySubjectGrade)
    {
        var dic = new Dictionary<string, double>();
        keySubjectGrade!.ForEach(e =>
        {
            dic.Add(e.DisciplineId!, e.FinalAverage);
        });

        return dic;
    }

    #endregion
}

