using Application.Features.AcademicLevel.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class AcademicLevelController: BaseController
{
    #region Post
    [HttpPost("academic-level")]
    public async Task<IActionResult> CreateAcademicLevelAsync([FromBody] CreateAcademicLevelRequest request)
    {
        string response =  await Mediator.Send((CreateAcademicLevelCommand)request.Level);

        return Ok(new { AcademicLevelId = response });
    }
    
    #endregion
}