using System;
using System.IO;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class CalendarSave
    {
        public static bool Save()
        {
            //Show save dialog if there's no path for the file
            if (Global.path == "")
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    FileName = Global.monthStr,
                    Filter = "Calendar Design Format (*.cdf)|*.cdf|All files (*.*)|*.*"
                };

                if (save.ShowDialog() != DialogResult.OK)
                    return false;

                //Save the chosen path
                Global.path = save.FileName;
                if (Global.path.Substring(Global.path.Length - 4) != ".cdf")
                    Global.path += ".cdf";
            }

            WriteToFile();
            return true;
        }

        private static void WriteToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Global.path))
                {
                    string line;

                    writer.WriteLine(Global.version);
                    writer.WriteLine(Global.year);
                    writer.WriteLine(Global.monthInt);

                    for (int i = 0; i < Global.dates.Count; i++)
                    {
                        line = Global.line1[i] + "|";
                        line += Global.line2[i] + "|";
                        line += Global.line3[i] + "|";

                        line += Global.lineCopyPrev[i].ToString() + "|";
                        line += Global.bigText[i].ToString();

                        writer.WriteLine(line);
                    }

                    writer.WriteLine(Global.subtext1);
                    writer.WriteLine(Global.subtext2);
                }

                Global.saved = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(Global.GetText("writeToFileError") + "\n\n" + e.Message,
                    Global.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}