using Microsoft.EntityFrameworkCore;
using RepositoryContracts.Entities;

namespace RepositoryImplementations
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationResult> ExaminationResultsDbSet { get; set; }
        public DbSet<ExaminationStatus> ExaminationStatusesDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ExaminationResult>()
                .HasData(ExaminationResults.Variable);

            modelBuilder
                .Entity<ExaminationStatus>()
                .HasData(ExaminationStatuses.Variables);
        }
    }
}
