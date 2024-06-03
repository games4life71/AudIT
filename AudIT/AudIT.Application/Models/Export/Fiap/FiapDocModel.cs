using Newtonsoft.Json;

namespace AudIT.Applicationa.Models.Export.Fiap;

public class FiapDocModel
{
    public string Title { get; private set; }

    public string AuditMissionName { get; private set; }

    public string ObjectiveName { get; private set; }

    public string Period { get; private set; }

    public string UserName { get; private set; }

    public string Problem { get; private set; }

    public string Constatari { get; private set; }

    public string Cauze { get; private set; }

    public string Consecinte { get; private set; }

    public string Recomandari { get; private set; }

    public readonly Dictionary<string, string> Data = new Dictionary<string, string>();


    public FiapDocModel(string title, string auditMissionName, string objectiveName, string period, string userName,
        string problem, string constatari, string cauze, string consecinte, string recomandari)
    {
        Title = title;
        AuditMissionName = auditMissionName;
        ObjectiveName = objectiveName;
        Period = period;
        UserName = userName;
        Problem = problem;
        Constatari = constatari;
        Cauze = cauze;
        Consecinte = consecinte;
        Recomandari = recomandari;

        //populate the dictionary with the data

        Data.Add("title", Title);
        Data.Add("AuditMissionName", AuditMissionName);
        Data.Add("ObjectiveName", ObjectiveName);
        Data.Add("period", Period);
        Data.Add("UserName", UserName);
        Data.Add("problem", Problem);
        Data.Add("constatari", Constatari);
        Data.Add("cauze", Cauze);
        Data.Add("consecinte", Consecinte);
        Data.Add("recomandari", Recomandari);
        Data.Add("date", DateTime.Now.ToShortDateString());
    }
}