﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Api.User
{
    public class ResponseLoginUserApiView
    {
        public int Id { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}