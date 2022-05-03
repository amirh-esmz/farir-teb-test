using Domain.Messages.CandidateAggregate;
using Domain.Models.CandidateAggregate;
using Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.CandidateAggregate
{
    public interface ICandidateRepository : IGenericRepository<Candidate>
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync(CandidateFilter filter,
            CancellationToken cancellationToken = default);
    }
}
