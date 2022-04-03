using KokoPizza.Blazor.Application.Records;

namespace KokoPizza.Blazor.Application.Components;

public class PaginatedList<T>
{
    public List<T> Items { get; set; }

    public int Count { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < PageSize;

    public PaginatedList()
    {
    }

    public PaginatedList(PaginatedListSettingsRecord<T> settings)
    {
        Items = settings.Items;
        Count = settings.Count;
        PageIndex = settings.PageIndex;
        PageSize = settings.PageSize;
    }
}