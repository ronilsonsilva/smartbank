using Newtonsoft.Json;

namespace SmartBank.AuthIntegration.Models
{
    public class UserChangePassword
    {
        public UserChangePassword(string userId, string password, string confirmPassword)
        {
            UserId = userId;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
