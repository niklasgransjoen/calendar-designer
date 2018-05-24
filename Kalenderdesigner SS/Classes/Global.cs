using Kalenderdesigner_SS.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Kalenderdesigner_SS
{
    internal static class Global
    {
        public const string version = "1.2.0";

        public static Form1 mainForm;
        public static PictureBox picBox;
        public static PrivateFontCollection pfc = new PrivateFontCollection();

        public static int year;
        public static int monthInt;
        public static string monthStr;
        public static List<DateTime> dates; //List of dates of the month
        public static DateTime[,] datesArr; //Array with dates of the month

        public static List<string> line1;
        public static List<string> line2;
        public static List<string> line3;
        public static string subtext1;
        public static string subtext2;

        public static List<bool> lineCopyPrev;
        public static List<bool> bigText;

        public static int selectedIndex;
        public static List<int> selectedIndexes;
        public static List<Rectangle> selectedRectangles;

        public static bool saved;
        public static string path;

        //Current settings
        public static Color line1Color;
        public static Color line2Color;
        public static Color line3Color;

        public static Font line1Font;
        public static Font line2Font;
        public static Font line3Font;

        public static void Reset()
        {
            line1 = new List<string>();
            line2 = new List<string>();
            line3 = new List<string>();
            subtext1 = "";
            subtext2 = "";
            lineCopyPrev = new List<bool>();
            bigText = new List<bool>();

            selectedIndex = -1;
            selectedIndexes = new List<int>();
            selectedRectangles = new List<Rectangle>();

            saved = true;
            path = "";
        }

        //Global functions

        /// <summary>
        /// Returns the array index from the list index
        /// </summary>
        /// <param name="index">The index to convert</param>
        /// <returns>An array containing the array index</returns>
        public static int[] ListToArrIndex(int index)
        {
            int[] indexArr = new int[2];

            indexArr[0] = index % datesArr.GetLength(0);
            indexArr[1] = index / datesArr.GetLength(0);

            return indexArr;
        }

        /// <summary>
        /// Get the list index from an array containing the x- and y indexes
        /// </summary>
        /// <param name="index">An array containing the x- and y index</param>
        /// <returns>List index</returns>
        public static int ArrToListIndex(int[] index) => index[0] + index[1] * datesArr.GetLength(0);

        /// <summary>
        /// Get the list index from x- and y indexes
        /// </summary>
        /// <param name="x">The x index</param>
        /// <param name="y">The y index</param>
        /// <returns>List index</returns>
        public static int ArrToListIndex(int x, int y) => ArrToListIndex(new int[] { x, y });

        /// <summary>
        /// Get the text with the gives tag
        /// </summary>
        /// <param name="tag">The tag of the text to return</param>
        /// <returns>Text with tag</returns>
        public static string GetText(string tag)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Resources.text);

            return doc.GetElementsByTagName(tag).Item(0).InnerText;
        }
    }
}