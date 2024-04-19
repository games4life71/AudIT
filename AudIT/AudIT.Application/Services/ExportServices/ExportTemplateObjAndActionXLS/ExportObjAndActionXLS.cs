using System.Data;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.ObjectiveAndActions;
using OfficeOpenXml;

namespace AudIT.Applicationa.Services.ExportServices.ExportTemplateObjAndActionXLS;

public class ExportObjAndActionXLS : IExporterService<ObjectiveAndActionsExportModel>
{
    private int CURRENT_ROW_MEDIUM = 13;
    private int CURRENT_ROW_LARGE = 13;

    /// <summary>
    /// Exports every Objective and its corresponding ObjectiveActions to a template  file
    /// </summary>
    /// <param name="objectives">List of ObjectiveAndActionExportModel</param>
    /// <param name="fileName">The resulting filename </param>
    /// <typeparam name="T"></typeparam>
    /// <returns>A template XLS file containing the data as a table and additional info</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<(bool, Stream, string)> ExportMultipleAsync(
        IEnumerable<ObjectiveAndActionsExportModel> objectives,
        string fileName)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (ExcelPackage package = new ExcelPackage())
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("NrCrt", typeof(int));
            dataTable.Columns.Add("Obiective", typeof(string));
            dataTable.Columns.Add("Actiuni ", typeof(string));
            dataTable.Columns.Add("Riscuri Identificate", typeof(string));
            dataTable.Columns.Add("Ierarhizare A riscurilor", typeof(string));
            dataTable.Columns.Add("Controlare Interne Existente", typeof(string));
            dataTable.Columns.Add("Controlare Interne Asteptate", typeof(string));

            Dictionary<int, int>
                mergeCellLarge =
                    new Dictionary<int, int>(); //store the start cell and the length of the merge for the large cells
            Dictionary<int, int>
                mergeCellMedium =
                    new Dictionary<int, int>(); //store the start cell and the length of the merge for the medium cells

            //for each objective
            for (var i = 0; i < objectives.Count(); i++)
            {
                //if the objective is not null
                if (objectives.ElementAt(i) == null)
                {
                    Console.WriteLine("Objective is null");
                }


                //for each ObjectiveAction in the Objective
                for (var j = 0; j < objectives.ElementAt(i).ObjectiveActions.Count; j++)
                {
                    mergeCellMedium.Add(CURRENT_ROW_MEDIUM,
                        objectives.ElementAt(i).ObjectiveActions.Count); //number of risks for the action
                    CURRENT_ROW_MEDIUM += objectives.ElementAt(i).ObjectiveActions.Count;


                    //if the action is the first action in the objective
                    if (j == 0)
                        if (objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count > 0)
                        {

                            dataTable.Rows.Add(
                                i,
                                objectives.ElementAt(i).Name, //Objective Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[0].Name,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[0].Risk,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneExistente,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneAsteptate);
                        }
                        // else
                        // {
                        //     dataTable.Rows.Add(
                        //         i,
                        //         objectives.ElementAt(i).Name, //Objective Name
                        //         objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                        //         "", //Risk Name
                        //         "", //Risk
                        //         objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneExistente,
                        //         objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneAsteptate);
                        // }

                    //for each risk in the action
                    for (var k = 0;
                         k < objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count;
                         k++)
                    {
                        //if the risk is the first risk and the action is not the first action
                        if (k == 0 && j != 0)
                        {
                            dataTable.Rows.Add(
                                null,
                                "", //Objective Name is empty
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Name, //
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Risk,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneExistente,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneAsteptate);

                        }
                        //if the risk is not the first then put empty lines for the crt objectiveName and ActionName columns
                        else if (k != 0)
                        {
                            dataTable.Rows.Add(
                                null,
                                "", //Objective Name is empty
                                // objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name is empty
                                "", //Action Name is empty
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Name, //
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Risk,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneExistente,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneAsteptate
                            );
                        }
                        // If the ActionRisk is not the first one or the ObjectiveAction is not the first one
                    }
                    //If the ObjectiveAction has no ActionRisks
                    if (objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count == 0)
                    {
                        dataTable.Rows.Add(
                            null,
                            j == 0 ? objectives.ElementAt(i).Name : "", //Objective Name
                            objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                            "", //Risk Name
                            "", //Risk
                            objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneExistente,
                            objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ControaleInterneAsteptate);
                    }
                }

                int longCount = objectives.Sum(list => objectives.ElementAt(i).ObjectiveActions.Count);
                mergeCellLarge.Add(CURRENT_ROW_LARGE, longCount);
                CURRENT_ROW_LARGE += longCount;
            }

            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("export");
            worksheet.Cells["B12"].LoadFromDataTable(dataTable, true);
            package.Workbook.Properties.Title = "Exported Objectives and Actions";
            package.Workbook.Properties.Author = "AudIT";


            foreach (var mergeMedium in mergeCellMedium)
            {
                var startCell = "D" + mergeMedium.Key;
                var endCell = "D" + (mergeMedium.Key + mergeMedium.Value -1);
                worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
                //make the text centered
                worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                startCell = "G" + mergeMedium.Key;
                endCell = "G" + (mergeMedium.Key + mergeMedium.Value - 1);
                worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
                //make the text centered
                worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                startCell = "H" + mergeMedium.Key;
                endCell = "H" + (mergeMedium.Key + mergeMedium.Value - 1);
                worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
                //make the text centered
                worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

            }

            foreach (var mergeLarge in mergeCellLarge)
            {
                var startCell = "B" + mergeLarge.Key;
                var endCell = "B" + (mergeLarge.Key + mergeLarge.Value - 1);
                worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                startCell = "C" + mergeLarge.Key;
                endCell = "C" + (mergeLarge.Key + mergeLarge.Value - 1);
                worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
                    OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
                    OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            }


            await package.SaveAsync();
            var buffer = await package.GetAsByteArrayAsync();

            var stream = new MemoryStream(buffer);

            return (true, stream, fileName);
        }

        return (false, null, "Could not export data");
    }


    public async Task<(bool, Stream, string)> ExportSingleAsync(ObjectiveAndActionsExportModel data,
        string fileName)
    {
        throw new NotImplementedException();
    }
}