using System;
using System.Windows;
using System.Reflection;

namespace Calendar_designer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /*[STAThread]
        private static void Main(string[] args)
        {
            string resource1 = "Calendar_designer.Calendar_designer.resources.dll";
            EmbeddedAssembly.Load(resource1, "Calendar_designer.resources.dll");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            App application = new App();
            application.InitializeComponent();
            application.Run(new MainWindow());
        }*/

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }


}