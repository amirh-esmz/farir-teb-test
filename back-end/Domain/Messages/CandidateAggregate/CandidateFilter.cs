using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages.CandidateAggregate
{
    public class CandidateFilter
    {
        public bool OnlyPending { get; set; }
        public int? MinYearsOfExperience { get; set; }
        public Guid? TechnologyId { get; set; }
    }
}
