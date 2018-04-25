using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmailSlackBot.WebLogic
{
    class MailBot
    {
        private IWebClient _client;

        public MailBot(IWebClient client)
        {
            _client = client;
        }




        public async void Run()
        {
            try
            {
                var obj = await _client.GetChannelMembers("C0X725W2G");
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

                var OpenIMObject = await _client.OpenIM("U93STPZ2L");
                Console.WriteLine(OpenIMObject.ToString());

                string emailsString = "";

                foreach (var mail in emails)
                {
                    emailsString += $"{mail},\n";
                }

                emailsString = emailsString.Remove(emailsString.Length - 4);

                var postResponse = await _client.PostMessage(OpenIMObject.channel.id, emailsString);

                Console.WriteLine($"Sent following message: {postResponse.message.text}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
