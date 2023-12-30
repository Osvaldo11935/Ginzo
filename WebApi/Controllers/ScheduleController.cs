using Application.Features.Schedule.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class ScheduleController: BaseController
{
    #region Post
    [HttpPost("schedule")]
    public async Task<IActionResult> CreateScheduleAsync([FromBody] CreateScheduleRequest request)
    {
        string response =  await Mediator.Send((CreateScheduleCommand)(request.DayWeek, request.ExitDate, request.EntryDate, request.SchoolYearId));

        return Ok(new { TeacheId = response });
    }
    
    #endregion
}