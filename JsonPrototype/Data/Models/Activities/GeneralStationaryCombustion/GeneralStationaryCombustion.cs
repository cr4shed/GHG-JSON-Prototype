using Microsoft.Identity.Client;

namespace JsonPrototype.Data
{
    public class GeneralStationaryCombustion : BaseActivity
    {
        public override string ActivityName { get; } = "GeneralStationaryCombustion";

        public List<FuelGroup> UsefulEnergyFuelGroups { get; set; } = new();
        public List<FuelGroup> NoUsefulEnergyFuelGroups { get; set; } = new();
    }
}
