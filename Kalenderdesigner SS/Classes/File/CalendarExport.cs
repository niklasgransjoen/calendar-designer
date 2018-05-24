using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kalenderdesigner_SS
{
    internal static class CalendarExport
    {
        private static double multiplier = 3;

        /// <summary>
        /// Export calendar to a picture file
        /// </summary>
        public static void Export()
        {
            
            SaveFileDialog save = new SaveFileDialog
            {
                RestoreDirectory = true,
                FileName = Global.monthStr,
                DefaultExt = "png",
                Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|All files (*.*)|*.*"
            };
            Bitmap bmp = new Bitmap(Global.picBox.Width * (int)multiplier, Global.picBox.Height * (int)multiplier);

            List<Rectangle> selectedRectangles = Global.selectedRectangles;
            Global.selectedRectangles = default(List<Rectangle>);

            Graphics g = Graphics.FromImage(bmp);
            AdjustResolution(multiplier);
            CalendarDraw.Draw(g);
            AdjustResolution((1 / multiplier));

            Global.selectedRectangles = selectedRectangles;

            Image image = bmp;

            if (image == null)
                return;

            if (save.ShowDialog() == DialogResult.OK)
            {
                image.Save(save.FileName);
            }
        }

        /// <summary>
        /// Adjust the resolution of the exportet picture
        /// </summary>
        /// <param name="multiplier">How many times bigger the exportet picture should be</param>
        private static void AdjustResolution(double multiplier)
        {
            CalendarDraw.cornerX = (int)(CalendarDraw.cornerX * multiplier);
            CalendarDraw.cornerY = (int)(CalendarDraw.cornerY * multiplier);
            CalendarDraw.cornerYTable = (int)(CalendarDraw.cornerYTable * multiplier);
            CalendarDraw.cornerYBottom = (int)(CalendarDraw.cornerYBottom * multiplier);

            CalendarDraw.paddingX = (int)(CalendarDraw.paddingX * multiplier);
            CalendarDraw.paddingY = (int)(CalendarDraw.paddingY * multiplier);

            CalendarDraw.colWidth = (int)(CalendarDraw.colWidth * multiplier);
            CalendarDraw.rowHeight = (int)(CalendarDraw.rowHeight * multiplier);

            CalendarDraw.width = (int)(CalendarDraw.width * multiplier);
            CalendarDraw.height = (int)(CalendarDraw.height * multiplier);

            CalendarDraw.fontSize = (int)(CalendarDraw.fontSize * multiplier);
            CalendarDraw.headlineSize = (int)(CalendarDraw.headlineSize * multiplier);

            CalendarDraw.logoDiv = (int)(CalendarDraw.logoDiv / multiplier);
            CalendarDraw.infoPosX = (int)(CalendarDraw.infoPosX * multiplier);
            CalendarDraw.infoSize = (int)(CalendarDraw.infoSize * multiplier);
        }
    }
}