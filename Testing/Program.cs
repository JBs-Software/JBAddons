using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JBAddons.Ini;
using JBAddons.Speech;
using System.Windows.Forms;

namespace Testing1
{
    class Program
    {
        static void Main(string[] args)
        {
            JBAddons.JBXml xml1 = new JBAddons.JBXml("C:/Users/wayne/source/repos/JBAddons/Testing/bin/Debug/test.xml");
            Console.WriteLine(xml1.ReadNode("IsGay"));
            Console.WriteLine(xml1.ReadNode("Times"));
            Console.WriteLine(xml1.ReadNodeInt("Times") + 4);
        }
    }
}
