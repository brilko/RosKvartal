using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using RepositoryContracts.Intefaces;

namespace RepositoryImplementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationContext context) 
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> ReadPageAsync(SearchPage page)
        {
            return await dbSet
                .Skip(page.Size * (page.Number - 1))
                .Take(page.Size)
                .ToListAsync();
        }
    }
}
