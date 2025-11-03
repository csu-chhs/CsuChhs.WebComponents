namespace CsuChhs.WebComponents.ResourceModels;

public interface IProtectedPageResource<T>
{
    int CurrentPage { get; init; }
    int TotalPages { get; init; }
    List<T> Items { get; }
    void UpdateItems(List<T> items);
}