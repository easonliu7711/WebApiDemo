using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Services.Dtos;

namespace WebApiDemo.Services;

public interface IDeviceService
{
    List<DeviceDto> GetDevices();
    IActionResult CreateDevices(List<DeviceDto> dtoList);
}