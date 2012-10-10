using System;
using System.IO;
using System.Text;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class StringExtensions
    {
        public static string SafeTrim(this string str)
        {
            return str.IsNullOrEmpty() ? str : str.Trim();
        }

        public static string SafeReplace(this string str, string search_str, string replace_str)
        {
            return search_str == "" ? str : str.Replace(search_str, replace_str);
        }

        public static string Concatenate(this string str, string append, char delimiter)
        {
            if (append.IsNullOrEmpty())
                return str;
            if (str.IsNullOrEmpty())
            {
                str = append;
                return str;
            }
            str += delimiter + append;
            return str;
        }
        public static string EncloseInTag(this string str, string el_tag)
        {
            try
            {
                string closeTag = el_tag.ExtractClosingTag();
                el_tag = el_tag.Replace("/>", ">").Replace("/ >", ">");
                return el_tag + str + closeTag;
            }
            catch (Exception ex)
            {
                throw new Exception("ZplLabelsStringExtensions error: " + ex.Message);
            }
        }

        public static string FromBase64(this string encoded)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(encoded));
        }

        public static string ToBase64(this string val)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(val));
        }

        public static string TitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }

        public static byte[] ToByteArray(this string str)
        {
            if (string.IsNullOrEmpty(str)) return new byte[] {0};
            return new  ASCIIEncoding().GetBytes(str);
        }

        public static double CastToDouble(this string amt)
        {
            amt = initialize_numeric_string(amt);
            double d;
            double.TryParse(amt, out d);
            return d;
        }

        public static Guid CastToGuid(this string guidStr)
        {
            return new Guid(guidStr);
        }

        public static decimal CastToDecimal(this string amt)
        {
            amt = initialize_numeric_string(amt);
            decimal d;
            decimal.TryParse(amt, out d);
            return d;
        }

        public static int CastToInt(this string amt)
        {
            amt = initialize_numeric_string(amt);
            double d;
            double.TryParse(amt, out d);
            return (int)d;
        }

        public static DateTime CastToDateTime(this string dte)
        {
            DateTime dt;
            DateTime.TryParse(dte, out dt);
            return dt; 

        }

        public static bool CastToBool(this string condition)
        {
            bool b;
            bool.TryParse(condition, out b);
            return b; 
        }

        private static string initialize_numeric_string(string amt)
        {
            if (amt == null) return "0";
            amt = amt.Trim();
            if(amt == "")
                amt = "0";
            return amt;
        }
        public static string ExtractClosingTag(this string str)
        {
            if (str.IndexOf("<") != 0 || str.IndexOf(">") < 0)
                throw new Exception("Poorly formed XML tag.");
            string temp = str.Replace("<", "");
            temp = temp.Trim();
            string [] arr = temp.Split(" ".ToCharArray());
            return "</" + arr[0].Replace("/", "").Replace(">", "") + ">"; 
        }
         
       public static string CastToString(this byte[] buff)
       {
           return Utilities.BuffToString(buff);
       }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string SubIfNullOrEmpty(this string str, string sub)
        {
            return str.IsNullOrEmpty() ? sub : str;
        }

        public static bool IsNumeric(this string str)
        {
            decimal num;
            return decimal.TryParse(str, out num);
        }

        public static bool IsDateTime(this string str)
        {
            DateTime dte;
            return DateTime.TryParse(str, out dte);
        }

        public static int MacolaDateFromDate(this DateTime dte)
        {
            if (dte == DateTime.MinValue) return 0;
            return dte.EDIDateFromDate(true).CastToInt();
        }

        public static string EDIDateFromDate(this DateTime dte, bool century)
        {
            if (century)
                return dte.ToString("yyyyMMdd");
            return dte.ToString("yyMMdd");
        }

        public static string EDITimeFromDate(this DateTime tme)
        {
            return tme.ToString("HHmmss");
        }

        public static DateTime DateFromEDIDate(this string ediDate)
        {

            var num = validateEdiDate(ediDate);
            return num == 0 ? DateTime.MinValue : DateTime.Parse(parseIntToDate(num));
        }

        private static string parseIntToDate(int num)
        {
            var dateStr = num.ToString();
            if(dateStr.Length != 8) 
                throw new FormatException(string.Format("String {0} could not be converted to date!", num));
            return dateStr.Substring(0, 4) + "/" + dateStr.Substring(4, 2) + "/" + dateStr.Substring(6, 2);
        }

        private static int validateEdiDate(string ediDate)
        {
            int num;
            if (ediDate.IsNullOrEmpty()) ediDate = "0";
            if (!int.TryParse(ediDate, out num))
                throw new ApplicationException("Invalid date format: " + ediDate);
            if (centuryMissing(num))
                num = addCentury(num);
            return num;
        }

        private static int addCentury(int testVall)
        {
            if (testVall == 0) return 0;
            return testVall + 20000000;
        }

        private static bool centuryMissing(int testVall)
        {
            return testVall < 10000000;
        }
        public static void SaveToFile(this string contents, string filename)
        {
            var fs = new FileStream(filename, FileMode.Create);
            fs.Write(contents.ToByteArray(),0,contents.Length);
            fs.Close();
        }
        public static string Capitalize(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }

        public static string StripTrailingAlpha(this string str)
        {
            return Utilities.StripTrailingAlpha(str);
        }

        public static string StripQuotes(this string str)
        {
            return str.Replace("\"", "");
        }

        public static string TruncateTo(this string str, int num)
        {
            if (str.IsNullOrEmpty()) return "";
            return str.Length < num ? str : str.Substring(0, num);
        }

        public static string FormatString(this string str, params string [] parms)
        {
            return string.Format(str, parms);
        }

        public static bool CanCastToInt(this string str)
        {
            int num;
            return (int.TryParse(str, out num));
        }

        public static string TrimPartDescription(this string partNum)
        {
            var retVal = partNum;
            if (partNum.StartsWith("P/N "))
                retVal = partNum.Substring(4, partNum.Length - 4);
            if (partNum.ToUpper().StartsWith("XP/N "))
                retVal = partNum.Substring(5, partNum.Length - 5);
            int pos = retVal.IndexOf(" ");
            if (pos > 0)
                retVal = retVal.Substring(0, pos);
            return retVal;
        }

        public static string RemoveRevision(this string partNum)
        {
            var retVal = partNum; 
            int pos = retVal.IndexOf("-");
            if (pos > 0)
                retVal = retVal.Substring(0, pos);
            return retVal;
        }

        public static string RemoveRevisionLeaveDash(this string partNum)
        {
            var retVal = partNum;
            int pos = retVal.IndexOf("-");
            if (pos > 0)
                retVal = retVal.Substring(0, pos + 1);
            return retVal;
        }
    }
}