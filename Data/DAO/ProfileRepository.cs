namespace SocialMediaPlatformBackend.Data.DAO
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly AppDbContext _appDbContext;

        public ProfileRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Profile> Add(Profile entity)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Delete(Profile entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Profile>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Profile> getById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Update(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}
