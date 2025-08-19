using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaPlatformBackend.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}/{name}")]
        public void Delete(int id, string name)
        {
            Console.WriteLine($"Deleted value with ID: {id}");
            Console.WriteLine($"and this is the additional parameter just to test: {name}");
        }
    }

    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("profile")]
        public Profile GetProfile()
        {
            return new Profile
            {
                Name = "John Doe",
                Avatar = "https://example.com/avatar.jpg",
                CreateDate = DateTime.Now
            };
        }
    }
}
