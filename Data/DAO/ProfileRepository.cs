using Microsoft.EntityFrameworkCore;
using SocialMediaPlatformBackend.Models;

namespace SocialMediaPlatformBackend.Data.DAO
{
    public class ProfileRepository : IProfileRepository
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

        public Task<List<Profile>> GetAll()
        {
            // this cause circular reference issue, since Post also has a reference(Navigation) to Profile
            List<Profile> profiles = _appDbContext.Profiles.Include(p => p.Posts).ToList();

            return Task.FromResult(profiles);
        }

        public Task<Profile> GetById(int id)
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
            Profile? existingProfile = _appDbContext.Profiles.Find(entity.ProfileId);
            if (existingProfile == null)
            {
                return null;
            }
            _appDbContext.Entry(existingProfile).CurrentValues.SetValues(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
