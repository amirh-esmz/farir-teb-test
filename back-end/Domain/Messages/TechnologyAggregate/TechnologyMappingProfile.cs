using AutoMapper;
using Domain.Models.TechnologyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages.TechnologyAggregate
{
    public class TechnologyMappingProfile : Profile
    {
        public TechnologyMappingProfile()
        {
            CreateMap<Technology, TechnologyDto>();
        }
    }
}
