using JsonPrototype.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonPrototype.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class FuelGroupController : ControllerBase
	{
		// GET: api/<FuelGroupController>
		[HttpGet]
		public IEnumerable<FuelGroup> Get()
		{
			using var dbContext = DbContextFactory.CreateInstance();
			var Reports = dbContext.Reports.ToList();

			List<FuelGroup> fuelgroup = new List<FuelGroup>();

			foreach (var report in Reports)
			{
				foreach (var activity in report.Activities)
				{
					if (activity.Value.GetType() == typeof(GeneralStationaryCombustion))
					{
						GeneralStationaryCombustion parsedActivity = (GeneralStationaryCombustion)activity.Value;
		
						foreach (var a in parsedActivity.NoUsefulEnergyFuelGroups)
						{
							a.Fuels = null;
							fuelgroup.Add(a);
						}

						foreach (var a in parsedActivity.UsefulEnergyFuelGroups)
						{
							a.Fuels = null;
							fuelgroup.Add(a);
						}
					}
				}
				
			}
			return fuelgroup;
		}

		// GET api/<FuelGroupController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<FuelGroupController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<FuelGroupController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<FuelGroupController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
