using JsonPrototype.Data;
using JsonPrototype.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonPrototype.Pages
{
    public partial class Index
    {
        public List<Report> Reports { get; set; }
        public bool AddSuccess { get; set; } = false;
        public bool DataLoaded { get; set; } = false;
        private Random rand = new Random();

        public async Task LoadData()
        {
            using var dbContext = DbContextFactory.CreateInstance();

            Reports = await dbContext.Reports.ToListAsync();

            DataLoaded = Reports.Count > 0;
            StateHasChanged();
        }

        public async Task AddData()
        {            
            // Setup.
            using var dbContext = DbContextFactory.CreateInstance();

            FuelGroup fuelGroupFoo = new FuelGroup
            {
                GscUnitName = "Fuel Group Foo",
                Description = "Foo",
                Fuels = new()
                {
                    GetExampleFuel("Anthracite Coal"),
                    GetExampleFuel("Coal Coke"),
                    GetExampleFuel("Coke Oven Gas"),
                    GetExampleFuel("Bituminous Coal"),
                    GetExampleFuel("Crude Oil")
                }
            };
            FuelGroup fuelGroupBar = new FuelGroup
            {
                GscUnitName = "Fuel Group Bar",
                Description = "Bar",
                Fuels = new()
                {
                    GetExampleFuel("Wood Waste"),
                    GetExampleFuel("Natural Gas"),
                    GetExampleFuel("Municipal Solid Waste"),
                    GetExampleFuel("Ethylene"),
                }
            };

            // Define 2021 activities.
            _2021ElectricityImport ei2021 = new()
            {
                SpecifiedSourcesEmissions = 121,
                UnspecifiedSourcesEmissions = 25
            };
            GeneralStationaryCombustion gsc2021 = new()
            {
                UsefulEnergyFuelGroups =
                {
                    fuelGroupFoo,
                    fuelGroupBar
                },
                NoUsefulEnergyFuelGroups =
                {
                    fuelGroupBar,
                    fuelGroupFoo
                }
            };

            // Define 2022 activities.
            _2022ElectricityImport ei2022 = new()
            {
                SpecifiedImportedElectricity = 100,
                SpecifiedImportedElectricityEmissions = 1,
                UnspecifiedImportedElectricity = 100,
                UnspecifiedImportedElectricityEmissions = 1,
                SpecifiedExportedElectricity = 100,
                SpecifiedExportedElectricityEmissions = 1,
                UnspecifiedExportedElectricity = 100,
                UnspecifiedExportedElectricityEmissions = 1,
                EntitlementPowerElectricity = 5
            };
            GeneralStationaryCombustion gsc2022 = new()
            {
                UsefulEnergyFuelGroups =
                {
                    fuelGroupFoo,
                    fuelGroupBar
                },
                NoUsefulEnergyFuelGroups =
                {
                    fuelGroupBar,
                    fuelGroupFoo
                }
            };

            // Create new reports.
            Report report2021 = new Report()
            {
                FacilityId = 123,
                ReportYear = 2021,
                Activities =
                {
                    { 
                        ei2021.ActivityName, 
                        ei2021
                    },
                    {
                        gsc2021.ActivityName,
                        gsc2021
                    }
                }
            };
            Report report2022 = new Report()
            {
                FacilityId = 123,
                ReportYear = 2022,
                Activities =
                {
                    {
                        ei2022.ActivityName,
                        ei2022
                    },
                    {
                        gsc2022.ActivityName,
                        gsc2022
                    }
                }
            };

            // Save reports.
            await dbContext.Reports.ExecuteDeleteAsync();
            dbContext.Reports.Add(report2021);
            dbContext.Reports.Add(report2022);
            var result = await dbContext.SaveChangesAsync();

            AddSuccess = result > 0;
            StateHasChanged();
        }

        private Fuel GetExampleFuel(string fuelType)
        {
            return new Fuel
            {
                FuelType = fuelType,
                FuelAmount = rand.Next(0, 999999),
                HhvMeasuredOrDefault = "Measured",
                WeightedAverageHighHeatingValue = rand.Next(0, 999999),
                WeightedAverageCarbonContent = rand.Next(0, 999999),
                SteamGeneration = rand.Next(0, 999999),
                TotalHeatInput = rand.Next(0, 999999),
                Co2MeasuredOrDefault = "Default",
                Co2EmissionFactor = rand.Next(0, 999999),
                Co2EmissionFactorUnit = "Lorem",
                Co2Methodology = "Default HHV/Default EF",
                Co2Emissions = rand.Next(0, 999999),
                Co2EmissionsCo2e = rand.Next(0, 999999),
                Ch4MeasuredOrDefault = "Measured",
                Ch4EmissionFactor = rand.Next(0, 999999),
                Ch4EmissionFactorUnit = "Ipsum",
                Ch4Methodology = "Measured HHV/Default EF",
                Ch4Emissions = rand.Next(0, 999999),
                Ch4EmissionsCo2e = rand.Next(0, 999999),
                N2oMeasuredOrDefault = "Default",
                N2oEmissionFactor = rand.Next(0, 999999),
                N2oEmissionFactorUnit = "Dolor",
                N2oMethodology = "Replacement Methodology",
                N2oEmissions = rand.Next(0, 999999),
                N2oEmissionsCo2e = rand.Next(0, 999999),
                AlternativeMethodologyDescription = "N2O Alternative Methodology"
            };
        }
    }
}
