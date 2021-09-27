using RestAPI.Models.Firebase.RequestModels;
using RestAPI.Models.Firebase.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Clients.FirebaseClient
{
    public class FirebaseClient : IFirebaseClient
    {
        public Task<SignInResponseModel> SignInAsync(SignInRequestModel user)
        {
            throw new System.NotImplementedException();
        }

        public Task<SignUpResponseModel> SignUpAsync(SignUpRequestModel user)
        {
            throw new System.NotImplementedException();
        }
    }
}
