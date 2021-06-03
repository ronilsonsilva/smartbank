using System;
using System.Text;

namespace SmartBank.DataValid.Api.Configurations
{
    public class DataValidConfig
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string UriBase { get; set; }
        public string ChaveAcesso 
        {
            get 
            {
                return Convert.ToBase64String(Encoding.ASCII.GetBytes($"{this.ConsumerKey}:{this.ConsumerSecret}"));
            }
        }
    }
}
