namespace ZplLabels.ZPL
{
    using Common;

    public class BarcodeType : EnumerationOfString<BarcodeType>
    {
        public static BarcodeType Code128 = new BarcodeType("^BC", "Code128");
        public static BarcodeType Code11 = new BarcodeType("^B1", "Code11");
        public static BarcodeType Interleaved2Of5 = new BarcodeType("^B2", "Interleaved2of5");
        public static BarcodeType Code39 = new BarcodeType("^B3", "Code39");
        public static BarcodeType Code49 = new BarcodeType("^B4", "Code49");
        public static BarcodeType PDF417 = new BarcodeType("^B7", "PDF417");
        public static BarcodeType EAN8 = new BarcodeType("^B8", "EAN8");
        public static BarcodeType UPCE = new BarcodeType("^B9", "UPCE");
        public static BarcodeType Code93 = new BarcodeType("^BA", "Code93");
        public static BarcodeType CodeABlock = new BarcodeType("^BB", "CodeABlock");
        public static BarcodeType UPSMaxiCode = new BarcodeType("^BD", "UPSMaxiCode");
        public static BarcodeType EAN13 = new BarcodeType("^BE", "EAN13");
        public static BarcodeType MicroPDF417 = new BarcodeType("^BF", "MicroPDF417");
        public static BarcodeType Industrial2of5 = new BarcodeType("^BI", "Industrial2of5");
        public static BarcodeType Standard2of5 = new BarcodeType("^BJ", "Standard2of5");
        public static BarcodeType ANSICodabar = new BarcodeType("^BK", "ANSICodabar");
        public static BarcodeType LOGMARS = new BarcodeType("^BL", "LOGMARS");
        public static BarcodeType MSI = new BarcodeType("^BM", "MSI");
        public static BarcodeType Plessey = new BarcodeType("^BP", "Plessey");
        public static BarcodeType QRCode = new BarcodeType("^BQ", "QRCode");
        public static BarcodeType UPCA = new BarcodeType("^BU", "UPCA");
        public static BarcodeType DataMatrix = new BarcodeType("^BX", "DataMatrix");




        private BarcodeType(string command, string displayName):base(command, displayName)
        { 
        }

        public BarcodeType()
        { 
        }
    }
}
