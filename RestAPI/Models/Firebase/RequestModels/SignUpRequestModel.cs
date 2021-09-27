using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPI.Models.Firebase.RequestModels
{
    public class SignUpRequestModel
    {
        [JsonPropertyName("email")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("returnSecureToken")]
        public bool ReturnSecureToken { get; set; }
    }
}
