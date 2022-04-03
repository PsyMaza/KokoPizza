namespace KokoPizza.Core.Application.Models.Common;

public abstract class BasePagedType<T>
{
    public int Count { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }

    public ICollection<T> Data { get; set; }
}