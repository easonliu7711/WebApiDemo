﻿using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Data.Entities;
using WebApiDemo.Services.Dtos;

namespace WebApiDemo.Services;

public class DeviceService(ApplicationDbContext context) : IDeviceService
{
    public List<DeviceDto> GetDevices()
    {
        return context.DeviceInfo.Select(entity => new DeviceDto(entity)).ToList();
    }

    public IActionResult CreateDevices(List<DeviceDto> dtoList)
    {
        var entities = dtoList.Select(dto => new DeviceEntity(dto)).ToList();
        context.DeviceInfo.AddRange(entities);
        context.SaveChanges();
        return new OkResult();
    }
}