using System.Windows;

namespace CalendarDesigner.Windows
{
    /// <summary>
    /// Interaction logic for SubtextWindow.xaml
    /// </summary>
    public partial class SubtextWindow : Window
    {
        public SubtextWindow()
        {
            InitializeComponent();

            Subtext1.Text = Global.Calendar.Subtext1;
            Subtext2.Text = Global.Calendar.Subtext2;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Global.Calendar.Subtext1 = Subtext1.Text;
            Global.Calendar.Subtext2 = Subtext2.Text;

            DrawInfo.SubtextSetup();
            Draw.Redraw();
            Global.Saved = false;
            Close();
        }
    }
}