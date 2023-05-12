using System.Text.Json;
using JsonPrototype.Data.Models;
using JsonPrototype.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			using var dbContext = DbContextFactory.CreateInstance();
            var Reports = dbContext.Reports.ToList();
            //var report = Reports[0];
            var json = JsonSerializer.Serialize(Reports);
            yield return json;
            //return Reports;
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
