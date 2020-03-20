using System;
using System.Text;
using BIO;
namespace BinaryIODemo
{
	class Program
	{
		static void Main(string[] args)
		{
			// open the MIDI file
			using(var br = new BinaryStreamReader(@"..\..\GORILLAZ_-_Feel_Good_Inc.mid"))
			{
				// check for the FourCC code at the beginning of the file
				if("MThd"!=br.ReadFixedString(4,Encoding.ASCII))
					throw new ApplicationException("The file is not a MIDI file");
				
				// read a big-endian 32-bit integer length from the the file
				var len = br.ReadInt32BE();
				// now read that many bytes into a buffer
				var ba = br.ReadBytes(len);
				// create a new binary reader over ba
				// not necessary, but for illustrative purposes:
				int trackCount;
				using (var br2 = new BinaryCollectionReader(ba))
				{
					// read the file type as a big-endian 16-bit short
					Console.WriteLine("MIDI File Type: " + br2.ReadInt16BE().ToString());
					// read the track count as a big-endian 16-bit short
					Console.WriteLine("MIDI Track Count: " + (trackCount=br2.ReadInt16BE()).ToString());
					// read the timebase as a big-endian 16-bit short
					Console.WriteLine("MIDI TimeBase: " + br2.ReadInt16BE().ToString());
				}
				var tracksRead = 0;
				while(tracksRead<trackCount)
				{
					var name = br.ReadFixedString(4, Encoding.ASCII);
					len = br.ReadInt32BE();
					var data = br.ReadBytes(len);
					if("MTrk"==name)
					{
						Console.WriteLine("Track #" + tracksRead.ToString() + " is " + len + " bytes.");
						++tracksRead;
					}
				}
			}	
		}
	}
}
