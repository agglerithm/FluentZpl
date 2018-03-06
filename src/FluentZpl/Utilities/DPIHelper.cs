using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZplLabels.Utilities
{
    /// <summary>
    /// Converts Pixel to mm and mm to Pixel
    /// Requires DPI-Value from Printer
    /// </summary>
    public class DPIHelper
    {

        public DPIHelper(int dpi)
        {
            this.dpi = dpi;
        }

        public int dpi { get; set; }
        public double dpmm { get { return dpi / 25.4; } }


        /// <summary>
        /// converts distance from milimeter to Pixel
        /// </summary>
        /// <param name="mm">Distance in mm</param>
        /// <returns>Pixels</returns>
        public int mmToPx(int mm)
        {
            return (int)Math.Round(mm * dpmm);
        }

        /// <summary>
        /// converts distance from milimeter to Pixel
        /// </summary>
        /// <param name="mm">Distance in mm</param>
        /// <returns>Pixels</returns>
        public int mmToPx(double mm)
        {
            return (int)Math.Round(mm * dpmm);
        }

        /// <summary>
        /// converts Pixel to milimeters
        /// </summary>
        /// <param name="px">Pixel</param>
        /// <returns>Distance in mm</returns>
        public double pxTomm(int px)
        {
            return px / dpmm;
        }

        /// <summary>
        /// converts dots to dotrows 
        /// some zpl commands require dotrows as parameter
        /// </summary>
        /// <param name="dots"></param>
        /// <returns></returns>
        public int dotsToDotRows(int dots)
        {
            return (int)Math.Round(dots / 2.0);
        }
    }
}