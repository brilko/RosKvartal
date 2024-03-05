using Microsoft.EntityFrameworkCore;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;

namespace RepositoryImplementations
{
    public class UpdateDateRepository : Repository<UpdateDate>, IUpdateDateRepository
    {
        private readonly DbSet<UpdateDate> updateDateSet;
        public UpdateDateRepository(ApplicationContext context) : base(context) 
        {
            updateDateSet = context.Set<UpdateDate>();
        }

        public async Task AddDateNowAsync()
        {
            var dateOfUpdate = new UpdateDate()
            {
                Date = DateTime.UtcNow,
                Deleted = false,
                Id = Guid.NewGuid(),
            };
            await AddAsync(dateOfUpdate);
        }

        public async Task<DateTime> GetDateOfLastUpdate()
        {
            return await updateDateSet
                .Select(ud => ud.Date)
                .MaxAsync();
        }
    }
}
