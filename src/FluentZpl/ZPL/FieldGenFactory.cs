namespace ZplLabels.ZPL
{
    public class FieldGenFactory
    {
        public static LabelTextGenerator GetText()
        {
            return new LabelTextGenerator();
        }

        public static LabelBarcodeGenerator GetBarcode()
        {
            return new LabelBarcodeGenerator();
        }

        public static GraphicBoxGenerator GetGraphic()
        {
            return new GraphicBoxGenerator();
        }
    }
}