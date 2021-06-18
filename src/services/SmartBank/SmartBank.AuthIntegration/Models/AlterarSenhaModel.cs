using Newtonsoft.Json;

namespace SmartBank.AuthIntegration.Models
{
    public class AlterarSenhaModel
    {
        public AlterarSenhaModel()
        {

        }
        public AlterarSenhaModel(string confirmPassword, string password, string userId)
        {
            ConfirmPassword = confirmPassword;
            Password = password;
            UserId = userId;
        }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
