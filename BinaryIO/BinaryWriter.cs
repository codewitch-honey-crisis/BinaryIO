using System;
using System.Collections.Generic;
using System.Text;

namespace BIO
{
	/// <summary>
	/// Represents a writer for writing binary data to an output stream
	/// </summary>
#if BIOLIB
	public
#endif
	abstract partial class BinaryWriter : IDisposable
	{
		/// <summary>
		/// Writes a byte to the output stream
		/// </summary>
		/// <param name="data">The byte to write</param>
		public abstract void Write(byte data);
		/// <summary>
		/// Writes a series of bytes to the output stream
		/// </summary>
		/// <param name="buffer">The buffer that contains the source data</param>
		/// <param name="startIndex">The start index into the buffer at which writing begins</param>
		/// <param name="length">The length of the data to write</param>
		public virtual void Write(byte[] buffer, int startIndex, int length)
		{
			if (null == buffer)
				throw new ArgumentNullException("buffer");
			if (0 > startIndex || buffer.Length <= startIndex)
				throw new ArgumentOutOfRangeException("startIndex");
			if (0 > length || buffer.Length < length)
				throw new ArgumentOutOfRangeException("length");
			if (buffer.Length < (startIndex + length))
				throw new ArgumentOutOfRangeException();
			for (int ic = startIndex + length, i = startIndex; i < ic; ++i)
				Write(buffer[i]);
		}
		/// <summary>
		/// Closes the writer and releases any resources held
		/// </summary>
		public abstract void Close();
		void IDisposable.Dispose()
		{
			Close();
		}
		/// <summary>
		/// Writes a byte to the output stream
		/// </summary>
		/// <param name="value">The value to write</param>
		/// <remarks>This method is equivelent to Write but is provided for completeness and symmetry with BinaryReader</remarks>
		public void WriteByte(byte value) 
			=>Write(value);
		/// <summary>
		/// Writes a signed byte to the output stream
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteSbyte(sbyte value)
		{
			Write(unchecked((byte)value));
		}
		/// <summary>
		/// Writes a series of bytes to the output stream
		/// </summary>
		/// <param name="values">The values to write</param>
		public void WriteBytes(byte[] values)
			=>Write(values, 0, values.Length);
		
		/// <summary>
		/// Writes a signed 16-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt16(short value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a signed 16-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt16BE(short value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian?ByteOrderUtility.Swap(value):value));
		}
		/// <summary>
		/// Writes a signed 16-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt16LE(short value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}

		/// <summary>
		/// Writes a unsigned 16-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt16(ushort value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a unsigned 16-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt16BE(ushort value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a unsigned 16-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt16LE(ushort value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}

		/// <summary>
		/// Writes a signed 32-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt32(int value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a signed 32-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt32BE(int value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a signed 32-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt32LE(int value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}

		/// <summary>
		/// Writes a unsigned 32-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt32(uint value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a unsigned 32-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt32BE(uint value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a unsigned 32-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt32LE(uint value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}

		/// <summary>
		/// Writes a signed 64-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt64(long value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a signed 64-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt64BE(long value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a signed 64-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteInt64LE(long value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}

		/// <summary>
		/// Writes a unsigned 64-bit integer to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt64(ulong value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a unsigned 64-bit integer to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt64BE(ulong value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a unsigned 64-bit integer to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteUInt64LE(ulong value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a 32-bit floating point value to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteSingle(float value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a 32-bit floating point value to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteSingleBE(float value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a 32-bit floating point value to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteSingleLE(float value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a 64-bit floating point value to the output stream in platform byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteDouble(double value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}
		/// <summary>
		/// Writes a 64-bit floating point value to the output stream in big-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteDoubleBE(double value)
		{
			WriteBytes(BitConverter.GetBytes(BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a 64-bit floating point value to the output stream in little-endian byte order
		/// </summary>
		/// <param name="value">The value to write</param>
		public void WriteDoubleLE(double value)
		{
			WriteBytes(BitConverter.GetBytes(!BitConverter.IsLittleEndian ? ByteOrderUtility.Swap(value) : value));
		}
		/// <summary>
		/// Writes a string to the output
		/// </summary>
		/// <param name="text">The text to write</param>
		/// <param name="encoding">The encoding to use or null for UTF-8</param>
		/// <remarks>Typically the string length must be prepended or otherwise known for this to be able to be read back</remarks>
		public void WriteString(string text,Encoding encoding = null)
		{
			if (null == encoding)
				encoding = Encoding.UTF8;
			WriteBytes(encoding.GetBytes(text));
		}
	}
}
