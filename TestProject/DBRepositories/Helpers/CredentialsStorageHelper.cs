﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestProject.Configurations;
using TestProject.Entities;
using TestProject.Services.Helpers.Interrfaces;
using TestProject.Services.Repositories;
using Xamarin.Essentials;

namespace TestProject.Services.Helpers
{
    public class CredentialsStorageHelper : IStorageHelper<User>
    {
        public async Task Save(User user)
        {          
            await SecureStorage.SetAsync(Constants.CredentialsKey, user.Id.ToString());
        }

        public async Task<User> Load()
        {
            if (await SecureStorage.GetAsync(Constants.CredentialsKey) == null)
                return null;

            int id = int.Parse(await SecureStorage.GetAsync(Constants.CredentialsKey));
            return await new UserRepository().Find<User>(id);
        }

        public void Clear()
        {
            SecureStorage.RemoveAll();
        }
    }
}