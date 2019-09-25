﻿using System.Threading.Tasks;

using MvvmCross.Commands;
using MvvmCross.Navigation;

using TestProject.Entities;
using TestProject.Resources;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Repositories.Interfaces;

namespace TestProject.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserRepository _userRepository;

        private readonly IDialogsHelper _dialogsHelper;

        private User _currentUser;

        public LoginViewModel(IMvxNavigationService navigationService, IUserRepository userRepository,
            IUserStorageHelper storage, IDialogsHelper dialogsHelper)
            : base(navigationService, storage)
        {
            _userRepository = userRepository;
            _dialogsHelper = dialogsHelper;

            LoginCommand = new MvxAsyncCommand(Login);
            GoToRegistrationCommand = new MvxAsyncCommand(GoToRegistration);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public IMvxAsyncCommand LoginCommand { get; private set; }
        
        public IMvxAsyncCommand GoToRegistrationCommand { get; private set; }
        
        protected async Task<bool> IsDataValid()
        {
            _currentUser = await _userRepository.GetUser(UserName, Password);
            return _currentUser != null;
        }

        private async Task Login()
        {
            bool isUserDataValid = await IsDataValid();
            if (!isUserDataValid)
            {
                _dialogsHelper.DisplayAlertMessage(Strings.LoginErrorMessage);
                return;
            }

            await _storage.Save(_currentUser.Id);
            await _navigationService.Navigate<MainViewModel>();
        }

        private async Task GoToRegistration()
        {
            await _navigationService.Navigate<RegistrationViewModel>();
        }
    }
}
