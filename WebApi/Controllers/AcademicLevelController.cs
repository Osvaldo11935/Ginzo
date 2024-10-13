using Application.Features.AcademicLevel.Commands.Create;
using Application.Features.AcademicLevel.Queries;
using Application.Features.Common.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class AcademicLevelController : BaseController
{
    #region Post

    [HttpPost("academic-level")]
    public async Task<IActionResult> CreateAcademicLevelAsync([FromBody] List<CreateAcademicLevelRequest> requests)
    {
        bool response =
            await Mediator.Send(
                (BaseCommand<List<CreateAcademicLevelCommand>, bool>) CreateAcademicLevelRequest.Parsing(requests));

        return Ok(new { Success = response });
    }

    #endregion

    #region Get

    [HttpGet("academic-level")]
    public async Task<IActionResult> GetAllCourseAsync([FromQuery] QueryParameterRequest request)
    {
        List<AcademicLevel> academicLevels =
            await Mediator.Send((GetAllAcademicLevelQuery)(request.PageSize, request.PageNumber, request.Search));

        List<AcademicLevelResponse> academicLevelResponses =
            AcademicLevelResponse.AcademicLevelToAcademicLevelResponse(academicLevels);

        return Ok((BasePaginationResponse<List<AcademicLevelResponse>>)(academicLevelResponses, request.PageNumber,
            request.PageSize,
            academicLevelResponses.Count));
    }

    #endregion
}