using Newtonsoft.Json;
using WebApiDemo.Controllers.Requests;
using WebApiDemo.Data.Entities;

namespace WebApiDemo.Services.Dto;

public class DeviceDto
{
    public DeviceDto(CreateDeviceRequest createDeviceRequest)
    {
        Id = Guid.NewGuid().ToString();
        Name = createDeviceRequest.Name;
        Type = createDeviceRequest.Type;
        AccessToken = createDeviceRequest.AccessToken;
        Label = createDeviceRequest.Label;
    }

    public DeviceDto(DeviceEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Type = entity.Type;
        AccessToken = entity.AccessToken;
        Label = entity.Label;
        CreateTime = entity.CreateTime.ToLocalTime();
        UpdateTime = entity.UpdateTime.ToLocalTime();
    }

    public DeviceDto(UpdateDeviceRequest updateDeviceRequest)
    {
        Id = updateDeviceRequest.Id;
        Name = updateDeviceRequest.Name;
        Type = updateDeviceRequest.Type;
        AccessToken = updateDeviceRequest.AccessToken;
        Label = updateDeviceRequest.Label;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string AccessToken { get; set; }

    public string Label { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}