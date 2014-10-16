FluentZpl
=========

A fluent interface to build labels using ZPL

FluentZpl consists of an assembly called ZplLabels that allows creation and printing of Zebra labels through a fluent interface. The ZplLabel class enables creation of label scripts through its Load() method, and either PrinterConnection or LabelPrinter can be used to send the resulting script to a Zebra printer.

The ZplLabel.Load() method takes an array of IFieldGenerator objects as parameters.  The field generators are created through static methods of the ZplFactory class. 

Creating a text field:

ZplFactory.TextField().At(1, 500).SetFont(Fonts.D, FieldOrientation.Normal, 56).WithData("PO Line Number").Centered(1200)

Creating a barcode field:

 ZplFactory.BarcodeField().At(1, 550).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Normal, 40).WithData("1").Height(70).BarWidth(2).Centered(1200) 

To create a complete label:

var label  = _label.Load(ZplFactory.TextField().At(1, 150).SetFont(Fonts.D, FieldOrientation.Normal, 84).WithData("PO Number").Centered(1200).Underline(),
                ZplFactory.BarcodeField().At(1, 250).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Normal, 48).WithData("22343").Height(150).BarWidth(4).Centered(1200),
                ZplFactory.TextField().At(1, 500).SetFont(Fonts.D, FieldOrientation.Normal, 56).WithData("PO Line Number").Centered(1200),
                ZplFactory.BarcodeField().At(1, 550).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Normal, 40).WithData("1").Height(70).BarWidth(2).Centered(1200),
                ZplFactory.TextField().At(1, 740).SetFont(Fonts.D, FieldOrientation.Normal, 56).WithData("SCustomer Part Number").Centered(1200),
                ZplFactory.BarcodeField().At(1, 820).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Normal, 72).WithData("0682001252").Height(80).BarWidth(3).Centered(1200),
                ZplFactory.TextField().At(1, 1050).SetFont(Fonts.D, FieldOrientation.Normal, 72).WithData("Serial/Lot Number").Centered(1200).Underline(),
                ZplFactory.BarcodeField().At(1, 1120).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Normal, 48).WithData("10000000006898").BarWidth(4).Height(110).Centered(1200),
                ZplFactory.TextField().At(1, 1320).SetFont(Fonts.B, FieldOrientation.Inverted, 64).WithData("QTY").Centered(1200),
                ZplFactory.BarcodeField().At(1, 1400).SetBarcodeType(BarcodeType.Code128).SetFont(Fonts.D, FieldOrientation.Inverted, 72).WithData("10").BarWidth(4).Height(150).Centered(1200)
                ).At(1, 50)
                
The "ToString()" method produces the following script:
^XA
^LH1,50
^FO1,150^ADN,84^FB1200,1,0,C
^FDPO Number^FS
^FO1,153^FD______^FS^FO401,250^BCN,150,N,N,N,N
^BY4
^FD22343^FS
^FO1,448^FB1200,1,0,C
^ADN,48^FD22343^FS
^FO1,500^ADN,56^FB1200,1,0,C
^FDPO Line Number^FS
^FO544,550^BCN,70,N,N,N,N
^BY2
^FD1^FS
^FO1,660^FB1200,1,0,C
^ADN,40^FD1^FS
^FO1,740^ADN,56^FB1200,1,0,C
^FDSCustomer Part Number^FS
^FO368,820^BCN,80,N,N,N,N
^BY3
^FD0682001252^FS
^FO1,972^FB1200,1,0,C
^ADN,72^FD0682001252^FS
^FO1,1050^ADN,72^FB1200,1,0,C
^FDSerial/Lot Number^FS
^FO1,1053^FD______________^FS^FO203,1120^BCN,110,N,N,N,N
^BY4
^FD10000000006898^FS
^FO1,1278^FB1200,1,0,C
^ADN,48^FD10000000006898^FS
^FO1,1320^ABI,64^FB1200,1,0,C
^FDQTY^FS
^FO467,1400^BCN,150,N,N,N,N
^BY4
^FD10^FS
^FO1,1622^FB1200,1,0,C
^ADI,72^FD10^FS
^XZ
