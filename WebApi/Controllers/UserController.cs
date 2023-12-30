using Application.Features.Address.Commands.Create;
using Application.Features.PersonalData.Commands.Create;
using Application.Features.User.Commands.Create;
using Application.Features.User.Queries;
using Domain.Common.ValueObjects;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class UserController : BaseController
{
    #region Post

    [HttpPost("user/teacher")]
    public async Task<IActionResult> CreateTeacherAsync([FromBody] CreateUserRequest request)
    {
        string response = await Mediator.Send((CreateUserCommand)(request.UserName, request.Password,  RoleValueObject.TeacherName,
            request.PhoneNumber, request.DocumentNumber,
            request.BirthDate, request.Name, request.Email));


        return Ok(new { TeacheId = response });
    }

    [HttpPost("user/student")]
    public async Task<IActionResult> CreateStudentAsync([FromBody] CreateUserRequest request)
    {
        string responseUser = await Mediator.Send((CreateUserCommand)(request.UserName, request.Password, RoleValueObject.StudentName,
            request.PhoneNumber, request.DocumentNumber, request.BirthDate, request.Name, request.Email));

        await Mediator.Send((CreatePersonalDataCommand)(request.PersonalData!.Mother, request.PersonalData!.Father,
            request.PersonalData!.Natural, request.PersonalData!.DocumentIssuanceDate, request.PersonalData!.DocumentExpirationDate,
            request.PersonalData!.PlaceIssuanceDocument, responseUser));

        await Mediator.Send((CreateAddressCommand)(request.Address!.Country, request.Address!.County, request.Address!.Province,
            request.Address!.Number, request.Address!.Street, request.Address!.Complement,request.Address!.District, 
            request.Address!.Neighborhood, responseUser));
        
        return Ok(new { StudentId = responseUser });
    }

    [HttpPost("user/admin")]
    public async Task<IActionResult> CreateAdminAsync([FromBody] CreateUserRequest request)
    {
        string response = await Mediator.Send((CreateUserCommand)(request.UserName, request.Password,  RoleValueObject.AdminName,
            request.PhoneNumber, request.DocumentNumber,
            request.BirthDate, request.Name, request.Email));

        return Ok(new { StudentId = response });
    }

    #endregion

    #region Get
    
    [HttpGet("user/students")]
    public async Task<IActionResult> GetAddressByUser([FromQuery] QueryParameterRequest request)
    {
        List<Student> users = await Mediator.Send((GetAllStudentQuery)(request.PageSize, request.PageNumber,  request.Search));

        List<StudentResponse> userResponses =
            StudentResponse.StudentToStudentResponse(users);

        return Ok((BasePaginationResponse<List<StudentResponse>>)(userResponses, request.PageNumber, request.PageSize,
            userResponses.Count));
    }
    
    #endregion
}