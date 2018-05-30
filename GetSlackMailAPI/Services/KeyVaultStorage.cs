using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSlackMailAPI.Services
{

    public interface IConfigSetting
    {
        string GetADClientKey();
        string GetSlackMaiADlURL();
        string GetSlackMailADID();

        string GetConfigBotToken();
        string GetVerificationToken();
    }

    public class KeyVaultStorage : IConfigSetting
    {
        private IConfiguration _configuration;

        public KeyVaultStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetADClientKey()
        {
            return _configuration["GetSlackMailADClientKey"];
        }

        public string GetSlackMaiADlURL()
        {
            return _configuration["GetSlackMailADURL"];

        }

        public string GetSlackMailADID()
        {
            return _configuration["GetSlackMailADID"];
        }

        public string GetConfigBotToken()
        {
            return _configuration["bottoken"];
        }
        public string GetVerificationToken()
        {
            return _configuration["VerificationToken"];
        }
    }
}
