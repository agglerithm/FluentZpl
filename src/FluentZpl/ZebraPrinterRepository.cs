using System.Data;
using System.Net;

namespace ZplLabels
{
    using System;
    using System.Collections.Generic;

    public class ZebraPrinterRepository : IZebraPrinterRepository
    {
 

        public ZebraPrinter Map(DataRow dr)
        {
            return new ZebraPrinter
                       {
                           PrinterID = dr["PRINTERID"].ToString(),
                           Site = dr["SITE_ID"].ToString(),
                           IPAddress = IPAddress.Parse(dr["DEVICE_LINK"].ToString())
                       };
        }

        public IEnumerable<ZebraPrinter> GetPrintList(string siteID)
        {
            throw new NotImplementedException();
        }
    }
}