﻿using System.Runtime.CompilerServices;

namespace Pulse.Core
{
    public static class Endian
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short SwapInt16(short v)
        {
            return (short)(((v & 0xff) << 8) | ((v >> 8) & 0xff));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort SwapUInt16(ushort v)
        {
            return (ushort)(((v & 0xff) << 8) | ((v >> 8) & 0xff));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SwapInt32(int v)
        {
            return (int)(((SwapInt16((short)v) & 0xffff) << 0x10) | (SwapInt16((short)(v >> 0x10)) & 0xffff));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SwapUInt32(uint v)
        {
            return (uint)(((SwapUInt16((ushort)v) & 0xffff) << 0x10) | (SwapUInt16((ushort)(v >> 0x10)) & 0xffff));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long SwapInt64(long v)
        {
            return (long)(((SwapInt32((int)v) & 0xffffffffL) << 0x20) | (SwapInt32((int)(v >> 0x20)) & 0xffffffffL));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong SwapUInt64(ulong v)
        {
            return (ulong)(((SwapUInt32((uint)v) & 0xffffffffL) << 0x20) | (SwapUInt32((uint)(v >> 0x20)) & 0xffffffffL));
        }

        public static unsafe int ToLittleInt32(byte* b)
        {
            return *(b + 3) | *(b + 2) << 8 | *(b + 1) << 16 | *b << 24;
        }
    }
}