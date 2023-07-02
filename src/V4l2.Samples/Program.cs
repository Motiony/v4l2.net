using System;
using System.Threading.Tasks;
using Iot.Device.Media;

namespace V4l2.Samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using VideoDevice device = VideoDevice.Create(new VideoConnectionSettings(0));
            device.SetVideoSettings(VideoDeviceValueType.ExposureType, (int)ExposureType.Auto);
            VideoDeviceValue value = device.GetVideoDeviceValue(VideoDeviceValueType.ExposureType);
            Console.WriteLine($"{value.Name} Min: {value.Minimum} Max: {value.Maximum} Step: {value.Step} Default: {value.DefaultValue} Current: {value.CurrentValue}");
            await Task.Delay(3000);
            device.SetVideoSettings(VideoDeviceValueType.ExposureType, (int)ExposureType.Manual);
            value = device.GetVideoDeviceValue(VideoDeviceValueType.ExposureType);
            Console.WriteLine($"{value.Name} Min: {value.Minimum} Max: {value.Maximum} Step: {value.Step} Default: {value.DefaultValue} Current: {value.CurrentValue}");
        }
    }
}
