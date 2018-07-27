using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class Preferences
    {
        private static string filename = Global.GetText("settingsFilename");

        //Read settings, default values if error is encountered
        public static void Read()
        {
            if (!ReadSettings())
                DefaulSettings();
        }

        /// <summary>
        /// Write the selected settings to the settings file
        /// </summary>
        public static void Write()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string settings = path + filename;

            try
            {
                if (File.Exists(settings))
                    File.SetAttributes(settings, File.GetAttributes(settings) & ~FileAttributes.Hidden);

                using (StreamWriter writer = new StreamWriter(settings))
                {
                    writer.WriteLine(Global.version);
                    writer.WriteLine(Global.line1Color.Name);
                    writer.WriteLine(Global.line2Color.Name);
                    writer.WriteLine(Global.line3Color.Name);

                    File.SetAttributes(settings, File.GetAttributes(settings) | FileAttributes.Hidden);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Global.GetText("writeToFileError") + "\n\n" + e.Message, Global.GetText("error"));
            }
        }

        /// <summary>
        /// Read settings (false if error is encountered)
        /// </summary>
        /// <returns>False if error is encountered</returns>
        private static bool ReadSettings()
        {
            //Find settings file
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string settings = path + filename;

            if (File.Exists(settings))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(settings))
                    {
                        string version = reader.ReadLine();

                        if (version != Global.version)
                            return false;

                        Global.line1Color = Color.FromName(reader.ReadLine());
                        Global.line2Color = Color.FromName(reader.ReadLine());
                        Global.line3Color = Color.FromName(reader.ReadLine());

                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Default the settings
        /// </summary>
        private static void DefaulSettings()
        {
            Global.line1Color = Color.Black;
            Global.line2Color = Color.Gray;
            Global.line3Color = Color.Black;
        }
    }
}