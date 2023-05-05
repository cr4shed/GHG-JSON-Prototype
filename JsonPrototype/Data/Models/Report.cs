using System.ComponentModel.DataAnnotations;

namespace JsonPrototype.Data.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public int FacilityId { get; set; }
        public int ReportYear { get; set; }
        public Dictionary<string, BaseActivity> Activities { get; set; } = new();
    }
}
