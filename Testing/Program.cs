using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using JBAddons.Ini;
using JBAddons.Files;
using JBAddons.Speech;
using System.Windows.Forms;

namespace Testing1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFile.CreateFile("google.txt");
            Thread.Sleep(100);
            TextFile.AppendToFile("google.txt", "Hello World");
            Thread.Sleep(300);
            JBSpeak.SpeakFromFile("google.txt", Encoding.UTF8);
        }
    }
}
