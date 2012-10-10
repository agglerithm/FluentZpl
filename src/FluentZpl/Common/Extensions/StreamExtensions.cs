using System.IO;
using ZplLabels.Common;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class StreamExtensions
    {
 
        public static void LoadBuffer(this Stream str, byte [] buffer)
        {
            str.Write(buffer,0,buffer.Length);
        }

        public static byte [] ToByteArray(this Stream mem)
        {
            initialize_stream(mem);
            const int len = 500;
            var buff = new byte[len + len];
            var output = new byte[0];
            int n;
            var offset = 0; 
            while((n = mem.Read(buff, 0, len)) != 0)
            {
                offset += n;
                output = Utilities.AppendBuffer(buff, output, n);
            }
            return Utilities.TrimBuff(output,offset);
        }

        private static void initialize_stream(Stream mem)
        {
            try
            {
                mem.Position = 0;
            }
            catch  
            {
                //Some implementations of Stream throw an error here. 
                // For these, the underlying stream will be initialized before this method is called. 
                // We need to bury the exception.
            }
        }

        //public static void CopyTo(this Stream input, Stream output)
        //{
        //    var bytes = new byte[4096];

        //    int n;

        //    initialize_stream(input);

        //    while ((n = input.Read(bytes, 0, bytes.Length)) != 0)
        //    {

        //        output.Write(bytes, 0, n);

        //    }
        //}
    }
}