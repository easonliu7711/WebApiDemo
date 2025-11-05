using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApiDemo.Controllers.Requests;
using WebApiDemo.Services.Dto;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("api")]
public class DeviceController(IDeviceService deviceService) : ControllerBase
{
    [SwaggerOperation("獲取設備列表")]
    [HttpGet("v1/auth/devices")]
    public List<DeviceDto> GetDevices()
    {
        return deviceService.GetDevices();
    }

    [SwaggerOperation("新增設備")]
    [HttpPost("v1/auth/devices")]
    public IActionResult CreateDevice([FromBody] List<CreateDeviceRequest> createDeviceRequestList)
    {
        return deviceService.CreateDevices(createDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }

    [SwaggerOperation("更新設備")]
    [HttpPut("v1/auth/devices")]
    public IActionResult UpdateDevices([FromBody] List<UpdateDeviceRequest> updateDeviceRequestList)
    {
        return deviceService.UpdateDevices(updateDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }
}