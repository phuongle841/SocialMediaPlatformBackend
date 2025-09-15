namespace SocialMediaPlatformBackend.Data.DAO
{
    public interface IProfileRepository : IRepository<Profile>
    {
        new Task<List<Profile>> GetAll();
        new Task<Profile> GetById(int id);
        new Task<Profile> Add(Profile entity);
        new Task<Profile> Update(Profile entity);
        new Task<Profile> Delete(Profile entity);
    }
}
