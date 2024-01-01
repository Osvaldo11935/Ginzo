using Domain.Entities;

namespace WebApi.Common.Models.Responses;

public class DisciplineResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public static List<DisciplineResponse> DisciplineToDisciplineResponse(List<Discipline> disciplines)
        => disciplines.Select(e => new DisciplineResponse
        {
            Id = e.Id,
            Name = e.Name
        }).ToList();

    public static DisciplineResponse DisciplineToDisciplineResponse(Discipline discipline)
        => new DisciplineResponse
        {
            Id = discipline.Id,
            Name = discipline.Name
        };
}