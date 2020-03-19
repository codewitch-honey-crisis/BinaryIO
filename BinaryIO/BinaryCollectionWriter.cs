using System;
using System.Collections.Generic;
using System.Text;

namespace BIO
{
	/// <summary>
	/// Represents a binary writer over a collection of bytes
	/// </summary>
#if BIOLIB
	public
#endif
	partial class BinaryCollectionWriter : BinaryWriter
	{
		ICollection<byte> _output;
		/// <summary>
		/// Creates a new instance of the writer over the specified collection
		/// </summary>
		/// <param name="output">The collection to add to</param>
		public BinaryCollectionWriter(ICollection<byte> output)
		{
			_output = output;
		}
		/// <summary>
		/// Closes the writer and releases any resources held
		/// </summary>
		public override void Close()
		{
			// do nothing
		}
		/// <summary>
		/// Writes a byte to the output collection
		/// </summary>
		/// <param name="data">The value to write</param>
		public override void Write(byte data)
		{
			_output.Add(data);
		}
		/// <summary>
		/// Writes a series of bytes to the output collection
		/// </summary>
		/// <param name="buffer">The buffer containing the source bytes</param>
		/// <param name="startIndex">The start index into the buffer at which writing begins</param>
		/// <param name="length">The length of the bytes to write</param>
		public override void Write(byte[] buffer, int startIndex, int length)
		{
			if (null == buffer)
				throw new ArgumentNullException("buffer");
			if (0 > startIndex || buffer.Length <= startIndex)
				throw new ArgumentOutOfRangeException("startIndex");
			if(0>length || buffer.Length<length)
				throw new ArgumentOutOfRangeException("length");
			if (buffer.Length < (startIndex + length))
				throw new ArgumentOutOfRangeException();
			for (int ic = startIndex + length, i = startIndex; i < ic; ++i)
				Write(buffer[i]);
		}
	}
}
