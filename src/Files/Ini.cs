using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace JBAddons.Ini
{
    public class JBIniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        /// <summary>
        /// New class of IniFile
        /// </summary>
        /// <param name="IniPath">The path to your INI file. Please read Github wiki for more info</param>
        public JBIniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        /// <summary>
        /// Reads the value from a given key
        /// </summary>
        /// <param name="Key">Key you want the value from</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        /// <returns>String</returns>
        public string ReadString(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        /// <summary>
        /// Read a bool value from a given Key
        /// </summary>
        /// <param name="Key">Key you want the value from</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        /// <returns>Bool</returns>
        public bool ReadBool(string Key, string Section = null)
        {
            return bool.Parse(ReadString(Key, Section));
        }

        /// <summary>
        /// Read a int value from a given Key
        /// </summary>
        /// <param name="Key">Key you want the value from</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        /// <returns>int</returns>
        public int ReadInt(string Key, string Section = null)
        {
            return int.Parse(ReadString(Key, Section));
        }

        /// <summary>
        /// Read a double value from a given Key
        /// </summary>
        /// <param name="Key">Key you want the value from</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        /// <returns>int</returns>
        public double ReadDouble(string Key, string Section = null)
        {
            return double.Parse(ReadString(Key, Section));
        }

        public Keys ReadKey(string Key, string Section = null)
        {
            return (Keys)Enum.Parse(typeof(Keys), ReadString(Key, Section), true);
        }

        /// <summary>
        /// Writes the a value to the given Key
        /// </summary>
        /// <param name="Key">Key you want to write to or create</param>
        /// <param name="Value">The value of the Key</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        /// <summary>
        /// Deletes the given Key
        /// </summary>
        /// <param name="Key">Key you want the value from</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        /// <summary>
        /// Deletes the given section
        /// </summary>
        /// <param name="Section">The section to delete</param>
        public void DeleteSection(string Section)
        {
            Write(null, null, Section ?? EXE);
        }

        /// <summary>
        /// See if the given keys exsits
        /// </summary>
        /// <param name="Key">The Key that you want to see exsits</param>
        /// <param name="Section">The Section that the Key is in, defualt = null</param>
        /// <returns>Bool</returns>
        public bool KeyExists(string Key, string Section = null)
        {
            return ReadString(Key, Section).Length > 0;
        }
    }
}
