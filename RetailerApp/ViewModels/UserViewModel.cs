using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using RetailerApp.Setup;
using RetailerApp.Models;

namespace RetailerApp.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnCallback;
        
        public readonly Db_Connection dbconn;
        private ObservableCollection<User> collection;
        private User model;
        private bool check;

        public UserViewModel()
        {
            collection = new ObservableCollection<User>();
            dbconn = new Db_Connection();
            model = new User();
            
            InsertCommand = new RelayCommand(async () => await InsertDataAsync());
            UpdateCommand = new RelayCommand(async () => await UpdateDataAsync());
            DeleteCommand = new RelayCommand(async () => await DeleteDataAsync());
            SelectCommand = new RelayCommand(async () => await ReadDataAsync());
            SelectCommand.Execute(null);
        }

        private async Task ReadDataAsync()
        {
            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = "SELECT * FROM users";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new User
                    {
                        Uid = sqlresult[0].ToString(),
                        Name = sqlresult[1].ToString(),
                        UserName = sqlresult[2].ToString(),
                        KeyPass = sqlresult[3].ToString(),
                        Status = (sqlresult[4].ToString() == "1") ? "Active" : "Not Active"
                    });
                }
            }
            
            dbconn.CloseConnection();
            OnCallback?.Invoke();
        }

        private async Task InsertDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"INSERT INTO users VALUES (" +
                            $"'{model.Name}', " +
                            $"'{model.UserName}', " +
                            $"'{model.KeyPass}', " +
                            $"'{state}')";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }
        
        private async Task UpdateDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"UPDATE users SET " +
                            $"name = '{model.Name}', " +
                            $"username = '{model.UserName}', " +
                            $"keypass = '{model.KeyPass}', " +
                            $"status = '{state}' " +
                            $"WHERE uid = '{model.Uid}'";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }

        private async Task DeleteDataAsync()
        {
            if (IsValidating())
            {
                var msg = MessageBox.Show("Are you sure?", "Question", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(msg == MessageBoxResult.Yes)
                {
                    dbconn.OpenConnection();
                    var query = $"DELETE FROM users WHERE uid = '{model.Uid}'";
                    var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                    sqlcmd.ExecuteNonQuery();
                    dbconn.CloseConnection();
                }
                await ReadDataAsync();
            }
        }

        private bool IsValidating()
        {
         var flag = true;
         if (model.Name == null)
         {
             MessageBox.Show("Text 1 cannot be empty!!!", "Warning",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
         } else if (model.UserName == null)
         {
             MessageBox.Show("Text 2 cannot be empty!!!", "Warning",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
         } else if (model.KeyPass == null)
         {
             MessageBox.Show("Text 3 cannot be empty!!!", "Warning",
                 MessageBoxButton.OK, MessageBoxImage.Exclamation);
         }
         
         return flag;
        }

        public ObservableCollection<User> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(null));
            }
        }
        
        public User Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value != null)
                {
                    IsChecked = (value.Status == "Active") ? true : false;
                }
                model = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(null));
            }
        }

        public bool IsChecked
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(null));
            }
        }
    }
}