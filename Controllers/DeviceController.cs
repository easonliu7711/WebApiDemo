using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApiDemo.Controllers.Requests;
using WebApiDemo.Services;
using WebApiDemo.Services.Dto;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("api")]
public class DeviceController(IDeviceService service) : ControllerBase
{
    [SwaggerOperation("獲取設備列表")]
    [HttpGet("v1/auth/devices")]
    public List<DeviceDto> GetDevices()
    {
        return service.GetDevices();
    }

    [SwaggerOperation("新增設備")]
    [HttpPost("v1/auth/devices")]
    public IActionResult CreateDevice([FromBody] List<CreateDeviceRequest> createDeviceRequestList)
    {
        return service.CreateDevices(createDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }

    [SwaggerOperation("更新設備")]
    [HttpPut("v1/auth/devices")]
    public IActionResult UpdateDevices([FromBody] List<UpdateDeviceRequest> updateDeviceRequestList)
    {
        return service.UpdateDevices(updateDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }
}