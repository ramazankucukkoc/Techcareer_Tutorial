using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Germany_Hour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeZoneInfo germanyTime = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime germanyTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, germanyTime);
            Console.WriteLine("Berlin Time :" + germanyTimeNow);
            Console.ReadKey();

        }
    }
}
