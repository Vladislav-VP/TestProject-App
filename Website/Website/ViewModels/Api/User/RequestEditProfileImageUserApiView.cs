﻿namespace ViewModels.Api.User
{
    public class RequestEditProfileImageUserApiView
    {
        public string Id { get; set; }

        public byte[] ImageBytes { get; set; }

        public string ImageUrl { get; set; }
    }
}
