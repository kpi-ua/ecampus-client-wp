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
    public delegate void AuthenticationEventHandler();
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event AuthenticationEventHandler AuthenticationCompleted;

        public event AuthenticationEventHandler AuthenticationStarted;

        public event AuthenticationEventHandler AuthenticationFailed;


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
                if (AuthenticationStarted!=null)
                {
                    AuthenticationStarted();
                }
                AuthResult ar = await CampusAPI.Auth(this.Login, this.Password);
                if (AuthenticationCompleted!=null)
                {
                    AuthenticationCompleted();
                }
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
                if (AuthenticationFailed!=null)
                {
                    AuthenticationFailed();
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
