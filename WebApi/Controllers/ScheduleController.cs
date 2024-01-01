using Application.Features.Common.Commands;
using Application.Features.Schedule.Commands.Create;
using Application.Features.Schedule.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class ScheduleController: BaseController
{
    #region Post
    [HttpPost("schedule")]
    public async Task<IActionResult> CreateScheduleAsync([FromBody] List<CreateScheduleRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateScheduleCommand>, bool>) CreateScheduleRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    
    #endregion
    
    #region Get

    [HttpGet("schedule")]
    public async Task<IActionResult> GetAllScheduleAsync([FromQuery] QueryParameterRequest request)
    {
        List<Schedule> courses =  await Mediator.Send((GetAllScheduleQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<ScheduleResponse> scheduleResponses = ScheduleResponse.ScheduleToScheduleResponse(courses);

        return Ok((BasePaginationResponse<List<ScheduleResponse>>)(scheduleResponses, request.PageNumber, request.PageSize,
            scheduleResponses.Count));
    }

    #endregion
}