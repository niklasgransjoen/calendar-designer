using System.Drawing;

namespace CalendarDesigner
{
    public static class Export
    {
        private const int Multiplier = 3;

        /// <summary>
        /// Exports the calendar to a picture file.
        /// </summary>
        public static bool GenerateImage(string filename)
        {
            Bitmap bmp = new Bitmap(Global.PicBox.Width * Multiplier, Global.PicBox.Height * Multiplier);
            Graphics g = Graphics.FromImage(bmp);

            Draw.Multiplier *= Multiplier;
            Draw.Recalculate();
            Calendar.DropSelection();

            Draw.Redraw(g);

            Draw.Multiplier /= Multiplier;
            Draw.Recalculate();

            Image image = bmp;

            if (image == null)
                return false;

            image.Save(filename);
            return true;
        }

    }
}