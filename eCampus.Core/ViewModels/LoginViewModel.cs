using eCampus.Core.Helpers;
using Microsoft.Phone.Net.NetworkInformation;
using System;
using System.ComponentModel;
using System.Net;
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

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Поле команды для обработки события нажатия клавиши "Увiйти"
        /// </summary>
        private ICommand _loginCommand;

        private BitmapImage _logoSource;

        public string Login { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// Конструктор
        /// </summary>
        public LoginViewModel()
        {
            this._loginCommand = new DelegateCommand(this.LoginAction);
        }

        /// <summary>
        /// Свойство для доступа к команде для обработки события нажатия клавиши "Увiйти"
        /// </summary>
        public ICommand LoginCommand
        {
            get { return this._loginCommand; }
        }

        /// <summary>
        /// Действие при нажатии клавиши "Увiйти"
        /// </summary>
        /// <param name="obj"></param>
        async private void LoginAction(object obj)
        {
            try
            {
                if (AuthenticationStarted != null)
                {
                    AuthenticationStarted();
                }

                var ar = await CampusClient.Auth(this.Login, this.Password);

                if (AuthenticationCompleted != null)
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

                if (AuthenticationFailed != null)
                {
                    AuthenticationFailed();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Получение логотипа в зависимости от темы
        /// </summary>
        public BitmapImage LogoSource
        {
            get
            {
                Visibility darkBackgroundVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
                
                if (darkBackgroundVisibility == Visibility.Visible)
                    _logoSource = new BitmapImage() { UriSource = new Uri(@"\Assets\Images\логоwp_чернаятема.png", UriKind.Relative) };
                else
                    _logoSource = new BitmapImage() { UriSource = new Uri(@"\Assets\Images\логоwp_белаятема.png", UriKind.Relative) };
                return _logoSource;
            }
        }
        
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
