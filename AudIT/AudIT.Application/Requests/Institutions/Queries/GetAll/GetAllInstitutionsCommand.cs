﻿using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetAll;

public class GetAllInstitutionsCommand:IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    
}