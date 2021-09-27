using System.Text.Json.Serialization;

namespace RestAPI.Models.Firebase.ResponseModels
{
    public class SignUpResponseModel
    {
        [JsonPropertyName("idToken")]
        public string IdToken{ get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("localId")]
        public string LocalId { get; set; }
    }
}
