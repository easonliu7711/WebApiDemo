using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApiDemo.Services.Dto;

namespace WebApiDemo.Data.Entities;

[Table("device_info", Schema = "asp_demo")]
public class DeviceEntity : AuditableEntity
{
    public DeviceEntity()
    {
    }

    public DeviceEntity(DeviceDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Type = dto.Type;
        AccessToken = dto.AccessToken;
        Label = dto.Label;
    }

    [Column("id")]
    [StringLength(50)]
    [Required]
    public string Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Required]
    public string Name { get; set; }

    [Column("type")]
    [StringLength(50)]
    [Required]
    public string Type { get; set; }

    [Column("access_token")]
    [StringLength(100)]
    [Required]
    public string AccessToken { get; set; }

    [Column("label")]
    [StringLength(200)]
    [Required]
    public string Label { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}