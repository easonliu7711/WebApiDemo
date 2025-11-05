using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Services.Dto;

namespace WebApiDemo.Services.Interfaces;

public interface IDeviceService
{
    List<DeviceDto> GetDevices();
    IActionResult CreateDevices(List<DeviceDto> dtoList);
    IActionResult UpdateDevices(List<DeviceDto> dtoList);
}