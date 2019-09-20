﻿using System.Collections.Generic;
using System.Threading.Tasks;

using MvvmCross.Commands;
using MvvmCross.Navigation;

using TestProject.Core.ViewModelResults;
using TestProject.Entities;
using TestProject.Resources;
using TestProject.Services.Enums;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Repositories.Interfaces;

namespace TestProject.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private User _currentUser;

        private readonly IUserRepository _userRepository;

        private readonly IDialogsHelper _dialogsHelper;

        private readonly IPhotoEditHelper _photoEditHelper;
        
        public MenuViewModel(IMvxNavigationService navigationService, IUserStorageHelper storage,
            IUserRepository userRepository, IDialogsHelper dialogsHelper, IPhotoEditHelper photoEditHelper)
            : base(navigationService, storage)
        {
            _userRepository = userRepository;
            _dialogsHelper = dialogsHelper;
            _photoEditHelper = photoEditHelper;

            LogoutCommand = new MvxAsyncCommand(Logout);
            ShowSettingsCommand = new MvxAsyncCommand<User>(ShowSettings);
            ShowTodoItemListCommand = 
                new MvxAsyncCommand(async () => await _navigationService.Navigate<TodoItemListViewModel>());
            EditProfilePhotoCommand = new MvxAsyncCommand(EditProfilePhoto);
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

        private string _encryptedProfilePhoto;
        public string EncryptedProfilePhoto
        {
            get => _encryptedProfilePhoto;
            set
            {
                _encryptedProfilePhoto = value;
                RaisePropertyChanged(() => EncryptedProfilePhoto);
            }
        }

        public IMvxAsyncCommand LogoutCommand { get; private set; }

        public IMvxAsyncCommand<User> ShowSettingsCommand { get; private set; }

        public IMvxAsyncCommand ShowTodoItemListCommand { get; private set; }

        public IMvxAsyncCommand EditProfilePhotoCommand { get; private set; }

        public async override Task Initialize()
        {
            await base.Initialize();

            _currentUser = await _storage.Get();
            if (_currentUser == null)
            {
                await _navigationService.Navigate<LoginViewModel>();
                return;
            }
            UserName = _currentUser.Name;
            EncryptedProfilePhoto = _currentUser.EncryptedProfilePhoto;
        }

        private async Task Logout()
        {
            _storage.Clear();
            await _navigationService.Close(this);
            await _navigationService.Navigate<LoginViewModel>();
        }

        private async Task<EditPhotoDialogResult> GetEditPhotoDialogResult()
        {
            string[] buttons =
                {
                    Strings.ChoosePicture,
                    Strings.TakePicture
                };

            Dictionary<string, EditPhotoDialogResult> optionResultPairs =
                new Dictionary<string, EditPhotoDialogResult>();
            optionResultPairs.Add(Strings.CancelText, EditPhotoDialogResult.Cancel);
            optionResultPairs.Add(Strings.ChoosePicture, EditPhotoDialogResult.ChooseFromGallery);
            optionResultPairs.Add(Strings.TakePicture, EditPhotoDialogResult.TakePicture);
            optionResultPairs.Add(Strings.DeletePicture, EditPhotoDialogResult.DeletePicture);

            string option = await _dialogsHelper.ChooseOption(Strings.ProfilePhotoTitle,
                Strings.CancelText, Strings.DeletePicture, buttons: buttons);

            return optionResultPairs[option];
        }

        private async Task EditProfilePhoto()
        {
            EditPhotoDialogResult result = await GetEditPhotoDialogResult();

            if (result == EditPhotoDialogResult.Cancel)
            {
                return;
            }

            string newEncryptedProfilePhoto = await _photoEditHelper.ReplacePhoto(result);
            if (newEncryptedProfilePhoto == null && result != EditPhotoDialogResult.DeletePicture)
            {
                return;
            }

            _currentUser.EncryptedProfilePhoto = newEncryptedProfilePhoto;
            EncryptedProfilePhoto = newEncryptedProfilePhoto;
            await _userRepository.Update(_currentUser);
        }

        private async Task ShowSettings(User user)
        {
            user = _currentUser;
            UpdateResult<User> updateResult = await _navigationService
                .Navigate<UserSettingsViewModel, User, UpdateResult<User>>(user);
        }
    }
}
