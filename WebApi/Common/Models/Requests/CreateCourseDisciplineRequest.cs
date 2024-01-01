using Application.Features.Course.Commands.Create;

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
    
    public static List<CreateCourseDisciplineCommand> Parsing(List<CreateCourseDisciplineRequest> requests)
        => requests.Select(request => (CreateCourseDisciplineCommand)(request.CourseId, request.SetDiscipline(request.Disciplines)) ).ToList();
}

public class DisciplineRequest
{
    public bool IsKey { get; set; }
    public string? DisciplineId { get; set; }
}