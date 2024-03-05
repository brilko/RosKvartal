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

        public async Task<List<Guid>> GetIdsStartNotPreviousAsync(DateTime date)
        {
            return await examinations
                .Where(e => e.Deleted == false)
                .Where(e => e.Start >= date)
                .Select(e => e.Id)
                .ToListAsync();
        }
    }
}
