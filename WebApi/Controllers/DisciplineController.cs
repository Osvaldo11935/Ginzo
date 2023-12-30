using Application.Features.Course.Commands.Create;
using Application.Features.Discipline.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class DisciplineController: BaseController
{
    #region Post
    [HttpPost("discipline")]
    public async Task<IActionResult> CreateDisciplineAsync([FromBody] CreateDisciplineRequest request)
    {
        string response =  await Mediator.Send((CreateDisciplineCommand)request.Name!);

        return Ok(new { DisciplineId = response });
    }
    
    [HttpPost("course/{courseId}/discipline")]
    public async Task<IActionResult> CreateCourseAsync([FromRoute] string courseId, [FromBody] CreateCourseDisciplineRequest request)
    {
        bool response =  await Mediator.Send((CreateCourseDisciplineCommand)(courseId, request.SetDiscipline(request.Disciplines)));

        return Ok(new { Success = response });
    }
    #endregion
}