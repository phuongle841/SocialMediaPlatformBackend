namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<List<Profile>> GetAll();
        Task<Profile> GetById(int id);
        Task<Profile> Add(Profile entity);
        Task<Profile> Update(Profile entity);
        Task<Profile> Delete(Profile entity);
    }
}
