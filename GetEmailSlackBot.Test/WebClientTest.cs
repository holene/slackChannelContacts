using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetEmailSlackBot.WebLogic;
using System.Configuration;
using System.Linq;
using GetEmailSlackBot.SlackResponses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GetEmailSlackBot.Test
{
    [TestClass]
    public class WebClientTest
    {
        private string token;
        SlackWebClient client;
        public WebClientTest()
        {
            token = ConfigurationManager.AppSettings["bottoken"];
            client = new SlackWebClient(token);
        }

        [TestMethod]
        public void sendAuthenticateMessageResponseNotNull()
        {
            


        }

    }
}
