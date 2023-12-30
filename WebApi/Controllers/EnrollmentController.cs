using Application.Features.Enrollment.Commands.Create;
using Application.Features.Enrollment.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Models.Requests;
using WebApi.Common.Models.Requests.Common;
using WebApi.Common.Models.Responses;
using WebApi.Common.Models.Responses.Common;
using WebApi.Controllers.Common;

namespace WebApi.Controllers;

public class EnrollmentController : BaseController
{
    #region Post

    [HttpPost("student/{studentId}/enrollment")]
    public async Task<IActionResult> CreateEnrollmentAsync([FromRoute] string studentId,
        [FromBody] CreateEnrollmentRequest request)
    {
        string response =
            await Mediator.Send((CreateEnrollmentCommand)(studentId, request.FinalAverage,
                request.SetDataEnrolledCourses()));

        return Ok(new { EnrollmentId = response });
    }

    [HttpPost("enrollment/enrollment-status")]
    public async Task<IActionResult> CreateEnrollmentStatusAsync([FromBody] CreateEnrollmentStatusRequest request)
    {
        string response = await Mediator.Send((CreateEnrollmentStatusCommand)(request.Status, request.Description));

        return Ok(new { EnrollmentStatusId = response });
    }

    [HttpPost("enrollment/schoolYear/{schoolYearId}/enrollment-parameter")]
    public async Task<IActionResult> CreateEnrollmentParameterAsync([FromRoute] string schoolYearId,
        [FromBody] CreateEnrollmentParameterRequest request)
    {
        string response =
            await Mediator.Send((CreateEnrollmentParameterCommand)(request.EndDate, request.StartDate, schoolYearId));

        return Ok(new { EnrollmentParameterId = response });
    }

    #endregion

    #region Get

    [HttpGet("enrollment")]
    public async Task<IActionResult> CreateEnrollmentParameterAsync([FromQuery] QueryParameterRequest request)
    {
        List<Enrollment> enrollments =
            await Mediator.Send((GetAllEnrollmentQuery)(request.PageSize, request.PageNumber, request.Search));
        
        List<EnrollmentResponse> enrollmentResponses =
            EnrollmentResponse.EnrollmentToEnrollmentResponse(enrollments);
        
        return Ok((BasePaginationResponse<List<EnrollmentResponse>>)(enrollmentResponses, request.PageNumber,
            request.PageSize, enrollmentResponses.Count));
    }

    #endregion
}