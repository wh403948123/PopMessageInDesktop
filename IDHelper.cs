using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace popmsg
{
    public static class IDHelper
    {
        public const long BASE = 2;
        public const long MIN_YEAR = 2000;
        public const long MAX_YEAR = 2127;
        public const long MIN_RANDOM = 0;
        public const long MAX_RANDOM = 1048575;

        private const long UP_YEAR = 62;            // bits: 7    max: 127
        private const long DN_YEAR = 56;
        private const long UP_MONTH = 55;           // bits: 4    max: 15
        private const long DN_MONTH = 52;
        private const long UP_DAY = 51;             // bits: 5    max: 31
        private const long DN_DAY = 47;
        private const long UP_HOUR = 46;            // bits: 5    max: 31
        private const long DN_HOUR = 42;
        private const long UP_MINUTE = 41;          // bits: 6    max: 63
        private const long DN_MINUTE = 36;
        private const long UP_SECOND = 35;          // bits: 6    max: 63
        private const long DN_SECOND = 30;
        private const long UP_MILLI_SECOND = 29;    // bits: 10   max: 1023
        private const long DN_MILLI_SECOND = 20;
        private const long UP_RANDOM = 19;          // bits: 20   max: 1048575 FFFFF
        private const long DN_RANDOM = 0;

        private static long DN_YEAR_POW = (long)System.Math.Pow(BASE, DN_YEAR);
        private static long DN_MONTH_POW = (long)System.Math.Pow(BASE, DN_MONTH);
        private static long DN_DAY_POW = (long)System.Math.Pow(BASE, DN_DAY);
        private static long DN_HOUR_POW = (long)System.Math.Pow(BASE, DN_HOUR);
        private static long DN_MINUTE_POW = (long)System.Math.Pow(BASE, DN_MINUTE);
        private static long DN_SECOND_POW = (long)System.Math.Pow(BASE, DN_SECOND);
        private static long DN_MILLI_SECOND_POW = (long)System.Math.Pow(BASE, DN_MILLI_SECOND);
        private static long DN_RANDOM_POW = (long)System.Math.Pow(BASE, DN_RANDOM);

        public static long NewID(DateTime datetime, long random)
        {
            if (datetime.Year > MAX_YEAR)
            {
                throw new ExSys("Year({0}) can not be more than {1}!", datetime.Year, MAX_YEAR);
            }
            if (datetime.Year < MIN_YEAR)
            {
                throw new ExSys("Year({0}) can not be less than {1}!", datetime.Year, MIN_YEAR);
            }
            if (random > MAX_RANDOM)
            {
                throw new ExSys("Random({0}) can not be more than {1}!", random, MAX_RANDOM);
            }
            if (random < MIN_RANDOM)
            {
                throw new ExSys("Random({0}) can not be less than {1}!", random, MIN_RANDOM);
            }
            long id = 0;

            id += ((long)datetime.Year - MIN_YEAR) * DN_YEAR_POW;
            id += ((long)datetime.Month) * DN_MONTH_POW;
            id += ((long)datetime.Day) * DN_DAY_POW;
            id += ((long)datetime.Hour) * DN_HOUR_POW;
            id += ((long)datetime.Minute) * DN_MINUTE_POW;
            id += ((long)datetime.Second) * DN_SECOND_POW;
            id += ((long)datetime.Millisecond) * DN_MILLI_SECOND_POW;
            id += ((long)random - MIN_RANDOM) * DN_RANDOM_POW;

            return id;
        }
        public static long NewID(DateTime datetime)
        {
            long random = Convert.ToInt64(Guid.NewGuid().ToString().Substring(0, 5), 16);
            return NewID(datetime, random);
        }
        public static long NewID()
        {
            return NewID(DateTime.Now);
        }
        //public static DateTime GetDateTime(long id)
        //{
        //    if (id < MIN_ID || id > MAX_ID)
        //    {
        //        throw new ExSys("Invalid id! \"{0}\"", id);
        //    }
        //    long YEAR = id / DN_YEAR_POW + MIN_YEAR;
        //    long MONTH = (id % DN_YEAR_POW) / DN_MONTH_POW;
        //    long DAY = (id % DN_MONTH_POW) / DN_DAY_POW;
        //    long HOUR = (id % DN_DAY_POW) / DN_HOUR_POW;
        //    long MINUTE = (id % DN_HOUR_POW) / DN_MINUTE_POW;
        //    long SECOND = (id % DN_MINUTE_POW) / DN_SECOND_POW;
        //    long MILLI_SECOND = (id % DN_SECOND_POW) / DN_MILLI_SECOND_POW;

        //    return DateTime.Parse(string.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}.{6:000}"
        //        , YEAR, MONTH, DAY, HOUR, MINUTE, SECOND, MILLI_SECOND));
        //}
        public static DateTime GetDateTimeWithoutMilliseconds(long id)
        {
            if (id < MIN_ID || id > MAX_ID)
            {
                throw new ExSys("Invalid id! \"{0}\"", id);
            }
            long YEAR = id / DN_YEAR_POW + MIN_YEAR;
            long MONTH = (id % DN_YEAR_POW) / DN_MONTH_POW;
            long DAY = (id % DN_MONTH_POW) / DN_DAY_POW;
            long HOUR = (id % DN_DAY_POW) / DN_HOUR_POW;
            long MINUTE = (id % DN_HOUR_POW) / DN_MINUTE_POW;
            long SECOND = (id % DN_MINUTE_POW) / DN_SECOND_POW;

            return DateTime.Parse(string.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}"
                , YEAR, MONTH, DAY, HOUR, MINUTE, SECOND));
        }
        public static long GetRandom(long id)
        {
            return id % DN_MILLI_SECOND_POW + MIN_RANDOM;
        }
        public static long MIN_ID
        {
            get { return NewID(DateTime.Parse(MIN_YEAR.ToString() + "-01-01 00:00:00.000"), MIN_RANDOM); }
        }
        public static long MAX_ID
        {
            get { return NewID(DateTime.Parse(MAX_YEAR.ToString() + "-12-31 23:59:59.999"), MAX_RANDOM); }
        }

        public static string GetRegisterCodestring(DateTime dt)
        {
            while (true)
            {
                string tmp = NewID(dt).ToString();
                if (tmp.Length == 19)
                {
                    return tmp;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }
        public static string GetRegisterCodestring()
        {
            while (true)
            {
                string tmp = NewID().ToString();
                if (tmp.Length == 19)
                {
                    return tmp;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
        }



        public static string GetDatetime_Max(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd") + " 23:59:59.995";
        }
        public static string GetDatetime_Min(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd") + " 00:00:00.002";
        }
        public static string GetNow_Max()
        {
            return DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59.995";
        }
        public static string GetNow_Min()
        {
            return DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00.002";
        }

        public static DateTime dt_GetDatetime_Max(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }
        public static DateTime dt_GetDatetime_Min(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }
        public static DateTime dt_GetNow_Max()
        {
            DateTime dt = DateTime.Now;
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }
        public static DateTime dt_GetNow_Min()
        {
            DateTime dt = DateTime.Now;
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }
    }
}
