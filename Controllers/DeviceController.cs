using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Controllers.Requests;
using WebApiDemo.Services;
using WebApiDemo.Services.Dtos;

namespace WebApiDemo.Controllers;

[ApiController]
[Route("api")]
public class DeviceController(IDeviceService service) : ControllerBase
{
    [HttpGet("v1/auth/devices")]
    public List<DeviceDto> GetDevices()
    {
        return service.GetDevices();
    }

    [HttpPost("v1/auth/devices")]
    public IActionResult CreateDevice([FromBody] List<CreateDeviceRequest> createDeviceRequestList)
    {
        return service.CreateDevices(createDeviceRequestList.Select(request => new DeviceDto(request)).ToList());
    }
}