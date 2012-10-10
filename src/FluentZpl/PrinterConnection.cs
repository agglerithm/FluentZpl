using System;
using System.Net;
using System.Net.Sockets;
using ZplLabels.Common.Extensions;

namespace ZplLabels
{
    using Common;

    public interface IPrinterConnection
    {
        string Print(string scriptStr, IPAddress ipAddress);
    }

    /// <summary>
    /// Summary description for PrinterConnectionConnection.
	/// </summary>
	public class PrinterConnection : IPrinterConnection
    {
        private const int Port = 9100;  //for ZEBRA PRINTERs

        private const int TimeOut = 30; 
 

 
        public string Print(string scriptStr, IPAddress ipAddress)
		{  

			try
			{
			    byte[] buff = scriptStr.ToByteArray();

                using (var tcp = new TcpClient(ipAddress.ToString(), Port) { ReceiveTimeout = TimeOut })
                using (var stream = tcp.GetStream())
                {
                    stream.Write(buff, 0, buff.Length);
			    }
                
		        return "OK";
			}
			catch (Exception e)
			{
                Logger.Error(this,"Error Printing Label",e);
				string msg = e.Message;
				return msg;
			}
		}

    }
}

