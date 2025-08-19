using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> Posts = new List<string>
            {
                "Post 1",
                "Post 2",
                "Post 3"
            };
            string Json = JsonSerializer.Serialize(Posts);
            Console.WriteLine(Json);
            return Posts;
        }
        [HttpGet("{id}")]
        public String Get(int id)
        {
            List<string> Posts = new List<string>
            {
                "Post 1",
                "Post 2",
                "Post 3"
            };


            List<Profile> profiles = new List<Profile>();
            int length = id;
            for (int i = 0; i < length; i++)
            {
                Profile profile = new Profile
                {
                    Name = "John Doe " + i,
                    Avatar = "https://example.com/avatar" + i + ".jpg",
                    CreateDate = DateTime.Now.AddDays(-i)
                };
                profiles.Add(profile);
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            string response = JsonSerializer.Serialize(profiles, options);
            //System.Diagnostics.Debug.WriteLine(profiles);
            Console.WriteLine(response);

            return response;
        }

        [HttpPost]
        public string Post([FromBody] string value)
        {
            // Here you would typically save the post to a database
            Console.WriteLine($"Post created: {value}");
            return "Ok";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            // Here you would typically update the post in the database
            Console.WriteLine($"Post with ID {id} updated to: {value}");
            return "Ok";
        }
    }
}
