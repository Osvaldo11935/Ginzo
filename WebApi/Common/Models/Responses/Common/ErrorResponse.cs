using WebApi.Common.Models.Enums;

namespace WebApi.Common.Models.Responses.Common;

public class ErrorResponse
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public GinzoErrorCode Code { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Message { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Description { get; set; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public List<string>? Errors { get; set; }

    public ErrorResponse(string message, string description, GinzoErrorCode code = GinzoErrorCode.Unknow) {
        Message = message;
        Description = description;
        Code = code;
    }

    public ErrorResponse() {
        Message = string.Empty;
        Description = string.Empty;
        Code = GinzoErrorCode.Unknow;
    }

}
