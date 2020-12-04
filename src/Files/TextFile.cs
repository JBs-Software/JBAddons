using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JBAddons
{
    public class TextFile
    {
        /// <summary>
        /// Creates the speicfed file
        /// Returns true, if the does not exists and is created
        /// Returns false, if the exists
        /// </summary>
        /// <param name="file">The file you want to create</param>
        /// <returns>Bool</returns>
        public static bool CreateFile(string file)
        {
            if (File.Exists(file) != true)
            {
                File.Create(file);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Appends text to file
        /// Returns false if the file does not exist
        /// Return true if the file does exist and is written to
        /// </summary>
        /// <param name="file">The file you want text to go to</param>
        /// <param name="text">The text you want to append</param>
        /// <returns>Bool</returns>
        public static bool AppendToFile(string file, string text)
        {
            if(File.Exists(file)!=true)
            {
                return false;
            }
            else
            {
                File.AppendAllText(file, text);
                return true;
            }
        }
    }
}
