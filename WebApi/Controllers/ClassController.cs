using Application.Features.Class.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class ClassController: BaseController
{
    #region Post
    [HttpPost("class")]
    public async Task<IActionResult> CreateClassAsync([FromBody] CreateClassRequest request)
    {
        string response =  await Mediator.Send((CreateClassCommand)(request.Name, request.SchoolYearId, request.AcademicLevelId, request.CourseId)!);

        return Ok(new { ClassId = response });
    }
    
    [HttpPost("class/{classId}/schedule")]
    public async Task<IActionResult> AddScheduleClassAsync([FromRoute] string classId , [FromBody] CreateClassScheduleRequest request)
    {
        bool response =  await Mediator.Send((CreateClassScheduleCommand)(classId, request.ScheduleIds));

        return Ok(new { Success = response });
    }
    
    [HttpPost("class/{classId}/student")]
    public async Task<IActionResult> AddStudentClassAsync([FromRoute] string classId, [FromBody] CreateStudentClassRequest request)
    {
        bool response =  await Mediator.Send((CreateStudentClassCommand)(classId, request.StudentIds));

        return Ok(new { Success = response });
    }
    #endregion
}