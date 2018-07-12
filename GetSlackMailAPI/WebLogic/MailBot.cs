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

        public async Task<List<string>> GetEmailsFromChannelMembers(string channelID)
        {
            var usersResponse = await _client.GetConversationMembers(channelID);

            List<string> users = new List<string>(usersResponse.members);

            while (usersResponse.response_metadata != null &&
                !string.IsNullOrEmpty(usersResponse.response_metadata.next_cursor))
            {
                usersResponse = await _client.GetConversationMembers(channelID, usersResponse.response_metadata.next_cursor);
                users.AddRange(usersResponse.members);

            }
            return users;
        }

        public async void Run(string channelID, string requesterID)
        {
            try
            {

                var OpenIMObject = await _client.OpenIM(requesterID);

                await _client.PostMessage(OpenIMObject.channel.id,
                    "I received your request. Please wait while I search for the emails.\n Do note that there will be a delay for large channels, and I will not be able to find locked channels or private conversations.\n");


                var userlist = await GetEmailsFromChannelMembers(channelID);
                List<string> emails = new List<string>();

                foreach (var member in userlist)
                {
                    var user = await _client.GetUserInfo(member);

                    if (!user.user.deleted)
                    {
                        emails.Add(user.user.profile.email);
                    }
                }



                var channelInfo = await _client.GetConversationInfo(channelID);

                string emailsString =
                    $"Here are the emails you requested from channel {channelInfo.channel.name}. I found {emails.Count} email adresses.\n";
                foreach (var mail in emails)
                {
                    emailsString += $"{mail},\n";
                }


                char[] trailingCharacters = new[] {',', '\n'};
                //emailsString = emailsString.Remove(emailsString.LastIndexOf(','));
                emailsString = emailsString.TrimEnd(trailingCharacters);
                await _client.PostMessage(OpenIMObject.channel.id, emailsString);
            }
            catch (undefinedResponseException e)
            {
                var OpenIMObject = await _client.OpenIM(requesterID);
                await _client.PostMessage(OpenIMObject.channel.id, "I got a response i didn't understand from Slack, and was unable to perform the request. This probably means I am broken and need to be fixed.");
            }
            catch (ErrorResponseException e)
            {
                var OpenIMObject = await _client.OpenIM(requesterID);
                var errormsg = $"I got an error message from Slack, which was: {e.ErrorMessage}. ";
                if (e.ErrorMessage == "channel_not_found")
                {
                    errormsg += "Did you try to use me in a private or locked channel?";
                }

                await _client.PostMessage(OpenIMObject.channel.id, errormsg);
            }
            catch (Exception e)
            {
                var OpenIMObject = await _client.OpenIM(requesterID);
                await _client.PostMessage(OpenIMObject.channel.id, "I am sorry, but an error have occured, and I was unable to perform the request.");
            }

        }
    }
}
