namespace WebApi.Common.Models.Responses.Common;

public class BasePaginationResponse<T>
{
    public T? Data { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalData  { get; set; }

    public BasePaginationResponse(int pageNumber, int pageSize, int totalData, T? data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalData = totalData;
        Data = data;
    }

    public static implicit operator BasePaginationResponse<T>((T? data, int pageNumber, int pageSize, int totalData) value)
        => new(value.pageNumber, value.pageSize, value.totalData, value.data);
}