using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Data.Entities;

public abstract class AuditableEntity
{
    [Column("create_time")]
    [Required]
    public DateTime CreateTime { get; set; }
    
    [Column("update_time")]
    [Required]
    public DateTime UpdateTime { get; set; }
}