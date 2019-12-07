﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

using ViewModels.Api.User;
using Services.Api;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Entities;

namespace TestProject.API.ApiControllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class UserApiController : Controller
    {
        private readonly IUsersApiService _usersService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<User> _userManager;

        public UserApiController(IWebHostEnvironment hostEnvironment, IUsersApiService usersService, UserManager<User> userManager)
        {
            //_usersService = new UsersApiService();
            _hostEnvironment = hostEnvironment;
            _usersService = usersService;
            _userManager = userManager;
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseRegisterUserApiView> Register([FromBody] RequestRegisterUserApiView user)
        {
            ResponseRegisterUserApiView response = await _usersService.Register(user);
            return response;
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseLoginUserApiView> Login([FromBody] RequestLoginUserApiView user)
        {
            ResponseLoginUserApiView userForLogin = await _usersService.Login(user, User);
            return userForLogin;
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public DeleteUserApiView Delete(int id)
        {
            DeleteUserApiView response = _usersService.Delete(id);
            return response;
        }

        [Route("EditProfileImage")]
        [HttpPost]
        public ResponseEditProfileImageUserApiView EditProfileImage([FromBody] RequestEditProfileImageUserApiView user)
        {
            string imageUrl = $"{_hostEnvironment.WebRootPath}\\ProfileImages\\{Guid.NewGuid()}.png";
            ResponseEditProfileImageUserApiView response = _usersService.ReplaceProfilePhoto(user, imageUrl);
            return response;            
        }

        [Route("GetProfileImage/{id}")]
        [HttpGet]
        public GetProfileImageUserApiView GetProfileImage(string id)
        {
            var user = _usersService.GetUserWithPhoto(id);
            return user;
        }

        [Route("GetUserName/{id}")]
        [HttpGet]
        public string GetUserName(string id)
        {
            string name = _usersService.GetUserName(id);
            return name;
        }

        [Route("EditName")]
        [HttpPost]
        public ResponseEditNameUserApiView EditName(RequestEditNameUserApiView user)
        {
            ResponseEditNameUserApiView response = _usersService.EditUserName(user);
            return response;
        }

        [Route("ChangePassword")]
        [HttpPost]
        public ResponseChangePasswordUserApiView ChangePassword(RequestChangePasswordUserApiView user)
        {
            ResponseChangePasswordUserApiView response = _usersService.ChangePassword(user);
            return response;
        }
    }
}