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
            await Mediator.Send((CreateEnrollmentParameterCommand)(request.EndDate, request.StartDate, schoolYearId,
                request.MinPriorityAge, request.MaxPriorityAge, request.FinalAverage));

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

    [HttpGet("enrollment/enrollment-status")]
    public async Task<IActionResult> GetAllEnrollmentStatusAsync([FromQuery] QueryParameterRequest request)
    {
        List<EnrollmentStatus> enrollments =
            await Mediator.Send((GetAllEnrollmentStatusQuery)(request.PageSize, request.PageNumber, request.Search));

        List<EnrollmentStatusResponse> enrollmentStatusResponses =
            EnrollmentStatusResponse.EnrollmentStatusToEnrollmentStatusResponse(enrollments);

        return Ok((BasePaginationResponse<List<EnrollmentStatusResponse>>)(enrollmentStatusResponses,
            request.PageNumber,
            request.PageSize, enrollmentStatusResponses.Count));
    }

    [HttpGet("enrollment/enrollment-parameters")]
    public async Task<IActionResult> GetAllEnrollmentParametersAsync([FromQuery] QueryParameterRequest request)
    {
        List<EnrollmentParameter> enrollments =
            await Mediator.Send((GetAllEnrollmentParameterQuery)(request.PageSize, request.PageNumber, request.Search));

        List<EnrollmentParameterResponse> enrollmentParameterResponses =
            EnrollmentParameterResponse.EnrollmentParameterToEnrollmentParameterResponse(enrollments);

        return Ok((BasePaginationResponse<List<EnrollmentParameterResponse>>)(enrollmentParameterResponses,
            request.PageNumber,
            request.PageSize, enrollmentParameterResponses.Count));
    }

    #endregion
}