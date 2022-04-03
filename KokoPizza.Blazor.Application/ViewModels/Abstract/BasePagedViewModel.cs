namespace KokoPizza.Blazor.Application.ViewModels.Abstract;

public abstract class BasePagedViewModel<T>
{
    public int Count { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public ICollection<T> Data { get; set; } 
}