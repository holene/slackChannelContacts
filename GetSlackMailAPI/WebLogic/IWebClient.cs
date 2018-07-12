using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetSlackMailAPI.SlackResponses;
namespace GetSlackMailAPI.WebLogic
{
    public interface IWebClient
    {
        Task<AuthTestResponse> SendAuthMessage();
        Task<ConversationMembersResponse> GetConversationMembers(string channelID);
        Task<ConversationMembersResponse> GetConversationMembers(string channelID, string nextCursor);

        Task<UserResponse> GetUserInfo(string memberID);
        Task<OpenIMResponse> OpenIM(string memberID);
        Task<PostMessageResponse> PostMessage(string channelID, string message);
        Task<ChannelInfoResponse> GetConversationInfo(string channelID);
    }
}
