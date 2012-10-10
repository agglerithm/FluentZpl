namespace ZplLabels.Common.Extensions
{
    using System;
    using System.Data; 

#pragma warning disable 1591
    public static class DataFieldExtensions
    {
        public static int CastToInt(this object obj)
        {
            return StringExtensions.CastToInt(obj.ToString());
        }

        public static Guid CastToGuid(this object obj)
        {
            return  StringExtensions.CastToGuid(obj.ToString());
        }

        public static decimal CastToDecimal(this object obj)
        {
            return StringExtensions.CastToDecimal(obj.ToString());
        }

        public static double CastToDouble(this object obj)
        {
            return StringExtensions.CastToDouble(obj.ToString());
        }

        public static bool CastToBool(this object obj)
        {
            decimal num;
            var value = obj.ToString();
            if(decimal.TryParse(value, out num))
            {
                return num != 0;
            }
            return StringExtensions.CastToBool(value);
        }

        public static DateTime CastToSqlDateTime(this object dte)
        {
            var val = dte.CastToDateTime();
            return val == DateTime.MinValue ? StringExtensions.CastToDateTime("1/1/1900") : val;
        }

        public static DateTime CastToDateTime(this object obj)
        {
            return StringExtensions.CastToDateTime(obj.ToString());
        }

        public static DateTime? CastToNullableDateTime(this object obj)
        {
            if (obj == null || obj == DBNull.Value) return null;
            var dateTime = StringExtensions.CastToDateTime(obj.ToString());
            return dateTime;
        }


        public static DataRow GetFirstRow(this DataSet ds)
        {
            var tbl = ds.GetFirstTable();
            return tbl.Rows.Count == 0 ? null : tbl.Rows[0];
        }
        public static DataTable GetFirstTable(this DataSet ds)
        {
            if (ds.Tables.Count == 0)
                throw new Exception("No tables in DataSet '" + ds.DataSetName + "'"); 
            return ds.Tables[0];
        }

        public static string StripQuotes(this object obj)
        {
            return obj.ToString().Replace("\"", "");
        }

        public static string StripTrailingAlpha(this object obj)
        {
            return StringExtensions.StripTrailingAlpha(obj.ToString());
        }
    }
}