
using Domain.Models.CandidateAggregate;
using Domain.Models.TechnologyAggregate;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        }
    
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }   
    }
}
