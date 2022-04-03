namespace KokoPizza.Core.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportToCsv<T>(List<T> eventExportDtos) where T : class;
}