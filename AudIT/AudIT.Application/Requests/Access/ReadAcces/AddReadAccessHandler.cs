using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Domain.Misc;
using MediatR;

namespace AudIT.Applicationa.Requests.Access.ReadAcces;

public class AddReadAccessHandler(
    IRepositoryFactory repositoryFactory
) : IRequestHandler<AddReadAccesCommand, (bool, string)>
{
    public async Task<(bool, string)> Handle(AddReadAccesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var repository = repositoryFactory.Create(request.EntityType.ToString());
            //cast the repository to the correct type
            // repository = (IRepositoryAcces<AuditableEntity>)repository;

            var method = repository.GetType().GetMethod("SetReadAccesAsync");
            // If the method is not found, the repository does not implement SetReadAccesAsync
            if (method == null)
            {
                return (false, "Repository does not implement SetReadAccesAsync");
            }

            // Call the SetReadAccesAsync method
            var task = (Task)method.Invoke(repository, new object[] { request.UserId, request.EntityId });

            // Await the task
            await task;


            // Get the Result property from the task's Result
            var resultProperty = task.GetType().GetProperty("Result");

            // Get the Result value
            var result = resultProperty.GetValue(task);


            return (true, "Read access added successfully");
        }
        catch (Exception e)
        {
            return (false, $"An error occured {e.Message}");
        }
    }
}