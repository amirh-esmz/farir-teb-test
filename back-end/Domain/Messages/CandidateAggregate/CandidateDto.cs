using Domain.Models.CandidateAggregate;

namespace Domain.Messages.CandidateAggregate
{
    public class CandidateDto
    {
        public Guid CandidateId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public CandidateStatus Status { get; set; }

        public IEnumerable<CandidateExperienceDto> Experiences { get; set; } = null!;
    }
}
