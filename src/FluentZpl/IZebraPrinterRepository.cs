using System.Collections;
using System.Collections.Generic;

namespace ZplLabels
{
    public interface IZebraPrinterRepository
    {
        IEnumerable<ZebraPrinter> GetPrintList(string siteID);
//        IEnumerable<string> GetSites();
//        IEnumerable<string> GetPrintersFor(string site);
    }
}