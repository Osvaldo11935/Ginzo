using Application.Features.Common.Commands;
using Application.Features.Course.Commands.Create;
using Application.Features.Course.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class CourseController: BaseController
{
    #region Post
    [HttpPost("course")]
    public async Task<IActionResult> CreateCourseAsync([FromBody] List<CreateCourseRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateCourseCommand>, bool>) CreateCourseRequest.Parsing(requests));

        return Ok(new { CourseId = response });
    }
    #endregion

    #region Get

    [HttpGet("course")]
    public async Task<IActionResult> GetAllCourseAsync([FromQuery] QueryParameterRequest request)
    {
        List<Course> courses =  await Mediator.Send((GetAllCourseQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<CourseResponse> courseResponses = CourseResponse.CourseToCourseResponse(courses);

        return Ok((BasePaginationResponse<List<CourseResponse>>)(courseResponses, request.PageNumber, request.PageSize,
            courseResponses.Count));
    }

    #endregion
}