using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApiDemo.Controllers.Requests;
using WebApiDemo.Services.Dto;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("api/v1/auth/devices")]
[SwaggerTag("設備管理 API")]
[Authorize]
public class DeviceController(IDeviceService deviceService) : ControllerBase
{
    [SwaggerOperation("獲取設備列表")]
    [HttpGet]
    public List<DeviceDto> GetDevices()
    {
        return deviceService.GetDevices();
    }

    [SwaggerOperation("新增設備")]
    [HttpPost]
    public IActionResult CreateDevice([FromBody] List<CreateDeviceRequest> createDeviceRequestList)
    {
        return deviceService.CreateDevices(createDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }

    [SwaggerOperation("更新設備")]
    [HttpPut]
    public IActionResult UpdateDevices([FromBody] List<UpdateDeviceRequest> updateDeviceRequestList)
    {
        return deviceService.UpdateDevices(updateDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }
}