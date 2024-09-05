using System.Text.Json;
using API.Helpers;

namespace API.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader<T>(this HttpResponse response, PagedList<T> data)
    {
        var paginationHeader = new PaginationHeader(data.CurrentPage, data.PageSize,
            data.TotalCount, data.TotalPages);

        // As it's outside of API controller functionality, we need to instruct the format
        var jsonOptions = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));
        // Return a CORS header to allow the client to access Pagination header
        response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
    }
}
