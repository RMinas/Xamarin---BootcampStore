using Acr.UserDialogs;
using BootcampStore.Core.Services.Interfaces;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampStore.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private bool _isBusy;
        private string _username;
        private string _password;

        private readonly IAuthenticationService _authService;
        private readonly IUserDialogs _dialogsService;

        private MvxCommand _loginCommand;
        public IMvxCommand LoginCommand => _loginCommand = _loginCommand ?? new MvxCommand(DoLoginCommand, CanExecute);

        public string Username {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !IsBusy;
        }

        private async void DoLoginCommand()
        {
            IsBusy = true;

            try
            {
                await _authService.LoginAsync(Username, Password);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Password = null;
                _dialogsService.Alert("Invalid Username or Password.");
                return;
            }
            finally
            {
                IsBusy = false;
            }

            Username = null;
            Password = null;
            ShowViewModel<MenuViewModel>();
        }

        public LoginViewModel(IAuthenticationService authService, IUserDialogs dialogsService)
        {
            _authService = authService;
            _dialogsService = dialogsService;
        }


    }
}
