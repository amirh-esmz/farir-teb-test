using Application.Services.Base;
using Domain.Messages.CandidateAggregate;
using Domain.Models.CandidateAggregate;
using Domain.Repositories.CandidateAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.Services.CandidateAggregate
{
    public class CandidateService : BaseApiService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor, ICandidateRepository candidateRepository,
            IMapper mapper) : base(environment, httpContextAccessor, mapper)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<CandidateDto>> GetCandidates(CandidateFilter filter)
        {
            var result = await _candidateRepository
                .GetCandidatesAsync(filter, IsRequestCancelled);

            return mapper.Map<IEnumerable<CandidateDto>>(result);
        }

        public async Task<(bool isSucceed, string message)> SetStatus(Guid id, bool isAccepted)
        {
            var entity = await _candidateRepository.GetOneAsync(c => c.CandidateId == id);
            if (entity is null)
                return (false, "entity not found");

            if (entity.Status != CandidateStatus.Pending)
                return (false, "candidate status is not pending");

            entity.Status = isAccepted ? CandidateStatus.Accepted : CandidateStatus.Rejected;
            await _candidateRepository.UpdateAsync(entity!);

            return (true, "");
        }
    }
}
