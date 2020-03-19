using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BIO
{
	/// <summary>
	/// Represents a reader for binary streams
	/// </summary>
#if BIOLIB
	public
#endif
	abstract partial class BinaryReader : IDisposable
	{
		/// <summary>
		/// Indicates the position of the cursor
		/// </summary>
		public long Position { get; protected set; }
		/// <summary>
		/// Reads a single byte from the stream, advancing the cursor
		/// </summary>
		/// <returns>The next byte or negative if the cursor is invalud</returns>
		public abstract int Read();
		/// <summary>
		/// Reads a series of bytes from the stream, advancing the cursor
		/// </summary>
		/// <param name="buffer">The buffer to fill</param>
		/// <param name="startIndex">The starting index within the buffer to fill</param>
		/// <param name="length">The length of the data to read</param>
		/// <returns>The number of bytes read</returns>
		public abstract int Read(byte[] buffer, int startIndex, int length);
		/// <summary>
		/// Closes the reader, releasing any resources held
		/// </summary>
		public abstract void Close();
		void IDisposable.Dispose()
		{
			Close();
		}
		/// <summary>
		/// Indicates whether or not the platform uses a little-endian byte ordering scheme.
		/// </summary>
		public static bool IsLittleEndian { get { return BitConverter.IsLittleEndian; } }
		/// <summary>
		/// Reads a byte from the stream
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public byte ReadByte()
		{
			var i = Read();
			if (0 > i)
				throw new IOException("Unexpected end of stream");
			return unchecked((byte)i);
		}
		/// <summary>
		/// Reads the specified number of bytes from a stream
		/// </summary>
		/// <param name="count">The count of bytes to read</param>
		/// <returns>A byte array containing the bytes</returns>
		/// <remarks>This throws if the data isn't completely available</remarks>
		public byte[] ReadBytes(int count)
		{
			var result = new byte[count];
			if(0<count)
			{
				if (Read(result, 0, count) != count)
					throw new IOException("Unexpected end of stream");
			}
			return result;
		}
		/// <summary>
		/// Reads a signed byte from the stream
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public sbyte ReadSByte()
		{
			var i = Read();
			if (0 > i)
				throw new IOException("Unexpected end of stream");
			return unchecked((sbyte)i);
		}
		/// <summary>
		/// Reads an Int16 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public short ReadInt16()
		{
			var ba = new byte[2];
			if(2!=Read(ba,0,2))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToInt16(ba, 0);
		}
		/// <summary>
		/// Reads an Int16 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public short ReadInt16BE()
		{
			return BitConverter.IsLittleEndian?ByteOrderUtility.Swap(ReadInt16()): ReadInt16();
		}
		/// <summary>
		/// Reads an Int16 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public short ReadInt16LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadInt16()) : ReadInt16();
		}
		/// <summary>
		/// Reads a UInt16 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ushort ReadUInt16()
		{
			var ba = new byte[2];
			if (2 != Read(ba, 0, 2))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToUInt16(ba, 0);
		}
		/// <summary>
		/// Reads a UInt16 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ushort ReadUInt16BE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt16()) : ReadUInt16();
		}
		/// <summary>
		/// Reads a UInt16 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ushort ReadUInt16LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt16()) : ReadUInt16();
		}

		/// <summary>
		/// Reads an Int32 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public int ReadInt32()
		{
			var ba = new byte[4];
			if (4 != Read(ba, 0, 4))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToInt32(ba, 0);
		}
		/// <summary>
		/// Reads an Int32 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public int ReadInt32BE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadInt32()) : ReadInt32();
		}
		/// <summary>
		/// Reads an Int32 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public int ReadInt32LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadInt32()) : ReadInt32();
		}
		/// <summary>
		/// Reads a UInt32 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public uint ReadUInt32()
		{
			var ba = new byte[4];
			if (4 != Read(ba, 0, 4))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToUInt32(ba, 0);
		}
		/// <summary>
		/// Reads a UInt32 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public uint ReadUInt32BE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt32()) : ReadUInt32();
		}
		/// <summary>
		/// Reads a UInt32 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public uint ReadUInt32LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt32()) : ReadUInt32();
		}
		/// <summary>
		/// Reads an Int64 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public long ReadInt64()
		{
			var ba = new byte[8];
			if (8 != Read(ba, 0, 8))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToInt64(ba, 0);
		}
		/// <summary>
		/// Reads an Int64 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public long ReadInt64BE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadInt64()) : ReadInt64();
		}
		/// <summary>
		/// Reads an Int64 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public long ReadInt64LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadInt64()) : ReadInt64();
		}
		/// <summary>
		/// Reads a UInt64 value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ulong ReadUInt64()
		{
			var ba = new byte[8];
			if (8 != Read(ba, 0, 8))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToUInt64(ba, 0);
		}
		/// <summary>
		/// Reads a UInt64 value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ulong ReadUInt64BE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt64()) : ReadUInt64();
		}
		/// <summary>
		/// Reads a UInt64 value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public ulong ReadUInt64LE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadUInt64()) : ReadUInt64();
		}
		/// <summary>
		/// Reads a float value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public float ReadSingle()
		{
			var ba = new byte[4];
			if (4 != Read(ba, 0, 4))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToSingle(ba, 0);
		}
		/// <summary>
		/// Reads a float value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public float ReadSingleBE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadSingle()) : ReadSingle();
		}
		/// <summary>
		/// Reads a float value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public float ReadSingleLE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadSingle()) : ReadSingle();
		}

		/// <summary>
		/// Reads a double value from the stream in platform byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public double ReadDouble()
		{
			var ba = new byte[8];
			if (8 != Read(ba, 0, 8))
				throw new IOException("Unexpected end of stream");
			return BitConverter.ToDouble(ba, 0);
		}
		/// <summary>
		/// Reads a double value from the stream in big endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public double ReadDoubleBE()
		{
			return BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadDouble()) : ReadDouble();
		}
		/// <summary>
		/// Reads a double value from the stream in little endian byte order
		/// </summary>
		/// <returns>The value read</returns>
		/// <remarks>This throws if the data isn't available</remarks>
		public double ReadDoubleLE()
		{
			return !BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(ReadDouble()) : ReadDouble();
		}
		/// <summary>
		/// Reads a fixed length string from the input
		/// </summary>
		/// <param name="byteLength">The length of the string, in bytes</param>
		/// <param name="encoding">The encoding, or default UTF8</param>
		/// <returns>The string that was read</returns>
		public string ReadFixedString(int byteLength,Encoding encoding = null)
		{
			if (null == encoding)
				encoding = Encoding.UTF8;
			var ba = ReadBytes(byteLength);
			return encoding.GetString(ba);
		}

	}

}
