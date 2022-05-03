using AutoMapper;
using Domain.Models.CandidateAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages.CandidateAggregate
{
    public class CandidateMappingProfile : Profile
    {
        public CandidateMappingProfile()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CandidateExperience, CandidateExperienceDto>();
        }
    }
}
