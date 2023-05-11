using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JsonPrototype.Data
{
    public abstract class NestedActivity : BaseActivity
    {
        public abstract Guid ParentActivityId { get; set; }
    }
}
