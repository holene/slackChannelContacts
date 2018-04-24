using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetEmailSlackBot.Bot
{
    class SlackBot : IBot
    {
        private HttpClient webClient;

        public SlackBot(string token)
        {
            webClient = new HttpClient();
        }

        

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetEmails()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, string channelID)
        {
            throw new NotImplementedException();
        }
    }
}
