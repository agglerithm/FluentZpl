namespace ZplLabels.Common
{
    using System;
    using System.IO;
    using Extensions;

    /// <summary>
    /// Summary description for Utilities.
    /// </summary>
    public class Utilities
    {

        public static byte[] GrowBuffer(byte[] buff, int size_to_grow_by)
        {

            var temp = new byte[buff.Length + size_to_grow_by]; 
            for (var i = 0; i < buff.Length; i++)
            {
                temp[i] = buff[i];
            }
            return temp;
        }

        public static byte[] AppendBuffer(byte[] source, byte[] dest, int len)
        {
            int destLength = dest.Length;
            var temp = GrowBuffer(dest, len); 
            for (var i = 0; i < len; i++)
            {
                temp[i + destLength] = source[i];
            }
            return temp;
        }

        public static string FromEncoded(string val)
        {
            return System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(val));
        }

        public static string ToEncoded(string val)
        {
            return   ToEncoded(System.Text.Encoding.ASCII.GetBytes(val)) ;
        }

        public static string ToEncoded(byte [] buff)
        {
            return Convert.ToBase64String(buff);
        }
        public static void DoDebugLog(string msg)
        {
            var sw = new StreamWriter(Environment.CurrentDirectory + "\\errlog.txt",true);
            sw.WriteLine (msg);
            sw.Close();
        }

        public static void CopyFileWithoutOverwrite(string source, string dest)
        {
            if (File.Exists(dest))
            {
                string fname = Path.GetFileNameWithoutExtension(dest);
                string ext = Path.GetExtension(dest);
                string pth = dest.Replace(Path.GetFileName(dest), "");
                dest = pth + fname + "x" + ext;
            }
            File.Copy(source, dest);
        }

        public static void AppendTextToFile(string path, string text)
        {
            //Creates a new text file with contents "text" at path "path"
            //  (Existing file is overwritten)
            var sw = new StreamWriter(path, true);
            sw.Write(text);
            sw.Close();
        }

        public static string QuickFileText(string path)
        {
            var sr = new StreamReader(path);
            var qTxt = sr.ReadToEnd();
            sr.Close();
            return qTxt;
        }

        public static void CopyFileWithOverwrite(string source, string dest)
        {
            if (File.Exists(dest))
                File.Delete(dest);
            File.Copy(source, dest);
        }

 

        public static byte[] TrimBuff(byte[] buff, int n)
        {
            var temp = new byte[n];
            for (var i = 0; i < n; i++)
                temp[i] = buff[i];
            return temp;
        }

        public static string BuffToString(byte[] buff)
        {
            return System.Text.Encoding.ASCII.GetString(buff);
        }

        public static byte [] StringToBuff(string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }

        public static void ClearDebugLog()
        {
            var sw = new StreamWriter(System.Environment.CurrentDirectory + "\\errlog.txt",false); 
            sw.Close();
        }

        public static void DoDebugLog(string path, string msg)
        {
            var sw = new StreamWriter(path, true);
            sw.WriteLine(msg);
            sw.Close();
        }

        public static void ClearDebugLog(string path)
        {
            var sw = new StreamWriter(path, false);
            sw.Close();
        }

        public static string SkipToken(string str ,string strToken )
        {
            int sz = strToken.Length;
            int pos = str.IndexOf(strToken);
            if(pos > 0 )
                str =  str.Substring(pos + sz,  str.Length -  (pos + sz)); 
            return str;
        }

        public static string SkipToken(string str ,string strToken, int reps)
        {
            for(int i = 0; i < reps; i++)
                str = SkipToken(str, strToken);
            return str;
        }

        public static string LeftBeforeToken(string str ,string strToken)
        {
            int sz = strToken.Length;
            if( str.IndexOf(strToken) > 0 )
                do
                {
                    str = str.Substring(0,  str.IndexOf(strToken) - 1);
                }
                while (str.IndexOf(strToken) > 0);  
            return str;
        }

        public static string SkipAll( string str ,  string strToken  ) 
        {
            do
            {
                str = SkipToken(str, strToken);
            }
            while (str.Substring(0,strToken.Length) == strToken && str != "");
            return str;
        }

        public static string GetApplicationFileName(bool withExtension)
        {
            string app = Environment.CommandLine.ToString().Replace("\"","");
            if(withExtension)
                return System.IO.Path.GetFileName(app);
            return System.IO.Path.GetFileNameWithoutExtension(app);
        }

        public static DateTime FromEDIDate(int edi_dte)
        {
            return new DateTime(edi_dte / 10000, edi_dte % 10000 / 100,
                                edi_dte % 100);
        }

        public static int ToEDIDate(DateTime dte)
        {
            return dte.Year * 10000 + dte.Month * 100 + dte.Day;
        }

        public static int IncrementEDIDate(int edi_dte, double delta)
        {
            DateTime dte = FromEDIDate(edi_dte);
            dte = dte.AddDays(delta);
            return ToEDIDate(dte);
        }


        public static string StripLeadingAlpha(string num)
        {
            string temp = "";
            for (int i = 0; i < num.Length; i++)
            {
                int testnum;
                if(Int32.TryParse(num[i].ToString(),out testnum))   
                    return num.SafeReplace(temp,""); 
                temp += num[i];
            }
            return num;
        }

        public static string StripTrailingAlpha(string num)
        {
            string temp = "";
            for (int i = 0; i < num.Length; i++)
            {
                int testnum;
                if (Int32.TryParse(num[i].ToString(), out testnum))
                    temp += num[i];
                else
                    return temp;
            }
            return temp;
        }

        public static string Truncate(string str, int len)
        {
            if (str == null) return "";
            if (str.Length <= len) return str;
            return str.Substring(0, len);
        }

        public static byte[] BinCat(byte[] original, byte[] append)
        {
            if (original == null) return append;
            byte [] temp = new byte[original.Length + append.Length];
            int i;
            int offset = original.Length;
            for (i = 0; i < offset; i++)
                temp[i] = original[i];
            for (i = 0; i < append.Length; i++)
                temp[offset + i] = append[i];
            return temp;
        }

        public static byte[] ToBinFromEncoded(string data)
        {
            return Convert.FromBase64String(data);
        }

        public static byte[] FromEncodedToByteArray(string base64_comp)
        {
            return Convert.FromBase64String(base64_comp);
        }


        public static string QuickStreamText(MemoryStream strm)
        {
            var buff = new byte[strm.Length];
            strm.Read(buff, 0, buff.Length);
            return BuffToString(buff);
        }

        public static MemoryStream StringToStream(string text)
        {
            byte[] buff = StringToBuff(text);
            return new MemoryStream(buff);
        }

        public static DateTime FromEDITime(int stamp)
        {
            return new DateTime(1900,1,1,stamp/10000,stamp %10000 /100,stamp % 100);
        }
    }
}