using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.AuthIntegration.Models
{
    public class User
    {
        #region [Constructors]

        public User()
        {

        }

        public User(string userName, string email, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        #endregion


        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [JsonProperty("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [JsonProperty("accessFailedCount")]
        public int AccessFailedCount { get; set; }

        [JsonProperty("lockoutEnd")]
        public DateTime LockoutEnd { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
