using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CalendarDesigner
{
    public static class File
    {
        public enum Extentions { CDF, PNG, JPG }

        private const string cdf = ".cdf";
        private const string png = ".png";
        private const string jpg = ".jpg";

        private const string cdfFilter = "Calendar Design Format (*" + cdf + ")|*" + cdf;
        private const string pngFilter = "PNG (*" + png + ")|*" + png;
        private const string jpgFilter = "JPG (*" + jpg + ")|*" + jpg;

        private const string saveFilter = cdfFilter + "|" + pngFilter + "|" + jpgFilter;
        private const string openFilter = cdfFilter;

        private const int saveFilterCDF = 1;
        private const int saveFilterPNG = 2;
        private const int saveFilterJPG = 3;

        private const int openFilterCDF = 1;

        /// <summary>
        /// Saves the current calendar with a SaveFileDialog prompt to the user.
        /// <para>Returns the success of the opperation.</para>
        /// </summary>
        public static bool SaveAs(Extentions ext = Extentions.CDF)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                DefaultExt = cdf,
                Filter = saveFilter,
                FileName = Global.Calendar.MonthName,
                AddExtension = true,
                RestoreDirectory = true
            };

            // Sets extention that shows at initial prompt
            switch (ext)
            {
                case Extentions.CDF:
                    save.FilterIndex = saveFilterCDF;
                    break;
                case Extentions.PNG:
                    save.FilterIndex = saveFilterPNG;
                    break;
                case Extentions.JPG:
                    save.FilterIndex = saveFilterJPG;
                    break;
                default:
                    return false;
            }

            if (save.ShowDialog() != DialogResult.OK)
                return false;

            string filename = save.FileName;
            switch (Path.GetExtension(filename))
            {
                case cdf:
                    Global.Path = filename;
                    return Save();

                case png:
                case jpg:
                    return Export.GenerateImage(filename);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Saves the current calendar.
        /// <para>Returns the success of the opperation.</para>
        /// </summary>
        public static bool Save()
        {
            if (Global.Path == null)
                return SaveAs();

            bool success = WriteFile(Global.Calendar, Global.Path);

            if (success)
                Global.Saved = true;

            return success;
        }

        /// <summary>
        /// Prompts the user with an OpenFileDialog.
        /// <para>Returns the success of the opperation.</para>
        /// </summary>
        /// <returns></returns>
        public static bool Open()
        {
            string filename = OpenPrompt();

            switch (Path.GetExtension(filename))
            {
                case cdf:
                    return Open(filename);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Opens a calendar file.
        /// <para>Returns the success of the opperation.</para>
        /// </summary>
        /// <param name="filename">The path of the calendar to open.</param>
        public static bool Open(string filename)
        {
            bool success = ReadFile(filename, out Calendar calendar);

            if (!success)
                return false;

            Global.Reset();
            Global.Path = filename;
            Calendar.Recalculate();

            return true;
        }

        /// <summary>
        /// Prompts the user with an OpenFileDialog.
        /// <para>Returns the chosen filepath.</para>
        /// </summary>
        /// <param name="ext">The extention to use on opening.</param>
        private static string OpenPrompt()
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = openFilter,
                AddExtension = true,
                RestoreDirectory = true
            };

            if (open.ShowDialog() != DialogResult.OK)
                return null;

            return open.FileName;
        }

        /// <summary>
        /// XmlSerializes an object of type T and saves to a specific path.
        /// <para>Returns the success of the serialization.</para>
        /// </summary>
        /// <param name="obj">The object to XmlSerialize.</param>
        /// <param name="filepath">The path to write the file to.</param>
        public static bool WriteFile<T>(T obj, string filepath, bool showError = true)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                StreamWriter writer = new StreamWriter(filepath);
                xml.Serialize(writer, obj);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                //throw;
                if (showError)
                    MessageBox.Show(e.Message, "Error");

                return false;
            }
        }

        /// <summary>
        /// Deserializes an Xml file.
        /// <para>Returns the success of the deserialization.</para>
        /// </summary>
        /// <param name="filepath">The path to read the file from.</param>
        /// <param name="obj">The object to return.</param>
        public static bool ReadFile<T>(string filepath, out T obj, bool showError = true)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                FileStream stream = new FileStream(filepath, FileMode.Open);
                XmlReader reader = XmlReader.Create(stream);

                obj = (T)xml.Deserialize(reader);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                //throw;
                if (showError)
                    MessageBox.Show(e.Message, "Error");

                obj = default(T);
                return false;
            }
        }
    }
}