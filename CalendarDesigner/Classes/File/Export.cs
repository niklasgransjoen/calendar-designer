using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
            Calendar.DropSelection();
            Draw.Multiplier = Multiplier;
            Draw.Recalculate();

            Global.Canvas.Dispatcher.Invoke(DispatcherPriority.Render, (Action)delegate () { });

            RenderTargetBitmap rtb = new RenderTargetBitmap(
                DrawClass.CanvasWidth, DrawClass.CanvasHeight,
                96, 96, PixelFormats.Default);

            rtb.Render(Global.Canvas);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (Stream stream = System.IO.File.OpenWrite(filename))
            {
                pngEncoder.Save(stream);
            }

            Draw.Multiplier = 1;
            Draw.Recalculate();

            return true;
        }
    }
}