using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.Fiap;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using OpenXMLTemplates.Documents;
using OpenXMLTemplates.Engine;
using OpenXMLTemplates.Variables;

namespace AudIT.Applicationa.Services.ExportServices.ExportFiapTemplateDoc;

public class ExportFiapDoc : IExporterService<FiapDocModel>
{
    public async Task<(bool, Stream, string)> ExportMultipleAsync(IEnumerable<FiapDocModel> data, string fileName)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method receives a FiapDocModel and autogenerates a Fiap Official DOCX.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public async Task<(bool, Stream, string)> ExportSingleAsync(FiapDocModel data, string fileName)
    {
        try
        {
            using var doc = new TemplateDocument("C:\\Users\\stefy\\Desktop\\fiap_template.docx");

            var dict = data.Data;

            if (dict != null)
            {
                var src = new VariableSource(dict);

                var engine = new DefaultOpenXmlTemplateEngine();
                engine.ReplaceAll(doc, src);
            }

            // doc.SaveAs("D:\\Projects\\AudIT\\AudIT\\AudIT\\ConsoleApp1\\Output\\result2.docx");


            // Create a temporary file path
            var tempFilePath = Path.GetTempFileName();

            // Save the document to the temporary file
            // doc.SaveAs(tempFilePath);
            doc.WordprocessingDocument.Save();
            var stream = new MemoryStream();

            // Create a new WordprocessingDocument in the MemoryStream
            using (var newDoc = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                // Copy all parts from the original WordprocessingDocument to the new one
                foreach (var part in doc.WordprocessingDocument.Parts)
                {
                    newDoc.AddPart(part.OpenXmlPart, part.RelationshipId);
                }
            }


            // var stream = new MemoryStream(bytes);

            // Delete the temporary file
            stream.Position = 0;

            return (true, stream, "Success");
        }
        catch (Exception e)
        {
            return (false, null, e.Message);
        }
    }
}