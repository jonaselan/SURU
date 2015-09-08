using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class Program
    {
        const string VERSION = "0.5-dev";
        public static string Version { get { return VERSION; } }
        public static string OnlineVersion { get; set; }
    }
}
