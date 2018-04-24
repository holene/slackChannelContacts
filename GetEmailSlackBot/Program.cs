using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GetEmailSlackBot.WebLogic;

namespace GetEmailSlackBot
{
    class Program
    {
        static void Main(string[] args)
        {

            string BotToken = ConfigurationManager.AppSettings["bottoken"];
            var client = new SlackWebClient(BotToken);
            var bot = new MailBot(client);

            bot.Run();

            while (true)
            {

            }
        }
    }
}
