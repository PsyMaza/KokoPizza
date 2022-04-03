using CsvHelper;
using KokoPizza.Core.Application.Contracts.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace KokoPizza.Infrastructure.Infrastructure.FileExporter;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportToCsv<T>(List<T> eventExportDtos) where T : class
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(eventExportDtos);
        }

        return memoryStream.ToArray();
    }
}