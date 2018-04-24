﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GetEmailSlackBot.SlackResponses;
using Newtonsoft.Json.Linq;

namespace GetEmailSlackBot.WebLogic
{
    public class SlackWebClient : IWebClient
    {
        private HttpClient _webclient;
        private string bottoken;

        public SlackWebClient(string token)
        {
            _webclient = new HttpClient();
            this.bottoken = token;
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

        public async Task<ConversationMembersResponse> GetChannelMembers(string channelName)
        {
            string url = "https://slack.com/api/conversations.members";
            string parameters = $"token={bottoken}&channel={channelName}";

            var JsonResponse = await _webclient.GetStringAsync(CreateUrl(url, parameters));

            return (ConversationMembersResponse)SlackResponseFactory.GetResponse(JsonResponse, "ConversationMembers");

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