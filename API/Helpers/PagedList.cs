using Microsoft.EntityFrameworkCore;

namespace API.Helpers;

public class PagedList<T> : List<T> 
{
    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        PageSize = pageSize;
        TotalCount = count;
        // items will be added to the PagedList
        AddRange(items);
    }

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,
        int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        // Calculate the number of items to skip,
        // then take the number of items for a pageSize,
        // to make them into a list
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
