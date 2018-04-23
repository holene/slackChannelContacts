using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlackAPI;

namespace GetEmailSlackBot
{
    class Program
    {
        static void Main(string[] args)
        {

            string BotToken = ConfigurationManager.AppSettings["bottoken"];

            Console.WriteLine(BotToken);
        }
    }
}
