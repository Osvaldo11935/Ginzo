namespace WebApi.Common.Models.Requests.Common;

public class QueryParameterRequest
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string? Search { get; set; }
}