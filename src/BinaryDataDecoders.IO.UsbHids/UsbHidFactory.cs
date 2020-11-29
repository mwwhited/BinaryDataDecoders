using HidSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BinaryDataDecoders.IO.UsbHids
{
    public class UsbHidFactory : IUsbHidFactory
    {
        public bool CanGetHidDevice(object? definition) => definition?.GetType()?.GetCustomAttributes<UsbHidAttribute>()?.Any() ?? false;

        public HidDevice? GetHidDevice(string devicePath, object? definition) => 
            GetHidDevices(definition).FirstOrDefault(d=>string.Equals(d.DevicePath, devicePath, StringComparison.OrdinalIgnoreCase));

        public HidDevice? GetHidDevice(object? definition) => GetHidDevices(definition).FirstOrDefault();

        public IEnumerable<HidDevice> GetHidDevices(object? definition)
        {
            if (definition == null) yield break;
            var def = definition.GetType();
            var config = def.GetCustomAttribute<UsbHidAttribute>();
            if (config == null) yield break;

            var devices = from device in DeviceList.Local.GetAllDevices().OfType<HidDevice>()
                          where device.VendorID == config.VendorId
                          where (device.ProductID & config.ProductMask) == (config.ProductId & config.ProductMask)
                          group device by device.DevicePath into hids
                          select hids.First();

            foreach (var device in devices)
                yield return device;
        }

        public IEnumerable<string> GetHidDevices() =>
            DeviceList.Local
                      .GetAllDevices()
                      .OfType<HidDevice>()
                      .Select(s => s.DevicePath)
                      .Distinct()
                      .OrderBy(s => s);
    }
}
