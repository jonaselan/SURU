using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public static class DBElementHandling
    {
        public static object RemoverEspacos(object o) {
            IList<PropertyInfo> props = new List<PropertyInfo>(o.GetType().GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(o, null);

                if (propValue is string) { Regex.Replace((string)propValue, @"\s+", ""); }
            }
            return o;
        }

        public static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
