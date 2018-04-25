using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSlackMailAPI.Services
{
    public interface ITokenProvider
    {
        string GetToken();
    }

    public class KeyVaultTokenProvider : ITokenProvider
    {
        private string adClientId;
        private string adKey;
        private string keyUrl;

        public KeyVaultTokenProvider(IConfigSetting config)
        {
            adClientId = config.GetSlackMailADID();
            adKey = config.GetADClientKey();
            keyUrl = config.GetSlackMaiADlURL();
        }

        public string GetToken()
        {
            return "";

        }
    }

    public class ConfigTokenProvider : ITokenProvider
    {
        private IConfigSetting _config;

        public ConfigTokenProvider(IConfigSetting config)
        {
            _config = config;
        }

        public string GetToken()
        {
            return _config.GetConfigBotToken();

        }
    }
}
