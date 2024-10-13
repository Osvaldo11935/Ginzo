using Application.Features.Common.Commands;
using Application.Features.VacancyCourse.Commands.Create;
using Application.Features.VacancyCourse.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class VacancyCourseController: BaseController
{
    #region Post
    [HttpPost("enrollment-parameter/{enrollmentParameterId}/vacancy-course")]
    public async Task<IActionResult> CreateVacancyCourseAsync([FromRoute] string enrollmentParameterId, [FromBody] List<CreateVacancyCourseRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateVacancyCourseCommand>, bool>) CreateVacancyCourseRequest.Parsing(requests, enrollmentParameterId));

        return Ok(new { Success = response });
    }
    #endregion
    
    #region Get

    [HttpGet("vacancy-course")]
    public async Task<IActionResult> GetAllVacancyCourseAsync([FromQuery] QueryParameterRequest request)
    {
        List<VacancyCourse> vacancyCourses =  await Mediator.Send((GetAllVacancyCourseQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<VacancyCourseResponse> vacancyCourseResponses = VacancyCourseResponse.VacancyCourseToVacancyCourseResponse(vacancyCourses);

        return Ok((BasePaginationResponse<List<VacancyCourseResponse>>)(vacancyCourseResponses, request.PageNumber, request.PageSize,
            vacancyCourseResponses.Count));
    }

    #endregion
    
}