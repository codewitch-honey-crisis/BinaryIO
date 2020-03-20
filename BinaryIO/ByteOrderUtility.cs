using System;
using System.Runtime.InteropServices;

namespace BIO
{
	/// <summary>
	/// Provides low level byte ordering functionality
	/// </summary>
#if BIOLIB
	public
#endif
	static class ByteOrderUtility
	{
		/// <summary>
		/// Indicates whether or not the platform uses a little-endian byte ordering scheme
		/// </summary>
		public static bool IsLittleEndian => BitConverter.IsLittleEndian;
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The word</param>
		/// <returns>A word with swapped byte order</returns>
		public static ushort Swap(ushort x) { return (ushort)((ushort)((x & 0xff) << 8) | ((x >> 8) & 0xff)); }
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The dword</param>
		/// <returns>A dword with swapped byte order</returns>
		public static uint Swap(uint x) { return ((x & 0x000000ff) << 24) + ((x & 0x0000ff00) << 8) + ((x & 0x00ff0000) >> 8) + ((x & 0xff000000) >> 24); }
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The word</param>
		/// <returns>A word with swapped byte order</returns>
		public static short Swap(short x) => unchecked((short)Swap(unchecked((ushort)x)));
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The dword</param>
		/// <returns>A dword with swapped byte order</returns>
		public static int Swap(int x) => unchecked((int)Swap(unchecked((uint)x)));
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The qword</param>
		/// <returns>A qword with swapped byte order</returns>
		public static ulong Swap(ulong x)
		{
			return
		 ((0x00000000000000FF) & (x >> 56)
		 | (0x000000000000FF00) & (x >> 40)
		 | (0x0000000000FF0000) & (x >> 24)
		 | (0x00000000FF000000) & (x >> 8)
		 | (0x000000FF00000000) & (x << 8)
		 | (0x0000FF0000000000) & (x << 24)
		 | (0x00FF000000000000) & (x << 40)
		 | (0xFF00000000000000) & (x << 56));
		}
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The qword</param>
		/// <returns>A qword with swapped byte order</returns>
		public static long Swap(long x)
			=> unchecked((long)Swap(unchecked((ulong)x)));

		// the following code is adopted from anthony male's technique https://antonymale.co.uk/converting-endianness-in-csharp.html
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The float</param>
		/// <returns>A float with swapped byte order</returns>
		public static float Swap(float x)
		{
			_UInt32SingleMap map = new _UInt32SingleMap() { Single = x };
			map.UInt32 = Swap(map.UInt32);
			return map.Single;
		}
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The double</param>
		/// <returns>A double with swapped byte order</returns>
		public static double Swap(double x)
		{
			_UInt64DoubleMap map = new _UInt64DoubleMap() { Double = x };
			map.UInt64 = Swap(map.UInt64);
			return map.Double;
		}
		// TODO: the following is untested
		/// <summary>
		/// Swaps byte order
		/// </summary>
		/// <param name="x">The decimal</param>
		/// <returns>A decimal with swapped byte order</returns>
		public static decimal Swap(decimal x)
		{
			var map = new _UInt64UInt64DecimalMap() { Decimal = x };
			var tmp = Swap(map.UInt64);
			map.UInt64 = Swap(map.UInt642);
			map.UInt642 = tmp;
			return map.Decimal;
		}
		[StructLayout(LayoutKind.Explicit)]
		private struct _UInt32SingleMap
		{
			[FieldOffset(0)] public uint UInt32;
			[FieldOffset(0)] public float Single;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct _UInt64DoubleMap
		{
			[FieldOffset(0)] public ulong UInt64;
			[FieldOffset(0)] public double Double;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct _UInt64UInt64DecimalMap
		{
			[FieldOffset(0)] public ulong UInt64;
			[FieldOffset(8)] public ulong UInt642;
			[FieldOffset(0)] public decimal Decimal;
		}
	}
}
