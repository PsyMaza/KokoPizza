namespace KokoPizza.Blazor.Application.Records;

public record PaginatedListSettingsRecord<T>(List<T> Items, int Count, int PageIndex, int PageSize);