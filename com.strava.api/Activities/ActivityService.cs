﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;

namespace com.strava.api.Activities
{
    public class ActivityService
    {
        private const String ActivityUrl = "https://www.strava.com/api/v3/activities/";
        private readonly IAuthentication _authenticator;

        public ActivityService(IAuthentication authenticator)
        {
            if (authenticator == null)
            {
                throw new ArgumentException("The IAuthenticator object must not be null.");
            }

            _authenticator = authenticator;
        }

        public async Task<Activity> GetActivityAsync(string id)
        {
            String getUrl = String.Format("{0}/{1}?access_token={2}", ActivityUrl, id, _authenticator.AuthToken);

            string json = await WebRequest.SendGetAsync(new Uri(getUrl));

            //  Unmarshalling
            return Unmarshaller<Activity>.Unmarshal(json);
        }
    }
}
