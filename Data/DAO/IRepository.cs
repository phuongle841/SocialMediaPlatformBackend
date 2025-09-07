namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> getAll();
        Task<T> getById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
