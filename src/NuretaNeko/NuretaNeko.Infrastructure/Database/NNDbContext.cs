using Microsoft.EntityFrameworkCore;
using NuretaNeko.Domain.Entities;
using NuretaNeko.Domain.Mapping;

namespace NuretaNeko.Infrastructure.Database
{
    public class NNDbContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillOption> SkillOptions { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }


        public NNDbContext(DbContextOptions options) : base(options) {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new SkillMapping());
            modelBuilder.ApplyConfiguration(new SkillOptionMapping());
            modelBuilder.ApplyConfiguration(new ResumeMapping());
            modelBuilder.ApplyConfiguration(new CandidateMapping());
        }
    }
}
