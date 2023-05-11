using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JsonPrototype.Data
{
    public abstract class BaseActivity
    {
        public Guid ActivityId { get; set; } = Guid.NewGuid();
        public int ReportId { get; set; } 
        abstract public string ActivityName { get; }
        public DateTime CreatedOnDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedOnDate { get; set; } = null;
    }
}
