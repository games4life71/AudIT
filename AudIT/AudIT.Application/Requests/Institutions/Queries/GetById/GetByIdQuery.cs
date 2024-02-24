using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetById;

public class GetByIdQuery : IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    public Guid Id { get; set; }

    public GetByIdQuery(Guid id)
    {
        Id = id;
    }
}