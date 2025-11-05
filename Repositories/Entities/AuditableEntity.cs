using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApiDemo.Repositories.Entities;

public abstract class AuditableEntity
{
    [Column("create_time")] [Required] public DateTime CreateTime { get; set; }

    [Column("update_time")] [Required] public DateTime UpdateTime { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}