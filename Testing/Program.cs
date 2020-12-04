using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBAddons.Ini;
using System.Windows.Forms;

namespace Testing1
{
    class Program
    {
        static void Main(string[] args)
        {
            JBIniFile ini = new JBIniFile("test.ini");

            Keys key = ini.ReadKey("Key", "Keys");

            Console.WriteLine("Key is " + key.ToString());
        }
    }
}
