namespace WebApi.Common.Models.Responses.Common;

public class BaseResponse<T>
{
    public T? Data { get; set; }

    public BaseResponse(T? data)
    {
        Data = data;
    }

    public static implicit operator BaseResponse<T>(T? data)
        => new(data);
}