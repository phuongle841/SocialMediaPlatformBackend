namespace SocialMediaPlatformBackend.Data.DAO
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProfileRepository> _logger;
        public ProfileRepository(AppDbContext appDbContext, ILogger<ProfileRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Profile> Add(Profile entity)
        {
            var result = _appDbContext.Profiles.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Profile> Delete(Profile entity)
        {
            var deletedProfile = await _appDbContext.Profiles.FindAsync(entity.ProfileId);
            if (deletedProfile == null)
            {
                return null;
            }
            _appDbContext.Profiles.Remove(deletedProfile);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public Task<List<Profile>> getAll()
        {
            List<Profile> profiles = _appDbContext.Profiles.ToList();
            return Task.FromResult(profiles);
        }

        public Task<Profile> getById(int id)
        {
            try
            {
                Profile profile = _appDbContext.Profiles.Find(id);
                return Task.FromResult(profile);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving the profile with ID {ProfileId}", id);
                throw;
            }
        }

        public async Task<Profile> Update(Profile entity)
        {
            Profile exsitingProfile = _appDbContext.Profiles.Find(entity.ProfileId);
            if (exsitingProfile == null)
            {
                return null;
            }
            _appDbContext.Entry(exsitingProfile).CurrentValues.SetValues(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
