using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Access.ReadAcces;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml.Export.HtmlExport;
using Activity = System.Diagnostics.Activity;

namespace AudIT.Infrastructure.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly AudITContext _context;
    private readonly IServiceProvider _serviceProvider;
    private Dictionary<string, Type> _repositoryTypeMap;

    public RepositoryFactory(AudITContext context,IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;

        //add the repository types to the dictionary
        _repositoryTypeMap = new Dictionary<string, Type>
        {
            { "Activity", typeof(Activity) },
            { "AuditMission", typeof(AuditMission) },
            { "Department", typeof(Department) },
            { "Institution", typeof(Institution) },
            { "Objective", typeof(Objective) },
            { "ObjectiveAction", typeof(ObjectiveAction) },
            { "ObjectiveActionFiap", typeof(ObjectiveActionFiap) },
            { "Recommendation", typeof(Recommendation) },
            { "StandaloneDocument", typeof(StandaloneDocument) },
            { "TemplateDocument", typeof(TemplateDocument) },
        };
    }

    public (bool,Type) GetRepositoryType(string entityName)
    {
        if (!_repositoryTypeMap.ContainsKey(entityName))
        {
            return (false, null)!;
        }

        return (true ,_repositoryTypeMap[entityName]);
    }
    // public IRepositoryAcces<T> Create<T>(EntityType entityType) where T : AuditableEntity
    // {
    //     if (!_repositoryTypeMap.TryGetValue(entityType.ToString(), out var entityClassType))
    //     {
    //         throw new ArgumentException($"Invalid entity type: {entityType}");
    //     }
    //
    //     if (typeof(T) != entityClassType)
    //     {
    //         throw new ArgumentException($"Entity type mismatch: {typeof(T)} does not match {entityClassType}");
    //     }
    //
    //     return _serviceProvider.GetRequiredService<IRepositoryAcces<T>>();
    // }

    public IBaseAcces Create(string entityType)
    {
        var repositoryTypes = GetRepositoryType(entityType);

        if (!repositoryTypes.Item1)
        {
            return null;
        }

        var repoType = repositoryTypes.Item2;
        //
        // // Get the type of the repository
        //
        //
        // // Create the repository
        //
        // // Get the type of the repository
        //
        // // Create the repository
        // return (IRepositoryAcces<AuditableEntity>)_serviceProvider.GetRequiredService(repositoryTypes.Item2);

        var genericBaseAccesRepositoryType = typeof(IRepositoryAcces<>);

        // Make the repository type
        var constructedBaseAccesRepositoryType = genericBaseAccesRepositoryType.MakeGenericType(repoType);

        // Create the repository
        return (IBaseAcces)_serviceProvider.GetRequiredService(constructedBaseAccesRepositoryType);
    }
}