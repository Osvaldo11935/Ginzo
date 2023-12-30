using Application.Features.Course.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class CourseController: BaseController
{
    #region Post
    [HttpPost("course")]
    public async Task<IActionResult> CreateCourseAsync([FromBody] CreateCourseRequest request)
    {
        string response =  await Mediator.Send((CreateCourseCommand)request.Name!);

        return Ok(new { CourseId = response });
    }
    #endregion
}