using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class DisciplineResponse
{
    public string? Name { get; set; }
    
    public static List<DisciplineResponse> DisciplineToDisciplineResponse(List<Discipline> disciplines)
        => disciplines.Select(e => new DisciplineResponse
        {
            Name = e.Name
        }).ToList();

    public static DisciplineResponse DisciplineToDisciplineResponse(Discipline discipline)
        => new DisciplineResponse
        {
             Name = discipline.Name
        };
}