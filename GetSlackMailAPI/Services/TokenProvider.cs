using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSlackMailAPI.Services
{
    public interface ITokenProvider
    {
        string GetToken();
        string GetVerificationToken();
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
        public string GetVerificationToken()
        {
            return _config.GetVerificationToken();
        }
    }
}
