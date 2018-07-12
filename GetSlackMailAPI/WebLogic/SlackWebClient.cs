using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GetSlackMailAPI.SlackResponses;
using Newtonsoft.Json.Linq;
using GetSlackMailAPI.Services;

namespace GetSlackMailAPI.WebLogic
{
    public class SlackWebClient : IWebClient
    {
        private HttpClient _webclient;
        private string bottoken;

        public SlackWebClient(ITokenProvider tokenProvider)
        {
            _webclient = new HttpClient();
            this.bottoken = tokenProvider.GetToken();
        }
        public async Task<AuthTestResponse> SendAuthMessage()
        {
            string url = "https://slack.com/api/auth.test";
            string parameters = $"token={bottoken}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            var obj = (AuthTestResponse)SlackResponseFactory.GetResponse(JsonResponse, "AuthTest");
            return obj;
        }

        private string CreateUrl(string url, string parameters)
        {
            return $"{url}?{parameters}";
        }

        public async Task<ConversationMembersResponse> GetConversationMembers(string channelID)
        {
            string url = "https://slack.com/api/conversations.members";
            string parameters = $"token={bottoken}&channel={channelID}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (ConversationMembersResponse)SlackResponseFactory.GetResponse(JsonResponse, "ConversationMembers");

        }

        /// <summary>
        /// Gets the members of a channel, starting from the given cursor
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public async Task<ConversationMembersResponse> GetConversationMembers(string channelID, string cursor)
        {
            string url = "https://slack.com/api/conversations.members";
            string parameters = $"token={bottoken}&channel={channelID}&cursor={cursor}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (ConversationMembersResponse)SlackResponseFactory.GetResponse(JsonResponse, "ConversationMembers");

        }


        public async Task<ChannelInfoResponse> GetConversationInfo(string channelID)
        {
            string url = "https://slack.com/api/conversations.info";
            string parameters = $"token={bottoken}&channel={channelID}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            

            return (ChannelInfoResponse)SlackResponseFactory.GetResponse(JsonResponse, "ChannelInfo");

        }

        public async Task<UserResponse> GetUserInfo(string memberID)
        {
            string url = "https://slack.com/api/users.info";
            string parameters = $"token={bottoken}&user={memberID}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (UserResponse)SlackResponseFactory.GetResponse(JsonResponse, "UserInfo");
        }

        public async Task<OpenIMResponse> OpenIM(string memberID)
        {
            string url = "https://slack.com/api/im.open";
            string parameters = $"token={bottoken}&user={memberID}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (OpenIMResponse)SlackResponseFactory.GetResponse(JsonResponse, "OpenIMResponse");
        }

        public async Task<PostMessageResponse> PostMessage(string channelID, string message)
        {
            string url = "https://slack.com/api/chat.postMessage";
            string parameters = $"token={bottoken}&channel={channelID}&text={message}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (PostMessageResponse)SlackResponseFactory.GetResponse(JsonResponse, "PostMessageResponse");
        }



    }
}
