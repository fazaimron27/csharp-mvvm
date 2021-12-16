using System.Windows;

namespace RetailerApp.Views.Home
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void MnuRelogin_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MnuBackup_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MnuUsers_Click(object sender, RoutedEventArgs e)
        {
            PnlContent.Children.Clear();
            PnlContent.Children.Add(new UsersView());
        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MnuInventory_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MnuStock_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void MnuProduct_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}