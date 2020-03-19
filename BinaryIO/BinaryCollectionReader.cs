using System;
using System.Collections.Generic;
using System.IO;

namespace BIO
{
	/// <summary>
	/// Represents a <see cref="BinaryReader"/> over a <see cref="IEnumerable{Byte}"/>
	/// </summary>
#if BIOLIB
	public
#endif
	partial class BinaryCollectionReader : BinaryReader
	{
		IEnumerator<byte> _input;
		/// <summary>
		/// Creates a new instance of the reader over the specified byte collection
		/// </summary>
		/// <param name="input">The collection of bytes to read</param>
		public BinaryCollectionReader(IEnumerable<byte> input)
		{
			_input = input.GetEnumerator();
		}
		/// <summary>
		/// Closes the reader and releases any resources held
		/// </summary>
		public override void Close()
		{
			_input.Dispose();
		}
		/// <summary>
		/// Reads the next character from the input collection
		/// </summary>
		/// <returns>The next byte read or a negative value if the cursor is not valid</returns>
		public override int Read()
		{
			if(_input.MoveNext())
			{
				++Position;
				return _input.Current;
			}
			return - 1;
		}
		/// <summary>
		/// Reads the specified number of bytes from the input collection
		/// </summary>
		/// <param name="buffer">The buffer to hold the result</param>
		/// <param name="startIndex">The start index into <paramref name="buffer"/> where copying begins</param>
		/// <param name="length">The maximum number of bytes to read</param>
		/// <returns>The number of bytes read</returns>
		public override int Read(byte[] buffer, int startIndex, int length)
		{
			if (null == buffer)
				throw new ArgumentNullException("buffer");
			if (0 > startIndex || buffer.Length <= startIndex)
				throw new ArgumentOutOfRangeException("startIndex");
			if (0 > length || buffer.Length < length)
				throw new ArgumentOutOfRangeException("length");
			if (buffer.Length < startIndex + length)
				throw new ArgumentOutOfRangeException();
			var result = 0;
			for(int ic=startIndex+length, i = startIndex;i<ic;++i)
			{
				if (!_input.MoveNext())
					break;
				buffer[i] = _input.Current;
				++Position;
				++result;
			}
			return result;
		}
	}
}
