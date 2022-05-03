using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.CandidateAggregate
{
    public class Candidate
    {
        public Guid CandidateId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public CandidateStatus Status { get; set; }

        [JsonPropertyName("experience")]
        public virtual ICollection<CandidateExperience> Experiences { get; set; }

        public Candidate()
        {
            Experiences = new List<CandidateExperience>();
        }
    }
}
