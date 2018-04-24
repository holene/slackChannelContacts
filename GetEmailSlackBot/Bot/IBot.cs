using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmailSlackBot.Bot
{
    interface IBot
    {
        void Connect();

        IEnumerable<string> GetEmails();
        void SendMessage(string message, string channelID);
    }
}
