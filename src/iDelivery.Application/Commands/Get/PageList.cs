namespace iDelivery.Application.Commands.Get;
public sealed class PageList<T>
{
    public List<T> Items {get; }
    public int Page {get; }
    public int PageSize {get; }
    public int TotalCount {get; }
    public bool HasNextPage => Page * PageSize <TotalCount;
    public bool HasPreviousPage => PageSize > 1;

    private PageList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static PageList<T> Create(IQueryable<T> query, int page, int pageSize)
    {
        var totalCount = query.Count();
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return new(items, page, pageSize, totalCount);
    }
}
