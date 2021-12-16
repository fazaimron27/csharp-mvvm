using System.Windows;
using RetailerApp.Views.Home;

namespace RetailerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dashboard Dashboard;
        public static string SessionUid;
        public static string SessionUser;
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            SessionUid = "";
            SessionUser = "";
            Dashboard = new Dashboard();
            Dashboard.Show();
        }
    }
}