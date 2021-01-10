namespace SecurityPractice.Common.DataAccess
{
    using System.Threading.Tasks;

    public interface IAddEntity<in T>
        where T : class
    {
        Task AddEntity(T entity);
    }
}
