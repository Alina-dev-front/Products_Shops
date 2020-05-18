using System;
using System.Collections.Generic;
using System.Text;

namespace Products_Shops
{
    public static class Dumper
    {
        public static void Dump<T>(this T v, string s)
        {
            Console.WriteLine(s + " : " + v);
        }

        public static void Dump<T>(this T v)
        {
            Console.WriteLine(v);
        }
    }
}
