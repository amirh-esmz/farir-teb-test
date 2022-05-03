using Domain.Models.TechnologyAggregate;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.TechnologyAggregate
{
    public interface ITechnologyRepository : IGenericRepository<Technology>
    {
    }
}
