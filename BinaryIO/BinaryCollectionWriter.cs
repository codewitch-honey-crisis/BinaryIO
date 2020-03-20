using System;
using System.Collections.Generic;

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
	}
}
