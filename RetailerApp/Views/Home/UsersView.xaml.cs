using System.Windows;
using System.Windows.Controls;
using RetailerApp.ViewModels;
using RetailerApp.Models;

namespace RetailerApp.Views.Home
{
    public partial class UsersView
    {
        private UserViewModel vm;

        public UsersView()
        {
            InitializeComponent();
            vm = new UserViewModel();
            vm.OnCallback += ResetComponent;
            DataContext = vm;
            ResetComponent();
        }

        private void ResetComponent()
        {
            TxtUid.IsReadOnly = true;

            BtnNew.Visibility = Visibility.Visible;
            BtnEdit.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;
            BtnMenu.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
            LblUid.Visibility = Visibility.Hidden;
            TxtUid.Visibility = Visibility.Hidden;

            TxtName.IsEnabled = false;
            TxtUser.IsEnabled = false;
            TxtPassword.IsEnabled = false;
            ChkStatus.IsEnabled = false;

            vm.Model = new User();
            BtnNew.Focus();
        }

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            BtnNew.Visibility = Visibility.Hidden;
            BtnEdit.Visibility = Visibility.Visible;
            BtnMenu.Visibility = Visibility.Visible;
            BtnReset.Visibility = Visibility.Visible;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            BtnNew.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
            BtnInsert.Visibility = Visibility.Visible;
            TxtName.IsEnabled = true;
            TxtUser.IsEnabled = true;
            TxtPassword.IsEnabled = true;
            ChkStatus.IsEnabled = true;
            vm.Model = new User();
            vm.IsChecked = true;
            TxtName.Focus();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            BtnEdit.Visibility = Visibility.Hidden;
            BtnInsert.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Visible;
            BtnDelete.Visibility = Visibility.Visible;
            BtnMenu.Visibility = Visibility.Visible;
            TxtName.IsEnabled = true;
            TxtUser.IsEnabled = true;
            TxtPassword.IsEnabled = true;
            ChkStatus.IsEnabled = true;
            LblUid.Visibility = Visibility.Visible;
            TxtUid.Visibility = Visibility.Visible;
            TxtName.Focus();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetComponent();
        }
    }
}