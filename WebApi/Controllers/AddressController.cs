using Application.Features.Address.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class AddressController : BaseController
{
    #region Get

    [HttpGet("user/{userId}/address")]
    public async Task<IActionResult> GetAddressByUser([FromRoute] string userId)
    {
        Address address = await Mediator.Send((GetAddressByUserQuery)userId);

        AddressResponse addressResponse =
            AddressResponse.AddressToAddressResponse(address);

        return Ok((BaseResponse<AddressResponse>)addressResponse);
    }

    #endregion
}