using Application.Features.Class.Commands.Create;
using Application.Features.Class.Queries;
using Application.Features.Common.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class ClassController: BaseController
{
    #region Post
    [HttpPost("class")]
    public async Task<IActionResult> CreateClassAsync([FromBody] List<CreateClassRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateClassCommand>, bool>) CreateClassRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    
    [HttpPost("class/schedule")]
    public async Task<IActionResult> AddScheduleClassAsync([FromBody] List<CreateClassScheduleRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateClassScheduleCommand>, bool>) CreateClassScheduleRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    
    [HttpPost("class/{classId}/student")]
    public async Task<IActionResult> AddStudentClassAsync([FromRoute] string classId, [FromBody] CreateStudentClassRequest request)
    {
        bool response =  await Mediator.Send((CreateStudentClassCommand)(classId, request.StudentIds));

        return Ok(new { Success = response });
    }
    #endregion
    
    #region Get

    [HttpGet("class")]
    public async Task<IActionResult> GetAllClassAsync([FromQuery] QueryParameterRequest request)
    {
        List<Class> @classes =  await Mediator.Send((GetAllClassQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<ClassResponse> classResponses = ClassResponse.ClassToClassResponse(@classes);

        return Ok((BasePaginationResponse<List<ClassResponse>>)(classResponses, request.PageNumber, request.PageSize,
            classResponses.Count));
    }

    #endregion
}