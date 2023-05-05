using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JsonPrototype.Data
{
    public abstract class BaseActivity
    {
        abstract public string ActivityName { get; }
        public DateTime CreatedOnDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedOnDate { get; set; } = null;
    }
}
