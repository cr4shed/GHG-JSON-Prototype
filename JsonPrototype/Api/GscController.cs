using JsonPrototype.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonPrototype.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class GscController : ControllerBase
	{
		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<GeneralStationaryCombustion> Get()
		{
			using var dbContext = DbContextFactory.CreateInstance();
			var Reports = dbContext.Reports.ToList();

			List<GeneralStationaryCombustion> gsc = new List<GeneralStationaryCombustion>();

			foreach (var report in Reports)
			{
				foreach (var activity in report.Activities)
				{
					if (activity.Value.GetType() == typeof(GeneralStationaryCombustion))
					{
						GeneralStationaryCombustion parsedActivity = (GeneralStationaryCombustion)activity.Value;
						gsc.Add(parsedActivity);
					}
				}

			}
			return gsc;
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
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
