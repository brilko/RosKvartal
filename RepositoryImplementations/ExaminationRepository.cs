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
            return await examinations.MaxAsync(x => x.Date);
        }
    }
}
