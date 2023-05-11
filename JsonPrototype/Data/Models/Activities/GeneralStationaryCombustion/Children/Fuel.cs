namespace JsonPrototype.Data
{
    public class Fuel : NestedActivity
    {
        public override string ActivityName { get; } = "Fuel";
        public override Guid ParentActivityId { get; set; }

        public string FuelType { get; set; }
        public decimal FuelAmount { get; set; }

        public string HhvMeasuredOrDefault { get; set; }
        public decimal WeightedAverageHighHeatingValue { get; set; }
        public decimal WeightedAverageCarbonContent { get; set; }
        public decimal SteamGeneration { get; set; }
        public decimal TotalHeatInput { get; set; }

        public string Co2MeasuredOrDefault { get; set; }
        public decimal Co2EmissionFactor { get; set; }
        public string Co2EmissionFactorUnit { get; set; }
        public string Co2Methodology { get; set; }
        public decimal Co2Emissions { get; set; }
        public decimal Co2EmissionsCo2e { get; set; }

        public string Ch4MeasuredOrDefault { get; set; }
        public decimal Ch4EmissionFactor { get; set; }
        public string Ch4EmissionFactorUnit { get; set; }
        public string Ch4Methodology { get; set; }
        public decimal Ch4Emissions { get; set; }
        public decimal Ch4EmissionsCo2e { get; set; }

        public string N2oMeasuredOrDefault { get; set; }
        public decimal N2oEmissionFactor { get; set; }
        public string N2oEmissionFactorUnit { get; set; }
        public string N2oMethodology { get; set; }
        public decimal N2oEmissions { get; set; }
        public decimal N2oEmissionsCo2e { get; set; }

        public string AlternativeMethodologyDescription { get; set; }
    }
}
