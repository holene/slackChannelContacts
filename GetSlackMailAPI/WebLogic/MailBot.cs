using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSlackMailAPI.WebLogic
{
    public interface IMailBot
    {
        void Run(string channelID, string requesterID);
    }

    public class MailBot : IMailBot
    {
        private IWebClient _client;

        public MailBot(IWebClient client)
        {
            _client = client;
        }

        public async void Run(string channelID, string requesterID)
        {
            try
            {
                var obj = await _client.GetChannelMembers(channelID);
                Console.WriteLine(obj);

                List<string> emails = new List<string>();

                foreach (var member in obj.members)
                {
                    var user = await _client.GetUserInfo(member);

                    if (!user.user.deleted)
                    {
                        emails.Add(user.user.profile.email);
                        Console.WriteLine(user.ToString());
                    }
                }

                var OpenIMObject = await _client.OpenIM(requesterID);
                Console.WriteLine(OpenIMObject.ToString());

                string emailsString = "";

                foreach (var mail in emails)
                {
                    emailsString += $"{mail},\n";
                }

                emailsString = emailsString.Remove(emailsString.Length - 4);

                var postResponse = await _client.PostMessage(OpenIMObject.channel.id, emailsString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
