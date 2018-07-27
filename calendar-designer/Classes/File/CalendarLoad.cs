using System;
using System.IO;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class CalendarLoad
    {
        public static void Load()
        {
            if (!Global.saved)
            {
                DialogResult result = MessageBox.Show(Global.GetText("unsavedChanges") + "\n\n" + 
                    Global.GetText("saveFirst"), Global.GetText("warning"), MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                    if (!Calendar.Save()) return;
            }

            OpenFileDialog open = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "Calendar Design Format (*.cdf)|*.cdf|Textfile (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (open.ShowDialog() != DialogResult.OK)
                return;

            Global.Reset();
            Global.path = open.FileName;
            if (Global.path.Substring(Global.path.Length - 4) != ".cdf")
            {
                MessageBox.Show(Global.GetText("invalidFormat"), Global.GetText("error"));
                return;
            }

            if (ReadFile())
                Calendar.ReDraw();
            else
                Calendar.GetCalendar();
        }

        private static bool ReadFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Global.path))
                {
                    string[] line;

                    if (reader.ReadLine() != Global.version)
                    {
                        MessageBox.Show(Global.GetText("invalidFile"), Global.GetText("error"));
                        return false;
                    }

                    Global.mainForm.cmbBoxYear.SelectedValue = Convert.ToInt16(reader.ReadLine());
                    Global.mainForm.cmbBoxMonth.SelectedIndex = Convert.ToInt16(reader.ReadLine()) - 1;
                    Calendar.GetCalendar();

                    for (int i = 0; i < Global.dates.Count; i++)
                    {
                        line = reader.ReadLine().Split(new string[] { "|" }, StringSplitOptions.None);

                        Global.line1[i] = line[0];
                        Global.line2[i] = line[1];
                        Global.line3[i] = line[2];

                        Global.lineCopyPrev[i] = Convert.ToBoolean(line[3]);
                        Global.bigText[i] = Convert.ToBoolean(line[4]);
                    }

                    Global.subtext1 = reader.ReadLine();
                    Global.subtext2 = reader.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Global.GetText("readFileError") + "\n\n" + e.Message,
                    Global.GetText("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}