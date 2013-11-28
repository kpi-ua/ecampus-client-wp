using eCampus.Core.Helpers;
using Microsoft.Phone.Net.NetworkInformation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace eCampus.Core.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле команды для обработки события нажатия клавиши "Увiйти"
        /// </summary>
        private ICommand loginCommand;

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        public LoginViewModel()
        {
            this.loginCommand = new DelegateCommand(this.LoginAction);
        }


        /// <summary>
        /// Свойство для доступа к команде для обработки события нажатия клавиши "Увiйти"
        /// </summary>
        public ICommand LoginCommand
        {
            get
            {
                return this.loginCommand;
            }
        }

        /// <summary>
        /// Действие при нажатии клавиши "Увiйти"
        /// </summary>
        /// <param name="obj"></param>
        async private void LoginAction(object obj)
        {
            try
            {
                string x = await DownloadString(new Uri("http://api.ecampus.kpi.ua/User/Auth?login=" + this.Login + "&password=" + this.Password));
                JToken token = JObject.Parse(x);
                string SessionID = (string)token.SelectToken("Data");
                x = await DownloadString(new Uri("http://api.ecampus.kpi.ua/User/GetPermissions?sessionId=" + SessionID));
                token = JObject.Parse(x);
                JToken Permissions = token.SelectToken("Data");
                string data = string.Empty;
                foreach (var item in Permissions)
                {
                    data += "SubsystemName: ";
                    data += (string)item.SelectToken("SubsystemName");
                    data += "\nIsCreate: ";
                    data += (string)item.SelectToken("IsCreate");
                    data += "\nIsRead: ";
                    data += (string)item.SelectToken("IsRead");
                    data += "\nIsUpdate: ";
                    data += (string)item.SelectToken("IsUpdate");
                    data += "\nIsDelete: ";
                    data += (string)item.SelectToken("IsDelete");
                    data += "\n\n";
                }
                MessageBox.Show(data);
            }
            catch (WebException)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show("Невірний логін чи пароль");
                }
                else
                {
                    MessageBox.Show("Відсутній доступ до мережі Інтернет");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private BitmapImage logoSource;
        /// <summary>
        /// Получение логотипа в зависимости от темы
        /// </summary>
        public BitmapImage LogoSource
        {
            get 
            {
                Visibility darkBackgroundVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
                if (darkBackgroundVisibility == Visibility.Visible)
                    logoSource = new BitmapImage() { UriSource = new Uri(@"\Assets\Images\логоwp_чернаятема.png", UriKind.Relative) };
                else
                    logoSource = new BitmapImage() { UriSource = new Uri(@"\Assets\Images\логоwp_белаятема.png", UriKind.Relative) };
                return logoSource; 
            }
        }


        public static Task<string> DownloadString(Uri url)
        {
            var tcs = new TaskCompletionSource<string>();
            var wc = new WebClient();
            wc.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };
            wc.DownloadStringAsync(url);
            return tcs.Task;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
