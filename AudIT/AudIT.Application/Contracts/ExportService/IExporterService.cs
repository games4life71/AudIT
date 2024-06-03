namespace AudIT.Applicationa.Contracts.ExportService;

/// <summary>
/// This interface is used to define the contract for the Exporter Service.
/// It is used to define the methods that the Exporter Service should implement.
/// </summary>
public interface IExporterService<in T>
{
    public Task<(bool, Stream, string)> ExportMultipleAsync(IEnumerable<T> data, string fileName);

    public Task<(bool, Stream, string)> ExportSingleAsync(T data, string fileName);
}