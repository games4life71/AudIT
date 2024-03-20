using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Contracts.ObjectiveActionServices;



/// <summary>
/// This interface models the ObjectiveActionService which consists of
///methods to compute a score for each Objection Action based on the Obhection Action entity risks
/// and probability of occurence of the risk
/// </summary>
public interface IObjectiveActionService
{
    /// <summary>
    /// Computes the score of an objective action based on the risks and the probability of occurence of the risk
    /// </summary>
    /// <param name="objectiveAction"></param>
    /// <returns></returns>
    public Task<(decimal, bool)> ComputeObjectiveActionScore(ObjectiveAction objectiveAction);

}