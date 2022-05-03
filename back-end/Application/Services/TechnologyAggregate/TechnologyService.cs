using Application.Services.Base;
using Domain.Messages.TechnologyAggregate;
using Domain.Repositories.TechnologyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TechnologyAggregate
{
    public class TechnologyService : BaseApiService
    {
        private readonly ITechnologyRepository technologyRepository;
        public TechnologyService(IWebHostEnvironment environment, IHttpContextAccessor
            httpContextAccessor, IMapper mapper, ITechnologyRepository technologyRepository) : base(environment, httpContextAccessor, mapper)
        {
            this.technologyRepository = technologyRepository;
        }

        public async Task<IEnumerable<TechnologyDto>> GetAll()
        {
            var entities = await technologyRepository.GetAllAsync();
            return mapper.Map<IEnumerable<TechnologyDto>>(entities);
        }
    }
}
