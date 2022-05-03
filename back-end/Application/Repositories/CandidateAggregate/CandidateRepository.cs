using Application.Repositories.Base;
using Domain.Messages.CandidateAggregate;
using Domain.Models.CandidateAggregate;
using Domain.Repositories.CandidateAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.CandidateAggregate
{
    public class CandidateRepository : GenericRepository<Candidate>,
        ICandidateRepository
    {
        public CandidateRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync(CandidateFilter filter,
            CancellationToken cancellationToken = default)
        {
            var candidateQuery = dbContext.Candidates.AsQueryable();

            if (filter.OnlyPending)
                candidateQuery = candidateQuery.Where(c => c.Status == CandidateStatus.Pending);

            if (filter.TechnologyId.HasValue || filter.MinYearsOfExperience.HasValue)
            {
                var experienceQuery = dbContext.Set<CandidateExperience>().AsQueryable();

                if (filter.MinYearsOfExperience.HasValue)
                    experienceQuery = experienceQuery
                        .Where(c => c.YearsOfExperience >= filter.MinYearsOfExperience);

                if (filter.TechnologyId.HasValue)
                    experienceQuery = experienceQuery
                        .Where(c => c.TechnologyId == filter.TechnologyId);

                candidateQuery = (from candidate in candidateQuery
                                  join experience in experienceQuery
                                  on candidate.CandidateId equals experience.CandidateId
                                  select candidate);
            }

            return await candidateQuery.Include(c => c.Experiences)
                .ThenInclude(c=>c.Technology).ToListAsync(cancellationToken);
        }
    }
}
