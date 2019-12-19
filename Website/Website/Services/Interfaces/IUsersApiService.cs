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

        Task<GetProfileImageUserApiView> GetUserWithPhoto(ClaimsPrincipal principal);

        Task<ResponseEditProfileImageUserApiView> ReplaceProfilePhoto(RequestEditProfileImageUserApiView user,
            string imageUrl, ClaimsPrincipal principal);

        Task<ResponseEditUserNameUserApiView> EditUserName(RequestEditUserNameUserApiView user, ClaimsPrincipal principal);

        Task<GetUserInfoUserApiView> GetUserInfo(ClaimsPrincipal principal);

        Task<ResponseChangePasswordUserApiView> ChangePassword(RequestChangePasswordUserApiView user, ClaimsPrincipal principal);

        Task Logout(ClaimsPrincipal principal);

        Task<DeleteUserApiView> Delete(ClaimsPrincipal principal);

        Task<ResponseRefreshAccessTokenUserApiView> RefreshToken(RequestRefreshAccessTokenUserApiView tokens);

        Task<ConfirmEmailUserApiView> ConfirmEmail(string userId);

        Task<ResponseChangeEmailUserApiView> ChangeEmail(RequestChangeEmailUserApiView requestChangeEmail, ClaimsPrincipal principal);

        Task<ConfirmChangeEmailUserApiView> ConfirmChangeEmail(string userId, string email);

        Task<ResponseForgotPasswordUserApiView> ForgotPassword(RequestForgotPasswordUserApiView user);
    }
}
