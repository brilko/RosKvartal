using Microsoft.EntityFrameworkCore;
using RepositoryContracts.Entities;

namespace RepositoryImplementations
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationResult> ExaminationResultsDbSet { get; set; }
        public DbSet<ExaminationStatus> ExaminationStatusesDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ExaminationResult>()
                .HasData(ExaminationResults.Variables);

            modelBuilder
                .Entity<ExaminationStatus>()
                .HasData(ExaminationStatuses.Variables);
        }
    }
}
