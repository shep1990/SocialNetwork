﻿using RestSharp;
using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WebApiClient
{
    public class ProfileApiClient : WebApiClientBase, IProfileApiClient
    {
        public ProfileApiClient(IRestClient client) : base(client)
        {
        }

        public async Task<SignUpModel> CreateProfile(SignUpModel signupModel)
        {
            return await PostAsync<SignUpModel>(new
            {
                signupModel.Id,
                signupModel.Email,
                signupModel.Name,
                signupModel.DateOfBirth,
                signupModel.Age
            }, $"/api/Profile/CreateProfile");
        }
    }
}
