
namespace Domain.Messages.CandidateAggregate
{
    public class CandidateExperienceDto
    {
        public Guid Id { get; set; }
        public int YearsOfExperience { get; set; }

        public string? TechnologyName { get; set; }
    }
}
