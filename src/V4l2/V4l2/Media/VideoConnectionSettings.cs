﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Device.Media
{
    /// <summary>
    /// The connection settings of a video device.
    /// </summary>
    public class VideoConnectionSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoConnectionSettings"/> class.
        /// </summary>
        /// <param name="busId">The bus ID the video device is connected to.</param>
        public VideoConnectionSettings(int busId)
        {
            BusId = busId;
        }

        /// <summary>
        /// The bus ID the video device is connected to.
        /// </summary>
        public int BusId { get; }

        /// <summary>
        /// The size of video device captured image.
        /// </summary>
        public (uint Width, uint Height) CaptureSize { get; set; } = (0, 0);

        /// <summary>
        /// The pixel format of video device captured image.
        /// </summary>
        public PixelFormat PixelFormat { get; set; } = PixelFormat.YUYV;

        /// <summary>
        /// The exposure type of video device.
        /// </summary>
        public ExposureType ExposureType { get; set; } = ExposureType.Auto;

        /// <summary>
        /// The exposure time of video device.
        /// </summary>
        /// <remarks>
        /// If ExposureType is set to Auto, the property is invalid.
        /// Time is a relative variable. Different devices can be set in different ranges.
        /// </remarks>
        public int ExposureTime { get; set; } = 0;
    }
}
