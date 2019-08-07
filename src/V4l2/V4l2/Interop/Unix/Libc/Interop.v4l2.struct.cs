﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;

internal struct V4l2FrameBuffer
{
    public IntPtr Start;
    public uint Length;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_capability
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string driver;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string card;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string bus_info;
    public uint version;
    public uint capabilities;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] reserved;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_fmtdesc
{
    public uint index;
    public v4l2_buf_type type;
    public uint flags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string description;
    public uint pixelformat;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] reserved;
}

internal enum v4l2_buf_type : uint
{
    V4L2_BUF_TYPE_VIDEO_CAPTURE = 1,
    V4L2_BUF_TYPE_VIDEO_OUTPUT = 2,
    V4L2_BUF_TYPE_VIDEO_OVERLAY = 3,
    V4L2_BUF_TYPE_VBI_CAPTURE = 4,
    V4L2_BUF_TYPE_VBI_OUTPUT = 5,
    V4L2_BUF_TYPE_SLICED_VBI_CAPTURE = 6,
    V4L2_BUF_TYPE_SLICED_VBI_OUTPUT = 7,
    V4L2_BUF_TYPE_VIDEO_OUTPUT_OVERLAY = 8,
    V4L2_BUF_TYPE_VIDEO_CAPTURE_MPLANE = 9,
    V4L2_BUF_TYPE_VIDEO_OUTPUT_MPLANE = 10,
    V4L2_BUF_TYPE_SDR_CAPTURE = 11,
    V4L2_BUF_TYPE_SDR_OUTPUT = 12,
    V4L2_BUF_TYPE_META_CAPTURE = 13,
    V4L2_BUF_TYPE_META_OUTPUT = 14,
    V4L2_BUF_TYPE_PRIVATE = 0x80,
}

internal enum v4l2_field : uint
{
    V4L2_FIELD_ANY = 0,
    V4L2_FIELD_NONE = 1,
    V4L2_FIELD_TOP = 2,
    V4L2_FIELD_BOTTOM = 3,
    V4L2_FIELD_INTERLACED = 4,
    V4L2_FIELD_SEQ_TB = 5,
    V4L2_FIELD_SEQ_BT = 6,
    V4L2_FIELD_ALTERNATE = 7,
    V4L2_FIELD_INTERLACED_TB = 8,
    V4L2_FIELD_INTERLACED_BT = 9,
}

internal enum v4l2_colorspace : uint
{
    V4L2_COLORSPACE_DEFAULT = 0,
    V4L2_COLORSPACE_SMPTE170M = 1,
    V4L2_COLORSPACE_SMPTE240M = 2,
    V4L2_COLORSPACE_REC709 = 3,
    V4L2_COLORSPACE_BT878 = 4,
    V4L2_COLORSPACE_470_SYSTEM_M = 5,
    V4L2_COLORSPACE_470_SYSTEM_BG = 6,
    V4L2_COLORSPACE_JPEG = 7,
    V4L2_COLORSPACE_SRGB = 8,
    V4L2_COLORSPACE_ADOBERGB = 9,
    V4L2_COLORSPACE_BT2020 = 10,
    V4L2_COLORSPACE_RAW = 11,
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_pix_format
{
    public uint width;
    public uint height;
    public uint pixelformat;
    public v4l2_field field;
    public uint bytesperline;
    public uint sizeimage;
    public v4l2_colorspace colorspace;
    public uint priv;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_rect
{
    public int left;
    public int top;
    public uint width;
    public uint height;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct v4l2_clip
{
    public v4l2_rect c;
    public v4l2_clip* next;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct v4l2_window
{
    public v4l2_rect w;
    public v4l2_field field;
    public uint chromakey;
    public v4l2_clip* clips;
    public uint clipcount;
    public void* bitmap;
    public byte global_alpha;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_vbi_format
{
    public uint sampling_rate;
    public uint offset;
    public uint samples_per_line;
    public uint sample_format;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] start;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] count;
    public uint flags;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] reserved;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_sliced_vbi_format
{
    public uint service_set;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    public ushort[] service_lines;
    public uint io_size;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] reserved;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_sdr_format
{
    public uint pixelformat;
    public uint buffersize;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
    public byte[] reserved;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_meta_format
{
    public uint dataformat;
    public uint buffersize;
}

[StructLayout(LayoutKind.Sequential)]
internal struct fmt
{
    public v4l2_pix_format pix;
    public v4l2_window win;
    public v4l2_vbi_format vbi;
    public v4l2_sliced_vbi_format sliced;
    public v4l2_sdr_format sdr;
    public v4l2_meta_format meta;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
    public byte[] raw;
}

[StructLayout(LayoutKind.Sequential, Size = 204)]
internal struct v4l2_format
{
    public v4l2_buf_type type;
    public fmt fmt;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_fract
{
    public uint numerator;
    public uint denominator;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_cropcap
{
    public v4l2_buf_type type;
    public v4l2_rect bounds;
    public v4l2_rect defrect;
    public v4l2_fract pixelaspect;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_crop
{
    public v4l2_buf_type type;
    public v4l2_rect c;
}

internal enum v4l2_memory : uint
{
    V4L2_MEMORY_MMAP = 1,
    V4L2_MEMORY_USERPTR = 2,
    V4L2_MEMORY_OVERLAY = 3,
    V4L2_MEMORY_DMABUF = 4,
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_requestbuffers
{
    public uint count;
    public v4l2_buf_type type;
    public v4l2_memory memory;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] reserved;
}

[StructLayout(LayoutKind.Sequential)]
public struct v4l2_timeval
{
    public uint tv_sec;
    public uint tv_usec;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_timecode
{
    public uint type;
    public uint flags;
    public byte frames;
    public byte seconds;
    public byte minutes;
    public byte hours;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] userbits;
}

[StructLayout(LayoutKind.Sequential)]
internal struct v4l2_buffer
{
    public uint index;
    public v4l2_buf_type type;
    public uint bytesused;
    public uint flags;
    public v4l2_field field;

    [StructLayout(LayoutKind.Sequential)]
    public struct timeval
    {
        public uint tv_sec;
        public uint tv_usec;
    }
    public timeval timestamp;

    public v4l2_timecode timecode;
    public uint sequence;
    public v4l2_memory memory;

    [StructLayout(LayoutKind.Explicit)]
    public struct m_union
    {
        [FieldOffset(0)]
        public uint offset;
        [FieldOffset(0)]
        public uint userptr;
    }
    public m_union m;

    public uint length;
    public uint input;
    public uint reserved;
}