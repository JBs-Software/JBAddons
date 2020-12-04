using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace JBAddons
{
    public class JBMain
    {
        #region Version Things
        private static int Major = Assembly.GetExecutingAssembly().GetName().Version.Major;
        private static int Minor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
        private static int Patch = Assembly.GetExecutingAssembly().GetName().Version.Build;
        #endregion

        public static string Version { get; } = Major.ToString() + "." + Minor.ToString() + "." + Patch.ToString();
        public static string Copyright { get; } = "Copyright (c) 2020 JB Stepan. Copyright (c) 2020 Contruibtors.md Licensed under the MIT License";
        public static bool EnableLogging { get; set; }

        /// <summary>
        /// Returns the current version of JBAddons
        /// </summary>
        /// <returns>String</returns>
        public static string GetVersion()
        {
            return Version;
        }
    }
}
