using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Descuentos.Business
{
    public static class HelperService
    {
        static Dictionary<string, string> cache;
        private static Dictionary<string, string> Cache
        {
            set { cache = value; }
            get
            {
                if (cache == null)
                    cache = new Dictionary<string, string>();

                return cache;
            }
        }

        public static string GetAppSetting(string key)
        {
            string localKey = key + "AppSetting";

            if (Cache.Any(a => a.Key == localKey))
                return cache[localKey];

            string result = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(result))
                return string.Empty;

            Cache.Add(localKey, result);

            return result;
        }

        public static string GetConnectionString(string key)
        {
            string localKey = key + "ConnectionString";

            if (Cache.Any(a => a.Key == localKey))
                return cache[localKey];

            string result = ConfigurationManager.ConnectionStrings[key].ConnectionString; ;

            if (string.IsNullOrWhiteSpace(result))
                return string.Empty;

            Cache.Add(localKey, result);

            return result;
        }

        public static decimal AsDecimal(this string value)
        {
            decimal result = 0;
            if (decimal.TryParse(value, out result)) { }
            return result;
        }

        public static int AsInt(this string value)
        {
            int result = 0;
            if (int.TryParse(value, out result)) { }
            return result;
        }
    }
}
