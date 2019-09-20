# V4L2.NET
V4L2 (Video for Linux version 2) implemented by .NET Core. The required minimum version of .NET Core is 2.1. Theoretically support all Linux devices running .NET Core (.NET Core JIT depends on ARMv7 instructions).

[dotnet/iot#664](https://github.com/dotnet/iot/pull/664)

## Install Dependencies
1. Install `v4l-utils`.
    ```
    sudo apt-get install v4l-utils
    ```
2. Install `System.Drawing` native dependencies.
    ```
    sudo apt-get install libc6-dev libgdiplus libx11-dev
    ```

## Getting Started
1. Create a `VideoConnectionSettings` and set the parameters for capture.
    ```C#
    VideoConnectionSettings settings = new VideoConnectionSettings(busId: 0)
    {
        CaptureSize = (2560, 1920),
        PixelFormat = PixelFormat.JPEG,
        ExposureType = ExposureType.Auto
    };
    ```
2. Create a communications channel to a video device.
    ```C#
    using VideoDevice device = VideoDevice.Create(settings);
    ```
3. Capture static image
    ```C#
    // Capture static image
    device.Capture("/home/pi/jpg_direct_output.jpg");

    // Change capture setting
    device.Settings.PixelFormat = PixelFormat.YUV420;

    // Get image stream, convert pixel format and save to file
    MemoryStream ms = device.Capture();
    Color[] colors = VideoDevice.Yv12ToRgb(ms, settings.CaptureSize);
    Bitmap bitmap = VideoDevice.RgbToBitmap(settings.CaptureSize, colors);
    bitmap.Save("/home/pi/yuyv_to_jpg.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    ```
4. Other methods
    ```C#
    // Get the supported formats of the device
    IEnumerable<PixelFormat> formats = device.GetSupportedPixelFormats();
    // Get the resolutions of the format
    IEnumerable<(uint Width, uint Height)> resolutions = device.GetPixelFormatResolutions(PixelFormat.YUYV));
    // Query v4l2 controls default and current value
    VideoDeviceValue value = device.GetVideoDeviceValue(VideoDeviceValueType.Rotate);
    ```

## Run the sample
```
cd V4l2.Samples
dotnet publish -c release -r linux-arm -o YOUR_FOLDER
sudo dotnet YOUR_FOLDER/V4l2.Samples.dll
```

## Run the sample with Docker
Before build docker image, you need to modify SDK, runtime and apt sources(in China) to adapt to the corresponding Linux platform.

```
docker build -t v4l2-sample -f Dockerfile .
docker run --rm -it --device /dev/video0 -v /home/pi/images:/home/pi/images v4l2-sample
```
