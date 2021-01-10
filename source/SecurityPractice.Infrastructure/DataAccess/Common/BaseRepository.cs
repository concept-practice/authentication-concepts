namespace SecurityPractice.Infrastructure.DataAccess.Common
{
    using System.Threading.Tasks;
    using SecurityPractice.Common.DataAccess;

    public abstract class BaseRepository<T> :
        IAddEntity<T>
        where T : class
    {
        private readonly ApplicationContext _context;

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }
    }
}
