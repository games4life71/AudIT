using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface ITemplateDocRepository: IRepository<TemplateDocument>
{
    public  Task<Result<TemplateDocument>> GetTemplateDocumentByName(string name);
}