using Application.Features.Common.Commands;
using Application.Features.SchoolYear.Commands.Create;
using Application.Features.SchoolYear.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class SchoolYearController: BaseController
{
    #region Post
    [HttpPost("school-year")]
    public async Task<IActionResult> CreateSchoolYearAsync([FromBody] List<CreateSchoolYearRequest> requests)
    {
        bool response =  await Mediator.Send(
            (BaseCommand<List<CreateSchoolYearCommand>, bool>) CreateSchoolYearRequest.Parsing(requests));

        return Ok(new { Success = response });
    }
    #endregion

    #region Get

    [HttpGet("school-year")]
    public async Task<IActionResult> GetAllSchoolYearAsync([FromQuery] QueryParameterRequest request)
    {
        List<SchoolYear> schoolYears =  await Mediator.Send((GetAllSchoolYearQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<SchoolYearResponse> schoolYearResponses = SchoolYearResponse.SchoolYearToSchoolYearResponse(schoolYears);

        return Ok((BasePaginationResponse<List<SchoolYearResponse>>)(schoolYearResponses, request.PageNumber, request.PageSize,
            schoolYearResponses.Count));
    }

    #endregion
}