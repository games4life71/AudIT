using System.Globalization;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Mappings.CSVMappings;
using AudiT.Domain.Entities;
using CsvHelper;
using CsvHelper.Configuration;

namespace AudIT.Applicationa.Services.ExportServices.ExportAsCSVService;

public class CSVExporterService : IExporterService
{
    private static readonly Dictionary<Type, Type> _classMappingDictionary = new Dictionary<Type, Type>()
    {
        { typeof(Activity), typeof(ActivityMap) }
    };


    public async Task<(bool, Stream, string)> ExportAsync<T>(IEnumerable<T> data, string fileName)
    {
        try
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            if (_classMappingDictionary.TryGetValue(typeof(T), out var mapping))
            {
                var map = (ClassMap)Activator.CreateInstance(mapping)!;
                csvWriter.Context.RegisterClassMap(map); // Register the ClassMap instance
            }

            await csvWriter.WriteRecordsAsync(data);

            await streamWriter.FlushAsync();
            memoryStream.Position = 0;

            return (true, memoryStream, "Data exported successfully");
        }
        catch (Exception ex)
        {
            return (false, null, $"An error occurred: {ex.Message}");
        }
    }
}