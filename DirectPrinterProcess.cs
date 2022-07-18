namespace CloudPrinter
{
    //class to make format
    public class DirectPrinterProcess
    {
        public string SelectMethod(int MethodID)
        {
            switch (MethodID)
            {
                case 0:
                    return JustificationCenter();
                case 1:
                    return JustificationLeft();
                case 2:
                    return DoubleHeight();
                case 3:
                    return DoubleWidth();
                case 4:
                    return CancelDoubleHeightWidth();
                default:
                    return CancelDoubleHeightWidth();
            }
        }


        // all formats
        private string JustificationCenter()
        {
            return "" + (char)27 + (char)97 + (char)1;
        }

        private string JustificationLeft()
        {
            return "" + (char)27 + (char)97 + (char)0;
        }

        private string DoubleHeight()
        {
            return "" + (char)27 + (char)33 + (char)16;
        }

        private string DoubleWidth()
        {
            return "" + (char)27 + (char)33 + (char)32;
        }

        public string CancelDoubleHeightWidth()
        {
            return "" + (char)27 + (char)33 + (char)0;
        }

        public string NewLine()
        {
            return "" + "\n";
        }

    }
}
