using System.IO;
namespace BIO
{
	/// <summary>
	/// Represents a <see cref="BinaryReader"/> over a <see cref="Stream"/>
	/// </summary>
#if BIOLIB
	public
#endif
	partial class BinaryStreamReader : BinaryReader
	{
		Stream _input;
		/// <summary>
		/// Creates a new instance with the specified input stream
		/// </summary>
		/// <param name="input"></param>
		public BinaryStreamReader(Stream input)
		{
			_input = input;
		}
		/// <summary>
		/// Creates a new instance with the specified input file
		/// </summary>
		/// <param name="filename">The filename to read</param>
		public BinaryStreamReader(string filename)
		{
			_input = File.OpenRead(filename);
		}
		/// <summary>
		/// Closes the reader, releasing any resources held
		/// </summary>
		public override void Close()
		{
			_input.Close();
		}
		/// <summary>
		/// Reads a byte from the input stream
		/// </summary>
		/// <returns>The byte, or a negative value if the cursor is invalid</returns>
		public override int Read()
		{
			var result = _input.ReadByte();
			if (0 > result)
				return result;
			++Position;
			return result;
		}
		/// <summary>
		/// Reads the specified number of bytes from the input stream
		/// </summary>
		/// <param name="buffer">The buffer to hold the data</param>
		/// <param name="startIndex">The starting index within <paramref name="buffer"/> where copying begins</param>
		/// <param name="length">The maximum amount of data to read</param>
		/// <returns>The number of bytes read</returns>
		public override int Read(byte[] buffer, int startIndex, int length)
		{
			var result = _input.Read(buffer, startIndex, length);
			Position += result;
			return result;
		}
	}
}
