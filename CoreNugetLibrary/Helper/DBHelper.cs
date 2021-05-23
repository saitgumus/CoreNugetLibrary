using System;

namespace SG.Kernel.Helper
{
    public class DBHelper
    {


        #region getnullablevalues

        public static string GetStringValue(object value)
        {
            return value.ToString();
        }

        #nullable enable
        public static Int32 GetInt32NullableValue(object? value)
        {
            if (value == null)
            {
                return 0;
            }

            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public static byte[] GetByteArray(object? value)
        {
            if (value is byte[])
                return (byte[])value;
            else
                return new byte[] { };

        }

        public static DateTime GetDateTimeValue(object? value)
        {
            if(value == null)
            {
                return DateTime.MinValue;
            }
            if(value is DateTime)
            {
                DateTime val = (DateTime)value;
                return val;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static Decimal GetDecimalValue(object? value)
        {
            if (value == null || value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return (decimal)value;
            }
        }

        public static byte GetByteNullableValue(object? value)
        {
            if (value == null)
            {
                return 0;
            }

            try
            {
                return Convert.ToByte(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public static short GetShortValue(object? value)
        {
            if (value == DBNull.Value)
                return 0;
            else
                return Convert.ToInt16(value??0);
        }
        #endregion
    }
}