using Microsoft.EntityFrameworkCore;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;

namespace RepositoryImplementations
{
    public class ExaminationRepository : Repository<Examination>, IExaminationRepository
    {
        private readonly DbSet<Examination> examinations;
        public ExaminationRepository(ApplicationContext context): base(context) 
        {
            examinations = context.Set<Examination>();
        }

        public async Task<DateTime> GetDateOfLastUploadedExamination()
        {
            return await examinations
                .Where(e => e.Deleted == false)
                .MaxAsync(x => x.Date);
        }

        public async Task<List<Guid>> GetExaminationsIdsWithDate(DateTime date)
        {
            return await examinations
                .Where(e => e.Date == date)
                .Where(e => e.Date == date)
                .Select(e => e.Id)
                .ToListAsync();
        }
    }
}
