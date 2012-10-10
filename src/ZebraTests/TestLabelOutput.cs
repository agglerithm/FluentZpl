using System;
using System.Net;
using NUnit.Framework;

namespace ZebraTests
{
    using ZplLabels;
    using ZplLabels.ZPL;

    [TestFixture]
    public class TestLabelOutput
    {
        private ZplLabel _label;
        [TestFixtureSetUp]
        public void SetUpForAllTests()
        {

        }
        [SetUp]
        public void SetUpForEachTest()
        {
            _label = new ZplLabel();
        }

        [Test]
        public void can_get_label_script()
        {
            var str = _label.Load(FieldGenFactory.GetText().At(1, 150).SetFont("D", FieldOrientation.Normal, 84).WithData("PO Number").Centered(1200).Underline(),
                FieldGenFactory.GetBarcode().At(1, 250).SetBarcodeType(BarcodeType.Code128).SetFont("D", FieldOrientation.Normal, 48).WithData("22343").Height(150).BarWidth(4).Centered(1200),
                FieldGenFactory.GetText().At(1, 500).SetFont("D", FieldOrientation.Normal, 56).WithData("PO Line Number").Centered(1200),
                FieldGenFactory.GetBarcode().At(1, 550).SetBarcodeType(BarcodeType.Code128).SetFont("D", FieldOrientation.Normal, 40).WithData("1").Height(70).BarWidth(2).Centered(1200),
                FieldGenFactory.GetText().At(1, 740).SetFont("D", FieldOrientation.Normal, 56).WithData("Stryker Part Number").Centered(1200),
                FieldGenFactory.GetBarcode().At(1, 820).SetBarcodeType(BarcodeType.Code128).SetFont("D", FieldOrientation.Normal, 72).WithData("0682001252").Height(80).BarWidth(3).Centered(1200),
                FieldGenFactory.GetText().At(1, 1050).SetFont("D", FieldOrientation.Normal, 72).WithData("Serial/Lot Number").Centered(1200).Underline(),
                FieldGenFactory.GetBarcode().At(1, 1120).SetBarcodeType(BarcodeType.Code128).SetFont("D", FieldOrientation.Normal, 48).WithData("10000000006898").BarWidth(4).Height(110).Centered(1200),
                FieldGenFactory.GetText().At(1, 1320).SetFont("D", FieldOrientation.Inverted, 64).WithData("QTY").Centered(1200),
                FieldGenFactory.GetBarcode().At(1, 1400).SetBarcodeType(BarcodeType.Code128).SetFont("D", FieldOrientation.Inverted, 72).WithData("10").BarWidth(4).Height(150).Centered(1200)
                ).At(1, 50).ToString();
            Console.Write(str); 
            var addr = new byte[] { 1, 0, 0, 127 };
            var conn = new PrinterConnection();
            conn.Print(str,  new IPAddress(addr));
        }

        [TearDown]
        public void TearDownForEachTest()
        {

        }

        [TestFixtureTearDown]
        public void TearDownAfterAllTests()
        {

        }
    }
}
