using System;
using System.Collections.Generic;
using System.Linq;
using HashNuGet;

class Program
{
    static void Main()
    {
        string s = "salom0";
        HashSHA256 sHA256 = new();
       s= sHA256.GetHashedString(s);
        Console.WriteLine(s);
    }
}
