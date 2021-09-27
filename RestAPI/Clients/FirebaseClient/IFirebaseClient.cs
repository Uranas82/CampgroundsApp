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
