﻿using System.Security.Claims;
using System.Threading.Tasks;

using Entities;
using ViewModels.Api.User;

namespace Services.Interfaces
{
    public interface IUsersApiService : IBaseApiService<User>
    {
        Task<ResponseRegisterUserApiView> Register(RequestRegisterUserApiView userToRegister);

        Task<ResponseLoginUserApiView> Login(RequestLoginUserApiView userRequest, ClaimsPrincipal principal);

        GetProfileImageUserApiView GetUserWithPhoto(string id);

        ResponseEditProfileImageUserApiView ReplaceProfilePhoto(RequestEditProfileImageUserApiView user, string imageUrl);

        ResponseEditNameUserApiView EditUserName(RequestEditNameUserApiView user);

        string GetUserName(string id);

        ResponseChangePasswordUserApiView ChangePassword(RequestChangePasswordUserApiView user);

        DeleteUserApiView Delete(int id);
    }
}