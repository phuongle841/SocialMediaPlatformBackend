namespace SocialMediaPlatformBackend.Data.DTO
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Data.DTO.PostDTO, Models.Post>().ReverseMap();
        }
    }

}
