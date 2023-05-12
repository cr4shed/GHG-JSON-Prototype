using JsonPrototype.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonPrototype.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class FuelController : ControllerBase
	{
		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<Fuel> Get()
		{
			using var dbContext = DbContextFactory.CreateInstance();
			var Reports = dbContext.Reports.ToList();



			List<Fuel> fuel = new List<Fuel>();



			foreach (var report in Reports)
			{
				foreach (var activity in report.Activities)
				{
					if (activity.Value.GetType() == typeof(GeneralStationaryCombustion))
					{
						GeneralStationaryCombustion parsedActivity = (GeneralStationaryCombustion)activity.Value;
						parsedActivity.NoUsefulEnergyFuelGroups.ForEach(a => { fuel.AddRange(a.Fuels); });
						parsedActivity.UsefulEnergyFuelGroups.ForEach(a => { fuel.AddRange(a.Fuels); });
					}
				}
			}



			return fuel;
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
