using Application.Features.Common.Commands;
using Application.Features.Course.Commands.Create;
using Application.Features.Discipline.Commands.Create;
using Application.Features.Discipline.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class DisciplineController: BaseController
{
    #region Post
    [HttpPost("discipline")]
    public async Task<IActionResult> CreateDisciplineAsync([FromBody] List<CreateDisciplineRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateDisciplineCommand>, bool>) CreateDisciplineRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    
    [HttpPost("/course-discipline")]
    public async Task<IActionResult> CreateCourseAsync([FromBody] List<CreateCourseDisciplineRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateCourseDisciplineCommand>, bool>) CreateCourseDisciplineRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    #endregion
    
    #region Get

    [HttpGet("discipline")]
    public async Task<IActionResult> GetAllDisciplineAsync([FromQuery] QueryParameterRequest request)
    {
        List<Discipline> courses =  await Mediator.Send((GetAllDisciplineQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<DisciplineResponse> disciplineResponses = DisciplineResponse.DisciplineToDisciplineResponse(courses);

        return Ok((BasePaginationResponse<List<DisciplineResponse>>)(disciplineResponses, request.PageNumber, request.PageSize,
            disciplineResponses.Count));
    }

    #endregion
    
}