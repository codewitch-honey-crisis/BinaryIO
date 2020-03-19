using System.IO;

namespace BIO
{
	/// <summary>
	/// Represents a <see cref="BinaryWriter"/> over a <see cref="Stream"/>
	/// </summary>
#if BIOLIB
	public
#endif
	partial class BinaryStreamWriter : BinaryWriter
	{
		Stream _output;
		/// <summary>
		/// Creates a new instance of the writer over the specified stream
		/// </summary>
		/// <param name="output">The stream to write to</param>
		public BinaryStreamWriter(Stream output)
		{
			_output = output;
		}
		/// <summary>
		/// Creates a new instance of the writer over the specified file
		/// </summary>
		/// <param name="filename">The filename to write to</param>
		public BinaryStreamWriter(string filename)
		{
			_output = File.OpenWrite(filename);
		}
		/// <summary>
		/// Writes a byte to the output stream
		/// </summary>
		/// <param name="data">The byte to write</param>
		public override void Write(byte data)
		{
			_output.WriteByte(data);
		}
		/// <summary>
		/// Writes a series of bytes to the output stream
		/// </summary>
		/// <param name="buffer">The buffer that contains the source bytes</param>
		/// <param name="startIndex">The start index into the buffer at which writing begins</param>
		/// <param name="length">The length to bytes to write</param>
		public override void Write(byte[] buffer, int startIndex, int length)
		{
			_output.Write(buffer, startIndex, length);
		}
		/// <summary>
		/// Closes the writer and releases any resources used
		/// </summary>
		public override void Close()
		{
			_output.Close();
		}
	}
}
