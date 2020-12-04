using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBAddons.Ini;
using JBAddons.Speech;
using System.Windows.Forms;

namespace Testing1
{
    class Program
    {
        static void Main(string[] args)
        {
            JBSpeak.SpeakFromFile("test.txt");
        }
    }
}
