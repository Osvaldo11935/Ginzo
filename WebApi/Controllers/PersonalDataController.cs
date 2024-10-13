using Application.Features.PersonalData.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class PersonalDataController : BaseController
{
    #region Get

    [HttpGet("user/{userId}/personal-data")]
    public async Task<IActionResult> GetPersonalDataByUser([FromRoute] string userId)
    {
        PersonalData personalData = await Mediator.Send((GetPersonalDataByUserQuery)userId);
        
        PersonalDataResponse personalDataResponse =
            PersonalDataResponse.PersonalDataToPersonalDataResponse(personalData);

        return Ok((BaseResponse<PersonalDataResponse>) personalDataResponse);
    }
 
    #endregion
}