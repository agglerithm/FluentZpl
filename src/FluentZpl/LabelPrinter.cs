using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using AFPST.Common.Services.Logging;

namespace AFPLabelPrint
{
    public interface ILabelPrinter
    {
//        string SiteID { get; }
//        string PrintID { get; }
//        string PrintPath { get; }
//        string IPAddr { get;  }
        void Print(string data, int copies, IPAddress address);  
//        void Refresh(Func<string, string, DataTable> getPrinterList, string siteID); 
        void Print(IList<string> data, IPAddress address);
    }

    /// <summary>
	/// Summary description for LabelPrinter.
	/// </summary>
	public class LabelPrinter : ILabelPrinter
    { 
        private readonly IPrinterConnection _conn; 

        public LabelPrinter(IPrinterConnection conn)
        {
            _conn = conn; 
        }
 
        public void Print(string data, int copies, IPAddress address)
		{ 
				for(int i = 0; i < copies; i++)
                    print_copy(data, i + 1, copies, address); 
		}

        public void Print(IList<string> data, IPAddress address)
        { 
            foreach(string datum in data)
                print_copy(datum, 1, 1, address);

        }

/*
        public void Print(string data, int copies, string ip)
        {
            _conn.Refresh(ip, Port);
            for (int i = 0; i < copies; i++)
                print_copy(_conn, data, i + 1, copies);
        }
*/

//        public void Print(string [] data, string IP)
//        {
//            var conn = new PrinterConnection(IP, 9100);
//            for (int i = 0; i < data.Length; i++)
//                print_copy(conn, data[i], 1, 1);
//
//        }

 //       private string IPAddr { get; set; }

        private void print_copy(
            string script, int ndx, int copies, IPAddress ipAddress)
        {
            script = set_number_of_copies(set_current_index(script, ndx), copies);
            var result = _conn.Print(script, ipAddress);
            if (result != "OK")
            {
                Logger.Warn(this,"Print failed, retrying one time.");
                Thread.Sleep(new TimeSpan(0,0,0,2));
                result = _conn.Print(script, ipAddress);
                if(result !="OK") throw new Exception(result);
            }
        }

        private static string set_current_index(string script, int ndx)
        {
            return script.Replace("@18", ndx.ToString());
        }

        private static string set_number_of_copies(string script, int copies)
        {
            return script.Replace("@19", copies.ToString());
        }

/*
		private void doc_PrintPage(object sender, PrintPageEventArgs ev) 
		{ 
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top; 
			var printFont = new Font("Arial Narrow", 10);
			printFont.GetHeight(ev.Graphics);
			ev.Graphics.DrawString (print_data, printFont, Brushes.Black,leftMargin,topMargin);
			doc = null;
		}
*/

/*
		private void PrintDocumentToFile(string text, int cnt)
		{
			System.IO.StreamWriter sw;
			for(int i = 0; i < cnt; i++)
			{
				sw = new System.IO.StreamWriter(PrintPath + i + ".txt");
				sw.Write(text);
				sw.Close();
			}
		}
*/

//		public void Refresh(Func<string, string, DataTable> getPrinterList, string siteID)
//		{
//		    //DataTable tbl = dutil.CommandReturns<DataTable>("exec <<automation>>.Automation.dbo.spGetPrinterList " + siteID + ", '" + PrintID + "'"); 
//		    DataTable tbl = getPrinterList(siteID, PrintID);
//			if(tbl == null || tbl.Rows.Count == 0) 
//                throw new Exception("Printer ID " + PrintID + " was not found on site " + siteID); 
//			PrintPath = tbl.Rows[0][1].ToString();
//			IPAddr = tbl.Rows[0][2].ToString();
// 
//		}


 

//        public string PrintPath
//	    {
//	        get; private set;  
//	    }
	}
}
