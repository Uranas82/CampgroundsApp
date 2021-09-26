using RestAPI.Models.Firebase.RequestModels;
using RestAPI.Models.Firebase.ResponseModels;
using System.Threading.Tasks;

namespace RestAPI.Clients.FirebaseClient
{
    public interface IFirebaseClient
    {
        Task<SignUpResponseModel> SignUpAsync(SignUpRequestModel user);

        Task<SignInResponseModel> SignInAsync(SignInRequestModel user);
    }
}

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