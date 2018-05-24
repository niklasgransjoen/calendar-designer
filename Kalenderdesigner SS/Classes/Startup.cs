using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class Startup
    {
        public static void Setup()
        {
            //Title on mainform, format Vx.x
            Global.mainForm.Text += " V" + Global.version.Substring(0, Global.version.IndexOf(".", Global.version.IndexOf(".") + 1));

            //Fill comboBoxes
            int year;
            ComboBox boxMonth = Global.mainForm.cmbBoxMonth;
            ComboBox boxYear = Global.mainForm.cmbBoxYear;

            for (int i = 0; i < 5; i++)
            {
                year = DateTime.Now.Year + i;
                boxYear.Items.Add(year);
            }

            //Select NEXT month, roll over to next year if necessary
            if (DateTime.Now.Month + 1 <= boxMonth.Items.Count)
            {
                boxMonth.SelectedIndex = DateTime.Now.Month;
                boxYear.Text = DateTime.Now.Year.ToString();
            }
            else
            {
                boxMonth.SelectedIndex = 0;
                boxYear.Text = (DateTime.Now.Year + 1).ToString();
            }

            Calendar.Setup();
        }

        /// <summary>
        /// Load your special font
        /// </summary>
        public static void LoadFont()
        {
            //Select your font from the resources.
            int fontLength = Properties.Resources.ssFont.Length;

            //create a buffer to read in to
            byte[] fontdata = Properties.Resources.ssFont;

            //create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            //pass the font to the font collection
            Global.pfc.AddMemoryFont(data, fontLength);
        }
    }
}