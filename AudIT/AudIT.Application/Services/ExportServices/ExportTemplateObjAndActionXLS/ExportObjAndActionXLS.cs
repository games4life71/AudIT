using System.Data;
using System.Text;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.ObjectiveAndActions;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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
                    int totalActionRisksForCurrentObjectiveAction =
                        objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count > 0
                            ? objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count
                            : 1;

                    mergeCellMedium.Add(CURRENT_ROW_MEDIUM,
                        totalActionRisksForCurrentObjectiveAction); //number of risks for the action
                    CURRENT_ROW_MEDIUM += totalActionRisksForCurrentObjectiveAction;


                    //if the action is the first action in the objective
                    if (j == 0)
                        if (objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count > 0)
                        {
                            var controlinternExist = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneExistente);
                            var controlinternAsteptate = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneAsteptate);

                            dataTable.Rows.Add(
                                i,
                                objectives.ElementAt(i).Name, //Objective Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[0].Name,
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[0].Risk,
                                controlinternExist,
                                controlinternAsteptate);
                        }


                    //for each risk in the action
                    for (var k = 0;
                         k < objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count;
                         k++)
                    {
                        //if the risk is the first risk and the action is not the first action
                        if (k == 0 && j != 0)
                        {
                            var controlinternExist = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneExistente);
                            var controlinternAsteptate = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneAsteptate);
                            dataTable.Rows.Add(
                                null,
                                "", //Objective Name is empty
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Name, //
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Risk,
                                controlinternExist,
                                controlinternAsteptate);
                        }
                        //if the risk is not the first then put empty lines for the crt objectiveName and ActionName columns
                        else if (k != 0)
                        {
                            var controlinternExist = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneExistente);
                            var controlinternAsteptate = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                                .ElementAt(j).ControaleInterneAsteptate);
                            dataTable.Rows.Add(
                                null,
                                "", //Objective Name is empty
                                // objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name is empty
                                "", //Action Name is empty
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Name, //
                                objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks[k].Risk,
                                controlinternExist,
                                controlinternAsteptate);
                        }
                        // If the ActionRisk is not the first one or the ObjectiveAction is not the first one
                    }

                    //If the ObjectiveAction has no ActionRisks
                    if (objectives.ElementAt(i).ObjectiveActions.ElementAt(j).ActionRisks.Count == 0)
                    {
                        var controlinternExist = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                            .ElementAt(j).ControaleInterneExistente);
                        var controlinternAsteptate = CollectStringFromList(objectives.ElementAt(i).ObjectiveActions
                            .ElementAt(j).ControaleInterneAsteptate);

                        dataTable.Rows.Add(
                            i,
                            j == 0 ? objectives.ElementAt(i).Name : "", //Objective Name
                            objectives.ElementAt(i).ObjectiveActions.ElementAt(j).Name, //Action Name
                            "", //Risk Name
                            "", //Risk
                            controlinternExist,
                            controlinternAsteptate);
                    }
                }

                int longCount = objectives.ElementAt(i).ObjectiveActions.Sum(obj => obj.ActionRisks.Count);

                int count = 0;
                foreach (var objectiveAction in objectives.ElementAt(i).ObjectiveActions)
                {
                    if (objectiveAction.ActionRisks.Count == 0)
                    {
                        count++;
                    }
                    else
                    {
                        count += objectiveAction.ActionRisks.Count;
                    }
                }

                mergeCellLarge.Add(CURRENT_ROW_LARGE, count);
                CURRENT_ROW_LARGE += count;
            }

            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("export");
            worksheet.Cells["B12"].LoadFromDataTable(dataTable, true);
            package.Workbook.Properties.Title = "Exported Objectives and Actions";
            package.Workbook.Properties.Author = "AudIT";
            StyleWorksheet(worksheet);

            worksheet.Cells["B7"].Value = $"Misiunea de audit: {objectives.ElementAt(0).AuditMission.Name}";
            worksheet.Cells["B8"].Value = $"Intocmit de : {objectives.ElementAt(0).AuditMission.User.UserName}";
            worksheet.Cells["B9"].Value = $"Departament: {objectives.ElementAt(0).AuditMission.Department.Name}";
            worksheet.Cells["B10"].Value = $"Intocmit la : {DateTime.Now.ToString("yyyy-MM-dd")}";

            worksheet.Cells["B7:B10"].Style.Font.Size = 14;
            worksheet.Cells["E4"].Value =
                "Evaluarea initiala a controlului intern si stabilirea obiectivelor de audit";
            worksheet.Cells["E4:G4"].Style.Font.Size = 18;

            worksheet.Columns.AutoFit();


            foreach (var mergeMedium in mergeCellMedium)
            {
                var startCell = "D" + mergeMedium.Key;
                var endCell = "D" + (mergeMedium.Key + mergeMedium.Value - 1);
                MergeCellsAndStyleUtil(worksheet: worksheet, startCell, endCell);

                startCell = "G" + mergeMedium.Key;
                endCell = "G" + (mergeMedium.Key + mergeMedium.Value - 1);

                MergeCellsAndStyleUtil(worksheet: worksheet, startCell, endCell);


                startCell = "H" + mergeMedium.Key;
                endCell = "H" + (mergeMedium.Key + mergeMedium.Value - 1);
                MergeCellsAndStyleUtil(worksheet: worksheet, startCell, endCell);
            }

            foreach (var mergeLarge in mergeCellLarge)
            {
                var startCell = "B" + mergeLarge.Key;
                var endCell = "B" + (mergeLarge.Key + mergeLarge.Value - 1);

                MergeCellsAndStyleUtil(worksheet: worksheet, startCell, endCell);


                startCell = "C" + mergeLarge.Key;
                endCell = "C" + (mergeLarge.Key + mergeLarge.Value - 1);

                MergeCellsAndStyleUtil(worksheet: worksheet, startCell, endCell);
            }


            await package.SaveAsync();
            var buffer = await package.GetAsByteArrayAsync();

            var stream = new MemoryStream(buffer);

            return (true, stream, fileName);
        }

        return (false, null, "Could not export data");
    }

    private void MergeCellsAndStyleUtil(ExcelWorksheet worksheet, string startCell, string endCell)
    {
        worksheet.Cells[$"{startCell}:{endCell}"].Merge = true;
        worksheet.Cells[$"{startCell}:{endCell}"].Style.HorizontalAlignment =
            OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        worksheet.Cells[$"{startCell}:{endCell}"].Style.VerticalAlignment =
            OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        worksheet.Cells[$"{startCell}:{endCell}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
    }

    private void StyleWorksheet(ExcelWorksheet worksheet)
    {
        for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
        {
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                var cell = worksheet.Cells[row, col];
                if (!cell.Text.IsNullOrEmpty())
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                if (row == 12)
                    cell.Style.Font.Bold = true;
            }
        }
    }

    private string CollectStringFromList(List<string> list)
    {
        var sb = new StringBuilder();
        foreach (var item in list)
        {
            sb.Append(item);
            sb.Append($"\n");
        }

        return sb.ToString();
    }

    public async Task<(bool, Stream, string)> ExportSingleAsync(ObjectiveAndActionsExportModel data,
        string fileName)
    {
        throw new NotImplementedException();
    }
}