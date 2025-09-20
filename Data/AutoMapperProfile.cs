namespace SocialMediaPlatformBackend.Data
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DTO.PostDTO, Models.Post>().ReverseMap();
            CreateMap<DTO.ProfileDTO, Models.Profile>().ReverseMap();
        }
    }
}
