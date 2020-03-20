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
	}
}
