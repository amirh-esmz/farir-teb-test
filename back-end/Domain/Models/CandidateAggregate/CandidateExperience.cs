using Domain.Models.TechnologyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CandidateAggregate
{
    public class CandidateExperience
    {
        public Guid Id { get; set; }
        public int YearsOfExperience { get; set; }

        public Guid TechnologyId { get; set; }
        public Guid CandidateId { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual Technology? Technology { get; set; }

        public string? TechnologyName => Technology?.Name;
    }
}
