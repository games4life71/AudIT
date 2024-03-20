using AudIT.Applicationa.Contracts.ObjectiveActionServices;
using AudiT.Domain.Entities;
using Exception = System.Exception;

namespace AudIT.Applicationa.Services.ObjectiveActionServices;

public class ObjectiveActionService: IObjectiveActionService
{
    public async Task<(decimal, bool)> ComputeObjectiveActionScore(ObjectiveAction objectiveAction)
    {

        try
        {
            decimal totalScore = 0;
            decimal maxScore = objectiveAction.ActionRisks.Count * 10 * 10;

            foreach (var actionRisk in objectiveAction.ActionRisks)
            {
                totalScore += actionRisk.Probability * actionRisk.Impact;
            }

            var percentage = (totalScore / maxScore) * 100;

            return (percentage, true);

        }
        catch (Exception e)
        {
            return (0, false);
        }

    }
}