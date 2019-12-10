﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TestProject.ApiModels.User;
using TestProject.Resources;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Interfaces;

namespace TestProject.Services
{
    public class UserService : BaseApiService, IUserService
    {
        private readonly IValidationHelper _validationHelper;

        private readonly IDialogsHelper _dialogsHelper;

        private readonly IPhotoEditHelper _photoEditHelper;

        public UserService(IValidationHelper validationHelper, IDialogsHelper dialogsHelper,
            IStorageHelper storage, IPhotoEditHelper photoEditHelper) : base(storage)
        {
            _url = "http://10.10.3.215:3000/api/userapi";
            _validationHelper = validationHelper;
            _storage = storage;
            _dialogsHelper = dialogsHelper;
            _photoEditHelper = photoEditHelper;
        }

        public async Task<ResponseChangePasswordUserApiModel> ChangePassword(RequestChangePasswordUserApiModel user)
        {
            ResponseChangePasswordUserApiModel response = await Post<RequestChangePasswordUserApiModel,
                ResponseChangePasswordUserApiModel>(user, $"{_url}/ChangePassword");
            return response;
        }

        public async Task<ResponseEditProfileImageUserApiModel> EditProfilePhoto(RequestEditProfileImageUserApiModel user)
        {
            var response = new ResponseEditProfileImageUserApiModel()
            {
                ImageBytes = user.ImageBytes
            };            
            string[] buttons =
                {
                    Strings.ChoosePicture,
                    Strings.TakePicture
                };

            Dictionary<string, Func<Task<byte[]>>> optionResultPairs =
                new Dictionary<string, Func<Task<byte[]>>>();
            optionResultPairs.Add(Strings.CancelText, null);
            optionResultPairs.Add(Strings.ChoosePicture, _photoEditHelper.PickPhoto);
            optionResultPairs.Add(Strings.TakePicture, _photoEditHelper.TakePhoto);
            optionResultPairs.Add(Strings.DeletePicture, _photoEditHelper.DeletePhoto);
            string option = await _dialogsHelper.ChooseOption(Strings.ProfilePhotoTitle,
                Strings.CancelText, Strings.DeletePicture, buttons: buttons);

            if (option == Strings.CancelText)
            {
                return response;
            }
            user.ImageBytes = await optionResultPairs[option]();
            if (user.ImageBytes == null && option != Strings.DeletePicture)
            {
                return response;
            }
            response = await Post<RequestEditProfileImageUserApiModel, ResponseEditProfileImageUserApiModel>
                (user, $"{_url}/EditProfileImage");

            return response;
        }

        public async Task<ResponseEditNameUserApiModel> EditUsername(RequestEditNameUserApiModel user)
        {
            var response = new ResponseEditNameUserApiModel();
            bool isUserNameValid = _validationHelper.IsObjectValid(user);
            if (!isUserNameValid)
            {
                return response;
            }
            response = await Post<RequestEditNameUserApiModel, ResponseEditNameUserApiModel>(user, $"{_url}/EditName");
            if (!response.IsSuccess)
            {
                _dialogsHelper.DisplayAlertMessage(response.Message);
                return response;
            }
            response.IsSuccess = true;
            return response;
        }

        public async Task<string> GetUserName()
        {
            string name = await Get<string>($"{_url}/GetUserName");
            return name;
        }

        public async Task<GetProfileImageUserApiModel> GetUserWithImage()
        {
            GetProfileImageUserApiModel user = await Get<GetProfileImageUserApiModel>($"{_url}/GetProfileImage");
            return user;
        }

        public async Task<ResponseLoginUserApiModel> Login(RequestLoginUserApiModel user)
        {
            ResponseLoginUserApiModel response = await Post<RequestLoginUserApiModel, ResponseLoginUserApiModel>
                (user, $"{_url}/Login");
            if (!response.IsSuccess)
            {
                _dialogsHelper.DisplayAlertMessage(response.Message);
                return response;
            }

            await _storage.Save(response.Token);
            response.IsSuccess = true;

            return response;
        }

        public async Task<ResponseRegisterUserApiModel> RegisterUser(RequestRegisterUserApiModel user)
        {
            var response = new ResponseRegisterUserApiModel();
            bool isUserNameValid = _validationHelper.IsObjectValid(user, nameof(user.Name));
            bool isPasswordValid = _validationHelper.IsObjectValid(user, nameof(user.Password));
            if (!isUserNameValid || !isPasswordValid)
            {
                response.Message = "Invalid format of credentials";
                return response;
            }
            response = await Post<RequestRegisterUserApiModel, ResponseRegisterUserApiModel>
                (user, $"{_url}/Register");
            if (!response.IsSuccess)
            {
                _dialogsHelper.DisplayAlertMessage(response.Message);
            }
            return response;
        }

        public async Task<DeleteUserApiModel> Delete()
        {
            DeleteUserApiModel response = await Delete<DeleteUserApiModel>();
            if (response.IsSuccess)
            {
                _storage.Clear();
            }
            return response;
        }
    }
}
