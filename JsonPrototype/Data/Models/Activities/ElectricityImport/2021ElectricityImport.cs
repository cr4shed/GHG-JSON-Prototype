using Newtonsoft.Json;

namespace JsonPrototype.Data
{
    public class _2021ElectricityImport : BaseElectricityImport
    {
        public decimal SpecifiedSourcesEmissions { get; set; }
        public decimal UnspecifiedSourcesEmissions { get; set; }

        public decimal TotalEmissions 
        { 
            get { return SpecifiedSourcesEmissions + UnspecifiedSourcesEmissions; }
        }
    }
}
