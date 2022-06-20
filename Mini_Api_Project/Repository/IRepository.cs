namespace ASP.NET_CORE_TRY.Repository;

public interface IRepository<T>
{
    Task<T> Get(int? id);
    
    Task Update(T entity);

    Task<IEnumerable<T>> GetAll();

    Task<T> GetByName(string name);

    Task<T> GetByAge(int age);

    Task<T> Add(T entity);

    Task Delete(T entity);
}