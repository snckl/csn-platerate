namespace PlateRate.Application.Common;
public class PageResult<T>
{

    public PageResult(IEnumerable<T> items,int totalCount,int page,int size)
    {
        Items = items;
        TotalItemsCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)size);
        ItemsFrom = size * (page - 1) + 1;
        ItemsTo = ItemsFrom + size - 1;
    }

    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount  { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
}
