using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.WebApiClient
{
    public class ProfileApiFactory
    {
        public static IProfileApiClient Create(string url)
        {
            return new ProfileApiClient(new RestClient(url));
        }
    }
}
