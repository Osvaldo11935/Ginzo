namespace WebApi.Common.Models.Requests;

public class CreateCourseDisciplineRequest
{
    public string? CourseId { get; set; }
    public List<DisciplineRequest>? Disciplines { get; set; }

    public Dictionary<string, bool> SetDiscipline(List<DisciplineRequest>? disciplines)
    {
        var dic = new Dictionary<string, bool>();
        
        disciplines!.ForEach(e =>
        {
            dic.Add(e.DisciplineId!, e.IsKey);
        });

        return dic;
    }
}

public class DisciplineRequest
{
    public bool IsKey { get; set; }
    public string? DisciplineId { get; set; }
}