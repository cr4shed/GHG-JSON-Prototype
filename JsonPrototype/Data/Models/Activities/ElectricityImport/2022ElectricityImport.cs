using System.Text.Json.Serialization;

namespace JsonPrototype.Data
{
    public class _2022ElectricityImport : BaseElectricityImport
    {
        // Import.
        public decimal SpecifiedImportedElectricity { get; set; }
        public decimal SpecifiedImportedElectricityEmissions { get; set; }

        public decimal UnspecifiedImportedElectricity { get; set; }
        public decimal UnspecifiedImportedElectricityEmissions { get; set; }


        // Export.
        public decimal SpecifiedExportedElectricity { get; set; }
        public decimal SpecifiedExportedElectricityEmissions { get; set; }

        public decimal UnspecifiedExportedElectricity { get; set; }
        public decimal UnspecifiedExportedElectricityEmissions { get; set; }


        // Canadian Entitlement Power.
        public decimal EntitlementPowerElectricity { get; set; }


        // Totals.
        public decimal TotalImportedElectricity
        {
            get { return SpecifiedImportedElectricity + UnspecifiedImportedElectricity; }
        }
        public decimal TotalImportedElectricityEmissions
        {
            get { return SpecifiedImportedElectricityEmissions + UnspecifiedImportedElectricityEmissions; }
        }

        public decimal TotalExportedElectricity
        {
            get { return SpecifiedExportedElectricity + UnspecifiedExportedElectricity; }
        }
        public decimal TotalExportedElectricityEmissions
        {
            get { return SpecifiedExportedElectricityEmissions + UnspecifiedExportedElectricityEmissions; }
        }
    }
}
