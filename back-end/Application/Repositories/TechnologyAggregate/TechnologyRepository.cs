using Application.Repositories.Base;
using Domain.Models.TechnologyAggregate;
using Domain.Repositories.TechnologyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.TechnologyAggregate
{
    public class TechnologyRepository : GenericRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}
