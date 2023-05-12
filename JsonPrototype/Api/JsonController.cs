using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonPrototype.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        // GET: api/<JsonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JsonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JsonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JsonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JsonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
